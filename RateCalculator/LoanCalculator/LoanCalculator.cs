using Shared.DataTranferObjects;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    public class LoanCalculator
    {
        public static LoanInformationDTO CalculateLoan(string lenderFilename, decimal loanAmount)
        {
            ILoanCalculation calculation = LoanCalculationFactory.GetCalculation(CalculationTypes.ThirtySixMonth);
            ILogger logger = new SimpleFileLogger.FileLogger();
            ILenderDataReader lenderloader = new LenderFileReader.LenderFileReader(lenderFilename, logger);

            List<LenderDTO> lenderList = lenderloader.LoadAllLenders();

            LoanInformationDTO result = calculation.CalculateBestRateLoan(lenderList, loanAmount);

            return result;
        }
    }
}
