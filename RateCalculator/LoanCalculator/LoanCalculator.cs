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
            ILogger logger = new SimpleFileLogger.FileLogger();

            try
            {
                ILoanCalculation calculation = LoanCalculationFactory.GetCalculation(CalculationTypes.ThirtySixMonth, logger);
                ILenderDataReader lenderloader = new LenderFileReader.LenderFileReader(lenderFilename, logger);

                List<LenderDTO> lenderList = lenderloader.LoadAllLenders();

                LoanInformationDTO result = calculation.CalculateBestRateLoan(lenderList, loanAmount);

                return result;
            }
            catch(Exception e)
            {
                logger.Fatal(e.ToString());
            }

            return new LoanInformationDTO();
        }
    }
}
