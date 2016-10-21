using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTranferObjects;
using Shared.Interfaces;

namespace LoanCalculator.Calculations
{
    internal class Calculation36Months : BaseCalculation, ILoanCalculation
    {
        ILogger logger;

        internal Calculation36Months(ILogger logger)
        {
            this.logger = logger;
        }

        public LoanInformationDTO CalculateBestRateLoan(List<LenderDTO> lenders, decimal loanAmount)
        {
            LoanInformationDTO result = new LoanInformationDTO();
            result.AmountRequested = loanAmount;

            Dictionary<LenderDTO, decimal> lendersAndAmounts = new Dictionary<LenderDTO, decimal>();

            //go through each lender from lowest rate to highest, building up the loan
            List<LenderDTO> orderedList = lenders.OrderBy(l => l.Rate).ToList();
            decimal remainingAmount = loanAmount;
            int currentLender = 0;

            while(remainingAmount > 0 && currentLender < orderedList.Count)
            {
                decimal amountToTake = remainingAmount;
                if (orderedList[currentLender].Available < remainingAmount)
                {
                    amountToTake = orderedList[currentLender].Available;
                }

                lendersAndAmounts.Add(orderedList[currentLender], amountToTake);

                result.AmountAvailable += amountToTake;
                remainingAmount -= amountToTake;
                currentLender++;
            }

            //then for each part of the loan work out it's final amount
            result.TotalRepayment = 0;
            result.Rate = 0;
            foreach (var lenderKvp in lendersAndAmounts)
            {
                result.TotalRepayment += CalculateCompoundInterest(lenderKvp.Value, lenderKvp.Key.Rate, 12, 36);
                //then calculate the weighted rate
                result.Rate += lenderKvp.Key.Rate * (lenderKvp.Value / result.AmountAvailable);
            }
            //monthly repayments
            result.MonthlyRepayment = result.TotalRepayment / 36;


            //return
            return result;

        }
    }
}
