using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ILoanCalculation
    {
        /// <summary>
        /// Calculates the loan with the best rate based on the lenders given and amount requested
        /// </summary>
        /// <param name="lenders">details of the lenders to use in the calculation</param>
        /// <param name="loanAmount">the requested amount</param>
        /// <returns>a LoanInformationDTO with details on the loan</returns>
        Shared.DataTranferObjects.LoanInformationDTO CalculateBestRateLoan(List<Shared.DataTranferObjects.LenderDTO> lenders, decimal loanAmount);
    }
}
