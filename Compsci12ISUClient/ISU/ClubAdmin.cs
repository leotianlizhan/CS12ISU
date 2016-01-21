/*
Tianli Zhan
Jan 13, 2016
Class that defines clubadmin who has permission to edit certain club's information
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    class ClubAdmin : Admin
    {
        //stores the list of clubs the admin is able to manage
        private List<Club> _adminClubList = new List<Club>();

        /// <summary>
        /// Create a club admin
        /// </summary>
        /// <param name="username">Username for the admin</param>
        /// <param name="password">Password for the admin</param>
        /// <param name="adminClubList">List of clubs that the admin has permission to manage</param>
        public ClubAdmin(string username, string password, List<Club> adminClubList)
            :this(username, password)
        {
            AdminClubList = adminClubList;
        }

        /// <summary>
        /// Create a club admin
        /// </summary>
        /// <param name="username">Username for the admin</param>
        /// <param name="password">Password for the admin</param>
        public ClubAdmin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Set the club manage list for this admin
        /// </summary>
        /// <param name="clubsToManage">List of clubs that this admin can manage</param>
        public void SetClubManageList(List<Club> clubsToManage)
        {
            AdminClubList = clubsToManage;
        }

        /// <summary>
        /// Gets or sets the club list that this admin can manage
        /// </summary>
        public List<Club> AdminClubList
        {
            get
            {
                return _adminClubList;
            }
            private set
            {
                _adminClubList = value;
            }
        }
    }
}
