using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects
{
    public struct LoanInformationDTO
    {
        public decimal AmountRequested;
        public decimal Rate;
        public decimal MonthlyRepayment;
        public decimal TotalRepayment;
    }
}
