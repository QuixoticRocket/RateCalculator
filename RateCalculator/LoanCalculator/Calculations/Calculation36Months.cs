using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTranferObjects;

namespace LoanCalculator.Calculations
{
    internal class Calculation36Months : BaseCalculation, Shared.Interfaces.ILoanCalculation
    {
        public LoanInformationDTO CalculateBestRateLoan(List<LenderDTO> lenders, decimal loanAmount)
        {
            throw new NotImplementedException();

            //go through each lender from lowest rate to highest, building up the loan

            //then for each part of the loan work out it's final amount

            //then calculate the weighted rate and amounts

            //return

        }
    }
}
