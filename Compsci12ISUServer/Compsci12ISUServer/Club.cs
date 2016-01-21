/*
Tianli Zhan
Jan 13, 2016
Class that define clubs, with name, GUID, location, supervisor, and description
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compsci12ISUServer
{
    class Club
    {
        //stores information for a club
        private string _name;
        private string _id;
        private string _location;
        private string _supervisor;
        private string _description;

        //Create a club object with all the information already there
        public Club(string id, string name, string location, string supervisor, string description)
        {
            _id = id;
            Name = name;
            Location = location;
            Supervisor = supervisor;
            Description = description;
        }

        //create a brand new club with a newly generated ID
        public Club(string name)
        {
            Name = name;
            //generate an ID
            _id = Guid.NewGuid().ToString();
        }

        //Gets or sets the ID
        public string ID
        {
            get
            {
                return _id;
            }
        }
        //gets or sets the name
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        //gets or sets the location
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        //gets or sets the supervisor
        public string Supervisor
        {
            get
            {
                return _supervisor;
            }
            set
            {
                _supervisor = value;
            }
        }
        //gets or set the description
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }
}
