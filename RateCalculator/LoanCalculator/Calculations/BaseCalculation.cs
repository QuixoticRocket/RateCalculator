using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Calculations
{
    internal abstract class BaseCalculation
    {
        /// <summary>
        /// calculates the total repayable at the end term of the loan using compound interest
        /// </summary>
        /// <param name="principalAmount">the initial loan amount</param>
        /// <param name="rate">annual rate of interest</param>
        /// <param name="numberOfAnnualCompoundPoints">number of times the interest is compounded per year</param>
        /// <param name="loanLengthInMonths">length of the loan in month</param>
        /// <returns></returns>
        internal decimal CalculateCompoundInterest(decimal principalAmount, decimal rate, int numberOfAnnualCompoundPoints, int loanLengthInMonths)
        {
            decimal lengthOfLoanInYears = loanLengthInMonths / (decimal)12;
            decimal rateOverCompoundPoints = rate / numberOfAnnualCompoundPoints;

            return principalAmount * (decimal)Math.Pow(Convert.ToDouble(1 + rateOverCompoundPoints), Convert.ToDouble(numberOfAnnualCompoundPoints * lengthOfLoanInYears));
        }
    }
}
