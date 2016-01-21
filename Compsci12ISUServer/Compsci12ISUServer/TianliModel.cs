/*
Tianli Zhan
January 19, 2016
Model containing my subprograms for the server program
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Compsci12ISUServer
{
    class TianliModel
    {
        //stores the model wrapper and shared variables
        private ServerModelWrapper _wrapper;
        private SharedVariables _variables;
        //regex object to extract information about a club and post
        private Regex _reClubInfo = new Regex(@"^\[\|([^|]*)\|([^|]*)\|([^|]*)\|([^|]*)\|([^|]*)\|\]$");
        private Regex _rePost = new Regex(@"^POST\(([^|]*)\|([^|]*)\)$");

        /// <summary>
        /// Creates an object with Tianli's subprograms in the main class
        /// </summary>
        /// <param name="variables">SharedVariables object that has all of the variables shared between the team.</param>
        /// <param name="wrapper">Model wrapper object that contains all of the team's subprograms.</param>
        public TianliModel(SharedVariables variables, ServerModelWrapper wrapper)
        {
            _wrapper = wrapper;
            _variables = variables;
        }

        //fill up the club admins list with previous data
        public void FillClubAdmins()
        {
            //check to see if the ListOfAdmins file exists to prevent errors
            if (!File.Exists(_variables.ServerDirectory + "/admins/ListOfAdmins.txt"))
            {
                using(StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/admins/ListOfAdmins.txt"))
                {
                }
            }
            //read the ListOfAdmins file
            using (StreamReader sr = new StreamReader(_variables.ServerDirectory + "/admins/ListOfAdmins.txt"))
            {
                //stores username and password
                string username;
                string password;
                //read through the entire file
                while (sr.Peek() != -1)
                {
                    //stores the usernames and passwords
                    username = sr.ReadLine();
                    password = sr.ReadLine();
                    //add to the list of club admins
                    _variables.ClubAdmins.Add(new ClubAdmin(username, password));
                    //keep reading lines entil reaching the [END], as this part is the club the admin is able to manage
                    string line = sr.ReadLine();
                    while (line != "[END]")
                    {
                        //add the id of the club to manageable club list of the last club admin
                        _variables.ClubAdmins[_variables.ClubAdmins.Count - 1].ManageableClubs.Add(line);
                        line = sr.ReadLine();
                    }
                }
            }
        }

        //fill up the clubs list with previous data
        public void FillClubs()
        {
            //check to see if the ListOfClubs file exists to prevent errors
            if (!File.Exists(_variables.ServerDirectory + "/clubs/ListOfClubs.txt"))
            {
                using (StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/clubs/ListOfClubs.txt"))
                {
                }
            }
            //read the ListOfClubs file
            using (StreamReader sr = new StreamReader(_variables.ServerDirectory + "/clubs/ListOfClubs.txt"))
            {
                //stores the match for regex
                Match m;
                //stores clubs' information
                string name;
                string id;
                string location;
                string supervisor;
                string description;
                //read through the entire file
                while (sr.Peek() != -1)
                {
                    string line = sr.ReadLine();
                    //match the club's information
                    m = _reClubInfo.Match(line);
                    //stores the club's information
                    id = m.Groups[1].ToString();
                    name = m.Groups[2].ToString();
                    location = m.Groups[3].ToString();
                    supervisor = m.Groups[4].ToString();
                    description = m.Groups[5].ToString();
                    //add the club to the list
                    _variables.Clubs.Add(new Club(id, name, location, supervisor, description));
                }
            }
        }

        //fill up the post list with previous data
        public void FillPosts()
        {
            //check to see if the ListOfClubs file exists to prevent errors
            if (!File.Exists(_variables.ServerDirectory + "/posts/ListOfPosts.txt"))
            {
                return;
            }
            //read the list of posts file
            using (StreamReader postsListReader = new StreamReader(_variables.ServerDirectory + "/posts/ListOfPosts.txt"))
            {
                //stores posts' information, including the file name, the id of the club, and the content
                string name;
                string id;
                string content;
                //read through the entire file
                while (postsListReader.Peek() != -1)
                {
                    //get the name of a post file
                    name = postsListReader.ReadLine();
                    //read and load this post into the list of posts
                    using (StreamReader postReader = new StreamReader(_variables.ServerDirectory + "/posts/" + name))
                    {
                        //read the id and content
                        id = postReader.ReadLine();
                        content = postReader.ReadLine();
                        //same the post into the list
                        _variables.Posts.Add(new Post(name, id, content));
                    }
                }
            }
        }

        /// <summary>
        /// Creates a club admin account
        /// </summary>
        /// <param name="filePath">Path of the request file</param>
        public void CreateAdmin(string filePath)
        {
            //stores the username and password
            string username;
            string password;
            //reads the request file
            using (StreamReader sr = new StreamReader(filePath))
            {
                //skip the first line which is command, already processed by Andrew
                sr.ReadLine();
                //stores the username and password
                username = sr.ReadLine();
                password = sr.ReadLine();
                //check the username and password length
                if(username.Length==0 || password.Length == 0)
                {
                    Console.WriteLine("Invalid username or password length");
                    return;
                }
            }

            
            //read the ListOfAdmins file to make sure username does not repeat
            using (StreamReader sr = new StreamReader(_variables.ServerDirectory + "/admins/ListOfAdmins.txt"))
            {
                //stores other usernames that were already created
                string otherUsername;
                //read through the entire file
                while(sr.Peek() != -1)
                {
                    //stores the other usernames
                    otherUsername = sr.ReadLine();
                    //check if the other username is equal to the username you want to create
                    if(otherUsername == username)
                    {
                        Console.WriteLine("Username already used, please use a different one");
                        return;
                    }
                    //skip the next line which is password
                    sr.ReadLine();
                    //keep reading lines entil reaching the [END], as this part is the club the admin is able to manage
                    string line = sr.ReadLine();
                    while(line!="[END]")
                    {
                        line = sr.ReadLine();
                    }
                }
            }
            //if nothing has gone wrong, it's ready to add the new account
            _variables.ClubAdmins.Add(new ClubAdmin(username, password));
            using (StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/admins/ListOfAdmins.txt", true))
            {
                sw.WriteLine(username);
                sw.WriteLine(password);
                sw.WriteLine("[END]");
            }
        }

        /// <summary>
        /// creates a club
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        public void CreateClub(string requestPath)
        {
            string clubName;
            //read the request
            using (StreamReader sr = new StreamReader(requestPath))
            {
                //skip the first line which is command
                sr.ReadLine();
                //get the club's name
                clubName = sr.ReadLine();
                //first check if the club name is empty
                if(clubName.Length == 0)
                {
                    Console.WriteLine("Cannot use blank name");
                    return;
                }
            }

            //make sure club name does not repeat
            using (StreamReader sr = new StreamReader(_variables.ServerDirectory + "/clubs/ListOfClubs.txt"))
            {
                //stores the match for regular expressions
                Match m;
                //stores the name of the already-created clubs
                string otherClubName;
                //read through the entire file
                while(sr.Peek() != -1)
                {
                    string line = sr.ReadLine();
                    //match with the regular expression written for matching club information
                    m = _reClubInfo.Match(line);
                    //stores the club name
                    otherClubName = m.Groups[2].ToString();
                    //check for same names
                    if(otherClubName==clubName)
                    {
                        Console.WriteLine("Club name already used, please use a different one");
                        return;
                    }
                }
            }

            //if nothing goes wrong, the server will add the club to its list
            using (StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/clubs/ListOfClubs.txt", true))
            {
                Club newClub = new Club(clubName);
                _variables.Clubs.Add(newClub);
                //record the new club
                sw.WriteLine("[|" + newClub.ID + "|" + clubName + "|Empty|Empty|Empty|]");
            }
        }

        /// <summary>
        /// Give an admin permission to manage a club
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        public void Assign(string requestPath)
        {
            string club;
            string admin;
            //read the request
            using (StreamReader sr = new StreamReader(requestPath))
            {
                //skip the first line which is command
                sr.ReadLine();
                //get the club's and admin's name
                club = sr.ReadLine();
                admin = sr.ReadLine();
            }

            //stores the id of the club
            string id = "-1";
            //reads the club list file to find the club name and id
            using (StreamReader sr = new StreamReader(_variables.ServerDirectory + "/clubs/ListOfClubs.txt"))
            {
                //stores the match after using regex
                Match m;
                //stores the name of the club
                string clubName;
                while(sr.Peek() != -1)
                {
                    string line = sr.ReadLine();
                    //match with the regular expression written for matching club information
                    m = _reClubInfo.Match(line);
                    //get the club name
                    clubName = m.Groups[2].ToString();
                    //check if the club names are equal
                    if(clubName == club)
                    {
                        //get the id of the club
                        id = m.Groups[1].ToString();
                        break;
                    }
                }
            }
            //id wasn't found
            if(id=="-1")
            {
                Console.WriteLine("ID was not found in the ListOfClubs");
                return;
            }

            //find the clubadmin and add the club id to its manageable list
            for(int i=0; i<_variables.ClubAdmins.Count; i++)
            {
                if(_variables.ClubAdmins[i].Username == admin)
                {
                    _variables.ClubAdmins[i].ManageableClubs.Add(id);
                    break;
                }
            }

            //update the ListOfAdmins
            using (StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/admins/ListOfAdmins.txt"))
            {
                //loop through the list
                for(int i=0; i<_variables.ClubAdmins.Count; i++)
                {
                    //record the username and password
                    sw.WriteLine(_variables.ClubAdmins[i].Username);
                    sw.WriteLine(_variables.ClubAdmins[i].Password);
                    //loop through the list of manageable clubs
                    for(int j=0; j<_variables.ClubAdmins[i].ManageableClubs.Count; j++)
                    {
                        //write down each id
                        sw.WriteLine(_variables.ClubAdmins[i].ManageableClubs[j].ToString());
                    }
                    //write the ending flag
                    sw.WriteLine("[END]");
                }
            }
        }

        /// <summary>
        /// Login an admin
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        /// <param name="requestOrigin">Path of where to send the response</param>
        public void Login(string requestPath, string requestOrigin)
        {
            //stores the username and password
            string username;
            string password;
            //reads the request
            using (StreamReader sr = new StreamReader(requestPath))
            {
                //skip the first line which is command
                sr.ReadLine();

                //get the username and password
                username = sr.ReadLine();
                password = sr.ReadLine();

                //find the admin in our database
                for(int i=0; i<_variables.ClubAdmins.Count; i++)
                {
                    //make sure the username and password both match
                    if(username == _variables.ClubAdmins[i].Username && password == _variables.ClubAdmins[i].Password)
                    {
                        //write the response
                        using (StreamWriter sw = new StreamWriter(requestOrigin + "\\RequestResponse.txt"))
                        {
                            //write the server approves
                            sw.WriteLine("true");
                            //write the id of the clubs this admin can manage
                            for(int j=0; j<_variables.ClubAdmins[i].ManageableClubs.Count; j++)
                            {
                                sw.WriteLine(_variables.ClubAdmins[i].ManageableClubs[j]);
                            }
                        }
                        return;
                    }
                }
            }

            //If the credentials don't match, inform the client
            Console.WriteLine("Did not find matching credentials");
            using (StreamWriter sw = new StreamWriter(requestOrigin + "\\RequestResponse.txt"))
            {
                sw.WriteLine("false");
            }
        }

        /// <summary>
        /// Posts new posts
        /// </summary>
        /// <param name="requestPath">Path of the request file</param>
        /// <param name="requestOrigin">Path of where to send the response</param>
        public void PublishPost(string requestPath, string requestOrigin)
        {

            //stores the date and time of when the post was received
            string time = DateTime.UtcNow.ToString("MM-dd-yyyy_hh.mm.ss");
            //stores the id and content of the post
            string id;
            string content;
            using (StreamReader sr = new StreamReader(requestPath))
            {
                string line = sr.ReadLine();
                //match the id and content and store them
                Match m = _rePost.Match(line);
                id = m.Groups[1].ToString();
                content = m.Groups[2].ToString();

                //store the username and password, for verification
                string username = sr.ReadLine();
                string password = sr.ReadLine();
                
                //if no match for username and password found
                if(!VerifyAccount(username, password))
                {
                    Console.WriteLine("Invalid credentials");
                    return;
                }
            }
            //record the post
            using (StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/posts/" + time + ".txt"))
            {
                sw.WriteLine(id);
                sw.WriteLine(content);
            }
            //record the post's information in the posts list
            _variables.Posts.Insert(0, new Post(time + ".txt", id, content));
            //record the new posts list in the list of post file
            using (StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/posts/ListOfPosts.txt"))
            {
                //loop through the posts list
                for(int i = 0;i < _variables.Posts.Count; i++)
                {
                    //write the file name of each posts
                    sw.WriteLine(_variables.Posts[i].FileName);
                }
            }
        }

        /// <summary>
        /// Verify the account with the list of admins
        /// </summary>
        /// <param name="username">Username of the account</param>
        /// <param name="password">Password of the account</param>
        /// <returns>True if the account is verified</returns>
        public bool VerifyAccount(string username, string password)
        {
            //look through the database for the username and password to make sure they match
            for (int i = 0; i < _variables.ClubAdmins.Count; i++)
            {
                //if it matches, the account is verified
                if (username == _variables.ClubAdmins[i].Username && password == _variables.ClubAdmins[i].Password)
                {
                    return true;
                }
            }
            //otherwise it's invalid
            return false;
        }
    }
}
