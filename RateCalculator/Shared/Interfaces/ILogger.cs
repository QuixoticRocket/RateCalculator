using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ILogger
    {
        /// <summary>
        /// Logging debug information messages. Will only log if in debug mode
        /// </summary>
        /// <param name="message">the message to log</param>
        void Debug(string message);

        /// <summary>
        /// Logging low priority information messages.
        /// </summary>
        /// <param name="message">the message to log</param>
        void Information(string message);

        /// <summary>
        /// Logging critical information messages.
        /// </summary>
        /// <param name="message">the message to log</param>
        void Critical(string message);

        /// <summary>
        /// Logging Fatal Errors.
        /// </summary>
        /// <param name="message">the message to log</param>
        void Fatal(string message);
    }
}
