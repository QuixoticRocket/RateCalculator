using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //we should check the number of args and their types etc, buit for brevity and because i'm taking a bit longer than expected on this I'm keeping this optimistic (and fragile)
            Shared.DataTranferObjects.LoanInformationDTO result = LoanCalculator.LoanCalculator.CalculateLoan(args[0], decimal.Parse(args[1]));

            if(result.AmountAvailable != result.AmountRequested)
            {
                Console.WriteLine("We could not fulfill your request as there is not enough availability at this time");
            }
            else
            {
                Console.WriteLine(string.Format("Requested Amount: £{0:N2}", result.AmountRequested));
                Console.WriteLine(string.Format("Rate: {0:N1}%", result.Rate * 100));
                Console.WriteLine(string.Format("Monthly repayment: £{0:N2}", result.MonthlyRepayment));
                Console.WriteLine(string.Format("Total repayment: £{0:N2}", result.TotalRepayment));
            }

            Console.WriteLine();
            Console.WriteLine("Hit Enter to exit");
            Console.ReadLine();
        }
    }
}
