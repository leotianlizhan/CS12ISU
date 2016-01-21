/*
Tianli Zhan, Andrew Pang
January 19, 2016
Shared variables for both of our models to use
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compsci12ISUServer
{
    class SharedVariables
    {
        // Create a private string variable to store where the directory where the server's data is found.
        private string _serverDirectory;
        // stores the list of club admins
        private List<ClubAdmin> _clubAdmins = new List<ClubAdmin>();
        // stores the list of clubs
        private List<Club> _clubs = new List<Club>();
        // stores the list of posts
        private List<Post> _posts = new List<Post>();

        /// <summary>
        /// The file path to the server's data files
        /// </summary>
        public string ServerDirectory
        {
            get
            {
                return _serverDirectory;
            }
            set
            {
                _serverDirectory = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the club admins list
        /// </summary>
        public List<ClubAdmin> ClubAdmins
        {
            get
            {
                return _clubAdmins;
            }
            set
            {
                _clubAdmins = value;
            }
        }
        /// <summary>
        /// Gets or sets the club admins list
        /// </summary>
        public List<Club> Clubs
        {
            get
            {
                return _clubs;
            }
            set
            {
                _clubs = value;
            }
        }
        /// <summary>
        /// Gets or sets the posts list
        /// </summary>
        public List<Post> Posts
        {
            get
            {
                return _posts;
            }
            set
            {
                _posts = value;
            }
        }
    }
}
