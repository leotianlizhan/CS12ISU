// Written by ThgilFoDrol
// Logger that logs logs into a log
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compsci12ISUServer
{
    class Logger
    {
        // String to store the type of debug message
        private string _debugType;
        // String to store the current file path
        private string _filepath = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("hh.mm.ss") + ".log";
        // Constant string to store the information prefix
        private const string _PREFIX_INFO = "[INFO]";
        // Constant string to store the warning prefix
        private const string _PREFIX_WARNING = "[WARNING]";
        // Constant string to store the error prefix
        private const string _PREFIX_ERROR = "[SEVERE]";
        // Boolean value to store if the logger has been initialized yet
        private static bool _hasLoggingStarted = false;

        /// <summary>
        /// Log debug information passed in to a line in the latest log file.
        /// </summary>
        /// <param name="line">The line to write to log file.</param>
        /// <param name="type">The type of debug message: 0 = INFO, 1 = WARNING, 2 = ERROR</param>
        public void Log(string line, int type)
        {
            // Check if the type of debug message parameter is 0
            if (type == 0)
            {
                // Set the debug type to the INFO tag
                _debugType = _PREFIX_INFO;
            }
            else if (type == 1) // Check if the type of debug message parameter is 1
            {
                // Set the debug type to the WARNING tag
                _debugType = _PREFIX_WARNING;
            }
            else if (type == 2) // Check if the type of debug message parameter is 2
            {
                // Set the debug type to the ERROR tag
                _debugType = _PREFIX_ERROR;
            }
            else // If the type parameter passed in does not match any existing IDs
            {
                // Set the debug type to UNRECOGNIZED
                _debugType = "[INVALID_ERROR_TYPE]";
            }

            // Create a new streamwriter object to write the log to
            using (StreamWriter sw = new StreamWriter(_filepath, true))
            {
                // Check if the logger was called before
                if (_hasLoggingStarted == true) // if logging has already been called before
                {
                    // Write the log message to the log file with the proper time formatting
                    sw.WriteLine("|{0}| {1} {2}", DateTime.Now.ToString("hh:mm:ss"), _debugType, line);
                    // Write the same thing to console
                    Console.WriteLine("|{0}| {1} {2}", DateTime.Now.ToString("hh:mm:ss"), _debugType, line);
                }
                else // if this is the first time logger is called
                {
                    // Start off the log file with the log file header
                    sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| " + _PREFIX_INFO + " Logging initialized!");
                    sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| " + _PREFIX_INFO + " Current date: " + DateTime.Now.ToString("yyyy-MM-dd"));
                    sw.WriteLine("|" + DateTime.Now.ToString("hh:mm:ss") + "| " + _PREFIX_INFO + " This is an automatically generated log file from the Computer Science 12U ISU Server made by Andrew and Tianli.");
                    // After writing the log file header, write the input log message to the log file with the proper time formatting
                    sw.WriteLine("|{0}| {1} {2}", DateTime.Now.ToString("hh:mm:ss"), _debugType, line);
                    // Write the same thing to console
                    Console.WriteLine("|{0}| {1} {2}", DateTime.Now.ToString("hh:mm:ss"), _debugType, line);
                    // Set the status of the logging to true, to avoid printing the header again
                    _hasLoggingStarted = true;
                }
            }
        }
    }
}
