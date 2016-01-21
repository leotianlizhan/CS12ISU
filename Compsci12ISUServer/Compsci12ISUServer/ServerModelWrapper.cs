using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compsci12ISUServer
{
    class ServerModelWrapper
    {
        // Shared variables for use between the team
        private SharedVariables _variables;
        // Individual team members' models
        private TianliModel _tianliModel;
        private AndrewModel _andrewModel;


        /// <summary>
        /// Server model wrapper object constructor
        /// </summary>
        public ServerModelWrapper()
        {

            _variables = new SharedVariables();
            _andrewModel = new AndrewModel(_variables, this);
            _tianliModel = new TianliModel(_variables, this);
        }

        /// <summary>
        /// Check if the directory containing the server data exists.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        /// <returns>Returns true if the data is valid, and false if it is not valid.</returns>
        public bool VerifyValidServerData(string path)
        {
            return _andrewModel.VerifyValidServerDirectory(path);
        }

        /// <summary>
        /// Create the folders to store server data at the location previously specified in the launch parameters.
        /// </summary>
        public void GeneratePseudoDirectoryStructure()
        {
            _andrewModel.GeneratePseudoDirectoryStructure();
        }

        public void RequestHandler()
        {
            _andrewModel.RequestHandler();
        }

        /// <summary>
        /// Creates a club admin account
        /// </summary>
        /// <param name="filePath">Path of the request file</param>
        public void CreateAdmin(string filePath)
        {
            _tianliModel.CreateAdmin(filePath);
        }

        /// <summary>
        /// creates a club
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        public void CreateClub(string requestPath)
        {
            _tianliModel.CreateClub(requestPath);
        }

        /// <summary>
        /// Give an admin permission to manage a club
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        public void Assign(string requestPath)
        {
            _tianliModel.Assign(requestPath);
        }

        /// <summary>
        /// Login the admin
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        /// <param name="requestOrigin">Path of where to send the response to</param>
        public void Login(string requestPath, string requestOrigin)
        {
            _tianliModel.Login(requestPath, requestOrigin);
        }

        /// <summary>
        /// Posts new posts
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        /// <param name="requestOrigin">Path of where to send the response</param>
        public void PublishPost(string requestPath, string requestOrigin)
        {
            _tianliModel.PublishPost(requestPath, requestOrigin);
        }

        /// <summary>
        /// Fills the club admins list with previous data
        /// </summary>
        public void FillClubAdmins()
        {
            _tianliModel.FillClubAdmins();
        }
        /// <summary>
        /// Fills the clubs list with previous data
        /// </summary>
        public void FillClubs()
        {
            _tianliModel.FillClubs();
        }

        /// <summary>
        /// Fills the posts list with previous data
        /// </summary>
        public void FillPosts()
        {
            _tianliModel.FillPosts();
        }
    }
}
