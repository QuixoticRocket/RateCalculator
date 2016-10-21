using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ILenderDataReader
    {
        /// <summary>
        /// Loads a list of lenders for the given criteria
        /// </summary>
        /// <param name="loanLengthInMonths">the length of the loan</param>
        /// <param name="rateMinimum">the minimum rate</param>
        /// <param name="rateMaximum">the maximum rate</param>
        /// <returns>a list of appropriate lenders</returns>
        List<DataTranferObjects.LenderDTO> LoadLenders(int loanLengthInMonths, decimal rateMinimum, decimal rateMaximum);

        /// <summary>
        /// Loads all available lenders
        /// </summary>
        /// <returns>a full list of lenders</returns>
        List<DataTranferObjects.LenderDTO> LoadAllLenders();
    }
}
