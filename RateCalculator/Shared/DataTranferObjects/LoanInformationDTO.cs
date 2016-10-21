using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects
{
    public struct LoanInformationDTO
    {
        decimal AmountRequested;
        decimal Rate;
        decimal MonthlyRepayment;
        decimal TotalRepayment;
    }
}
