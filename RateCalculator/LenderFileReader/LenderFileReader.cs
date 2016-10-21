using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTranferObjects;
using System.IO;
using Shared.Interfaces;

namespace LenderFileReader
{
    public class LenderFileReader : Shared.Interfaces.ILenderDataReader
    {
        string filename;
        ILogger logger;

        public LenderFileReader(string filename, ILogger logger)
        {
            this.logger = logger;
            try
            {
                this.filename = filename;
            }
            catch(Exception e)
            {
                //we could break this down into more detailled messages by catching the appropriate exceptions and tailoring, but for now we'll just log everything the same - fatal
                logger.Fatal(e.ToString());
            }
        }

        public List<LenderDTO> LoadAllLenders()
        {
            List<LenderDTO> lenders = ProcessFile();
            return lenders;
        }

        public List<LenderDTO> LoadLenders(int loanLengthInMonths, decimal rateMinimum, decimal rateMaximum)
        {
            throw new NotSupportedException("This method is not yet complete and is included for extensibility purposes only");
            List<LenderDTO> lenders = ProcessFile();
            lenders = lenders.Where(l => l.Rate > rateMinimum && l.Rate < rateMaximum).ToList();
            //there's no distinction for how long they will lend for so loanLengthInMonths is unused... but then this entire method is unused at the moment and was added for future extensibility
            return lenders;
        }

        //we could split this out into an interfaced item to make testing the rest a little easier, but when it comes to actual reading and writing data we're looking at requiring integration testing anyway.
        private List<LenderDTO> ProcessFile()
        {
            List<LenderDTO> lenderList = new List<LenderDTO>();
            using (StreamReader lenderFile = new StreamReader(filename))
            {
                int lineNumber = 0;
                string currentLine;
                string[] readValues;

                //simply loop through the file reading lines and converting to a lendr. log any issues and continue on

                while(!lenderFile.EndOfStream)
                {
                    lineNumber++; //we do this first as erroring out will prevent it later (also why it's initialized to 0 when we start counting lines at 1)
                    currentLine = lenderFile.ReadLine();

                    readValues = currentLine.Split(',');
                    if(readValues == null || readValues.Length != 3)
                    {
                        //something has gone wrong reading the line. log a message and move on
                        logger.Critical(string.Format("Error reading line {0} from file {1}", lineNumber, filename));
                        continue;
                    }

                    LenderDTO lender = new LenderDTO();
                    lender.Name = readValues[0];
                    if(!decimal.TryParse(readValues[1], out lender.Rate))
                    {
                        //something has gone wrong converting values. log a message and move on
                        logger.Critical(string.Format("Error converting rate on line {0} from file {1}", lineNumber, filename));
                        continue;
                    }
                    else if(lender.Rate < 0)
                    {
                        //negative rate? doesn't seem right. log a message and move on
                        logger.Critical(string.Format("Negative rate found on line {0} from file {1}", lineNumber, filename));
                        continue;
                    }

                    if (!decimal.TryParse(readValues[2], out lender.Available))
                    {
                        //something has gone wrong converting values. log a message and move on
                        logger.Critical(string.Format("Error converting availability on line {0} from file {1}", lineNumber, filename));
                        continue;
                    }
                    else if (lender.Available < 0)
                    {
                        //negative amount available? doesn't seem right. log a message and move on
                        logger.Critical(string.Format("Negative available amount found on line {0} from file {1}", lineNumber, filename));
                        continue;
                    }

                    //if we're here then we've got a good lender. add to the list
                    lenderList.Add(lender);
                }

                return lenderList;
            }
        }
    }
}
