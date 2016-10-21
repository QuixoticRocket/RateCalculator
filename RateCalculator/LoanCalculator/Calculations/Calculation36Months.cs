using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTranferObjects;

namespace LoanCalculator.Calculations
{
    internal class Calculation36Months : BaseCalculation, Shared.Interfaces.ILoanCalulation
    {
        public LoanInformationDTO CalculateBestRateLoan(List<LenderDTO> lenders, decimal loanAmount)
        {
            throw new NotImplementedException();
        }
    }
}
