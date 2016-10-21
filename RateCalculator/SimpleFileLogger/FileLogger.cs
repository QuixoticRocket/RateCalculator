using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileLogger
{
    public class FileLogger : Shared.Interfaces.ILogger
    {
        
       //super simple logging... it leaves much to be desired, but this is not the focus of what we're doing.

        public void Critical(string message)
        {
            using (StreamWriter filelog = new StreamWriter(".\\log.txt", true))
            {
                filelog.WriteLine(string.Format("{0} :: CRITICAL :: {1}", DateTime.Now.ToString(), message));
            }
        }

        public void Debug(string message)
        {
#if(DEBUG)
            using (StreamWriter filelog = new StreamWriter(".\\log.txt", true))
            {
                filelog.WriteLine(string.Format("{0} :: DEBUG :: {1}", DateTime.Now.ToString(), message));
            }
#endif
        }

        public void Fatal(string message)
        {
            using (StreamWriter filelog = new StreamWriter(".\\log.txt", true))
            {
                filelog.WriteLine(string.Format("{0} :: FATAL :: {1}", DateTime.Now.ToString(), message));
            }
        }

        public void Information(string message)
        {
            using (StreamWriter filelog = new StreamWriter(".\\log.txt", true))
            {
                filelog.WriteLine(string.Format("{0} :: INFORMATION :: {1}", DateTime.Now.ToString(), message));
            }
        }
    }
}
