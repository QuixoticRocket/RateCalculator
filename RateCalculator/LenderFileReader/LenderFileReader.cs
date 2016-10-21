using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTranferObjects;

namespace LenderFileReader
{
    public class LenderFileReader : Shared.Interfaces.ILenderDataReader
    {
        public List<LenderDTO> LoadAllLenders()
        {
            throw new NotImplementedException();
        }

        public List<LenderDTO> LoadLenders(int loanLengthInMonths, decimal rateMinimum, decimal rateMaximum)
        {
            throw new NotImplementedException();
        }
    }
}
