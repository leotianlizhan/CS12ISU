using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compsci12ISUServer
{
    class Program
    {
        /// <summary>
        /// Create a new model wrapper object
        /// </summary>
        private static ServerModelWrapper _wrapper;

        /// <summary>
        /// Create a new logger object
        /// </summary>
        private static Logger _logger = new Logger();

        static void Main(string[] args)
        {
            _wrapper = new ServerModelWrapper();

            // Temporary parameters setup
            string dataPath = "E:/ISU/Compsci12ISUServer_Data";
            // end of temporary setup

            // Server startup confirmation with debug
            _logger.Log("Server starting up!", 0);

            // Check if the first parameter exists
            if (args.Length > 0)
            {
                // Check if the server data folder is valid
                if (_wrapper.VerifyValidServerData(args[0]))
                {
                    _logger.Log("The file path specified for the first argument is valid.", 0);
                }
                else
                {
                    _logger.Log("The file path specified for the first argument is invalid.", 2);
                    _logger.Log("Server did not start properly, quitting...", 1);
                    Environment.Exit(0);
                }
            }
            else // if the first parameter does not exist
            {
                _wrapper.VerifyValidServerData(dataPath);
                _logger.Log("There was no file path specified to retrieve server data from.", 2);
                _logger.Log("Server did not start properly, quitting...", 1);
                //Environment.Exit(0);
            }

            //Console.WriteLine("Argument 1: " + dataPath);

            //fill the clubadmins and clubs list with previous data
            _wrapper.FillClubAdmins();
            _wrapper.FillClubs();
            _wrapper.FillPosts();

            _wrapper.GeneratePseudoDirectoryStructure();

            Console.WriteLine("Server ready.");

            while (true)
            {
                _wrapper.RequestHandler();
                // Give the poor cpu a coffee break
                System.Threading.Thread.Sleep(10);
            }
        }


        //private void RunServer()
        //{
        //    // Main server loop
        //    while (true)
        //    {

        //        // Give the poor cpu a coffee break
        //        System.Threading.Thread.Sleep(50);
        //    }
        //}
    }
}
