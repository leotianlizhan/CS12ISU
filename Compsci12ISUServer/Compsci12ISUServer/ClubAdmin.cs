/*
Tianli Zhan
January 19, 2016
A class to store club admin datatype, which contains username password, and a list of club ids to manage
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compsci12ISUServer
{
    class ClubAdmin
    {
        //stores the username, password, and a list of manaeable clubs' ids
        private string _username;
        private string _password;
        private List<string> _manageableClubs = new List<string>();

        //create a club admin with username and password
        public ClubAdmin(string username, string password)
        {
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Gets the username
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
        }

        /// <summary>
        /// Gets the password
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
        }

        public List<string> ManageableClubs
        {
            get
            {
                return _manageableClubs;
            }
            set
            {
                _manageableClubs = value;
            }
        }
    }
}
