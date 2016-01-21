/*
Tianli Zhan
Jan 13, 2016
Abstract class that defines a generic admin, with username and password
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    abstract class Admin
    {
        //stores the username and password for the admin
        protected string _username;
        protected string _password;

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
            protected set
            {
                _username = value;
            }
        }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            protected set
            {
                _password = value;
            }
        }
    }
}
