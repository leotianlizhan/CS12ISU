/*
Tianli Zhan
Jan 13, 2016
Class that contains all the shared variables for all programmers to use
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ISU
{
    class SharedVariables
    {
        //stores the list of clubs and list of posts for display
        private List<Club> _clubList = new List<Club>();
        private List<Post> _postList = new List<Post>();
        private ClubAdmin _admin;
        private string _requestLocation;

        //initialize some data in shared variables when it's first created
        public SharedVariables()
        {
            //check if the config file exist
            if(!File.Exists("config.txt"))
            {
                //if it doesn't inform the user that the config file is missing
                MessageBox.Show("config.txt file not found. It is needed for specifying the server's location", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //exits the application
                Environment.Exit(0);
            }
            //read the config file
            using (StreamReader sr = new StreamReader("config.txt"))
            {
                //set the request location to the one in config
                RequestLocation = sr.ReadLine();
            }
        }

        //Gets or sets the list of clubs
        public List<Club> ClubList
        {
            get { return _clubList; }
            set { _clubList = value; }
        }

        //Gets or sets the list of posts
        public List<Post> PostList
        {
            get { return _postList; }
            set { _postList = value; }
        }

        //Gets or sets the club admin
        public ClubAdmin Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        //Gets or sets the location to send request (server location)
        public string RequestLocation
        {
            get { return _requestLocation; }
            private set { _requestLocation = value; }
        }
    }
}
