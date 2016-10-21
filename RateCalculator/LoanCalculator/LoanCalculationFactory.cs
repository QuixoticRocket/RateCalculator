using LoanCalculator.Calculations;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    internal enum CalculationTypes
    {
        ThirtySixMonth,
    }

    internal class LoanCalculationFactory
    {
        internal static ILoanCalculation GetCalculation(CalculationTypes typeOfCalculation, ILogger logger)
        {
            switch (typeOfCalculation)
            {
                case CalculationTypes.ThirtySixMonth:
                    return new Calculation36Months(logger);
                    break;
                default:
                    throw new NotSupportedException("The requested calculation type is not supported yet");
                    break;
            }
        }
    }
}
