/*
Tianli Zhan
Jan 13, 2016
Class for Tianli's model, contains all the subprograms Tianli did
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ISU
{
    class TianliModel
    {
        //stores the shared variables
        private SharedVariables _variables;
        //stores the model wrapper
        private ClientModelWrapper _wrapper;
        //regex object for matching club informations
        private Regex _reClubInfo = new Regex(@"^\[\|([^|]*)\|([^|]*)\|([^|]*)\|([^|]*)\|([^|]*)\|\]$");
        //time for server to respond
        private const int RESPONSE_TIME = 2000;

        //Creates my model, with wrapper and shared variables as parameter
        public TianliModel(ClientModelWrapper wrapper, SharedVariables variables)
        {
            //set my instance variables to the arguments passed in
            _wrapper = wrapper;
            _variables = variables;
        }

        // Updates the client with possibly new posts. Pass in the amount you want
        public bool UpdatePosts(int amount)
        {
            //attempt to update post
            try
            {
                //write request to a file for the server to read
                using (StreamWriter sw = new StreamWriter(_variables.RequestLocation + "\\pseudo_requests\\Request.txt"))
                {
                    //ask the server for an amount of posts
                    sw.WriteLine("GET listofPosts(" + amount + ")");
                    //get the path of this program
                    string startupPath = System.Windows.Forms.Application.StartupPath.Replace("\\", "/");
                    //tell the server the path of this program
                    sw.WriteLine("Origin: \"" + startupPath + "/posts\"");
                }
                //wait for server to process the request
                System.Threading.Thread.Sleep(RESPONSE_TIME);
                MessageBox.Show("Please, the server takes forever to respond, just wait a few seconds");
                //check the server response
                using (StreamReader responseReader = new StreamReader("RequestResponse.txt"))
                {
                    //if the server denies the request, return false since it was unsuccessful
                    if (responseReader.ReadLine() == "false")
                        return false;
                }
                //clear the post list to put new posts
                _variables.PostList = new List<Post>();
                //get the names of each file in the folder
                string[] posts = Directory.GetFiles(System.Windows.Forms.Application.StartupPath + "\\posts", "*.txt");
                //read until the end of the file
                for(int i=0; i<posts.Length; i++)
                {
                    //read each post
                    using (StreamReader postReader = new StreamReader(posts[i]))
                    {
                        string id = postReader.ReadLine();
                        string content = postReader.ReadLine();
                        _variables.PostList.Add(new Post(id, content));
                    }
                    //delete the post after you read it
                    File.Delete(posts[i]);
                }
            }
            catch
            {
                //if an error is caught, return false
                return false;
            }
            //if everything is fine, return true
            return true;
        }

        // Updates the clubs with possibly changes
        public bool UpdateClubs()
        {
            //attempt at updating
            try
            {
                //clear the old list
                _variables.ClubList.Clear();
                string path = _variables.RequestLocation + "\\clubs\\ListofClubs.txt";
                //read new list of clubs
                using (StreamReader sr = new StreamReader(path))
                {
                    //stores the match for regular expressions
                    Match m;
                    //stores all the information for a club
                    string id;
                    string name;
                    string location;
                    string supervisor;
                    string description;
                    //read until the end of file
                    while(sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        //match with the regular expression written for matching club information
                        m = _reClubInfo.Match(line);
                        //store each information in separate variables
                        id = m.Groups[1].ToString();
                        name = m.Groups[2].ToString();
                        location = m.Groups[3].ToString();
                        supervisor = m.Groups[4].ToString();
                        description = m.Groups[5].ToString();
                        //add the club to the list
                        _variables.ClubList.Add(new Club(id, name, location, supervisor, description));
                    }
                }
            }
            catch
            {
                //if an error occured, return false
                return false;
            }
            //if nothing goes wrong, return true
            return true;
        }

        //publishs a new post with the content
        public bool PublishPost(string id, string content)
        {
            //attempt to request to write new post
            try
            {
                ClearResponse();
                //write to the request file in server's location
                using (StreamWriter sw = new StreamWriter(_variables.RequestLocation + "\\pseudo_requests\\Request.txt"))
                {
                    //replace all the line breaks with "\r\n" so that everything will be on 1 line
                    content = content.Replace(Environment.NewLine, @"\r\n");
                    //write the request
                    sw.WriteLine("POST(" + id + "|" + content + ")");
                    //write the username and password for the admin
                    sw.WriteLine(_variables.Admin.Username);
                    sw.WriteLine(_variables.Admin.Password);
                    //tell the server the path of this program
                    sw.WriteLine("Origin: \"" + System.Windows.Forms.Application.StartupPath.Replace("\\", "/") + "\"");
                }
                //wait for the server to respond
                System.Threading.Thread.Sleep(RESPONSE_TIME);
                //read the server response
                using (StreamReader responseReader = new StreamReader("RequestResponse.txt"))
                {
                    //if the server denies the request, return false since it was unsuccessful
                    if (responseReader.ReadLine() == "false")
                        return false;
                }
            }
            catch
            {
                //if request failed, return false
                return false;
            }
            //if nothing was wrong, return true
            return true;
        }

        //submit changes to the club's information, pass in the id and the new name, location, supervisor, and description
        public bool SubmitChanges(string id, string name, string location, string supervisor, string description)
        {
            //attempt to request to change a club's information
            try
            {
                ClearResponse();
                //write to the request file in server's location
                using (StreamWriter sw = new StreamWriter(_variables.RequestLocation + "\\pseudo_requests\\Request.txt"))
                {
                    //replace all the line breaks with "\r\n" so that everything will be on 1 line
                    description = description.Replace(Environment.NewLine, @"\r\n");
                    //write the request
                    sw.WriteLine("POST club(" + id + "|" + name + "|" + location + "|" + supervisor + "|" + description + ")");
                    //write the username and password for the admin
                    sw.WriteLine(_variables.Admin.Username);
                    sw.WriteLine(_variables.Admin.Password);
                    //tell the server the path of this program
                    sw.WriteLine("Origin: \"" + System.Windows.Forms.Application.StartupPath.Replace("\\", "/") + "\"");
                }
                //wait for the server to respond
                System.Threading.Thread.Sleep(RESPONSE_TIME);
                //read the server response
                using (StreamReader responseReader = new StreamReader("RequestResponse.txt"))
                {
                    //if the server denies the request, return false since it was unsuccessful
                    if (responseReader.ReadLine() == "false")
                        return false;
                }
            }
            catch
            {
                //if request failed, return false
                return false;
            }
            //if nothing was wrong, return true
            return true;
        }

        //Filters the posts for certain clubs, pass in the clubs you want to see
        public List<Post> Filter(List<Club> clubs)
        {
            //stores the result of the filter
            List<Post> result = new List<Post>();
            //loop through each post in postlist
            for(int i=0; i < _wrapper.PostList.Count; i++)
            {
                //loop through each club in the filter
                for(int j=0; j < clubs.Count; j++)
                {
                    //if the post is from this club in the filter
                    if(_wrapper.PostList[i].ID == clubs[j].ID)
                    {
                        //add the post to the result
                        result.Add(_wrapper.PostList[i]);
                    }
                }
            }
            //return the result
            return result;
        }

        //Finds a club based on its id, returns the club found, pass in the id to find
        public Club FindClub(string id)
        {
            //loop through the club list
            for (int i = 0; i < _variables.ClubList.Count; i++)
            {
                //if a match is found for the id
                if (id == _variables.ClubList[i].ID)
                {
                    //return the found club
                    return _variables.ClubList[i];
                }
            }
            //if nothing is found, return null
            return null;
        }

        //Log the admin in, pass in the username and password
        public bool Login(string username, string password)
        {
            //clear the response file
            ClearResponse();
            //updates the club list in case a new club was created for you to manage
            UpdateClubs();
            //create an admin with the username and password
            _variables.Admin = new ClubAdmin(username, password);

            //attempt to request to change a club's information
            try
            {
                //write to the request file in server's location
                using (StreamWriter sw = new StreamWriter(_variables.RequestLocation + "\\pseudo_requests\\Request.txt"))
                {
                    //write the request to log in
                    sw.WriteLine("LOGIN");
                    //write the username and password for the admin
                    sw.WriteLine(_variables.Admin.Username);
                    sw.WriteLine(_variables.Admin.Password);
                    //tell the server the path of this program
                    sw.WriteLine("Origin: \"" + System.Windows.Forms.Application.StartupPath.Replace("\\", "/") + "\"");
                }
                //wait for the server to respond
                System.Threading.Thread.Sleep(RESPONSE_TIME);
                //read the server response
                using (StreamReader responseReader = new StreamReader("RequestResponse.txt"))
                {
                    //if the server accepts the request
                    if (responseReader.ReadLine() == "true")
                    {
                        //stores the id of a club
                        string id;
                        //stores the list of clubs this admin is able to manage
                        List<Club> manageableClubs = new List<Club>();
                        //read the entire response file for all the clubs this admin can manage
                        while (responseReader.Peek() != -1)
                        {
                            //set the id of the club
                            id = responseReader.ReadLine();
                            //find the club in the clublist by id, and add it to the manageableClub list
                            manageableClubs.Add(FindClub(id));
                        }
                        //set the admin's club manage list to the one created based on the server's response
                        _variables.Admin.SetClubManageList(manageableClubs);
                    }
                    else
                    {
                        //server did not respond or did not approve, so the update failed
                        return false;
                    }
                }
            }
            catch
            {
                //if request failed, return false
                return false;
            }
            //if nothing was wrong, return true
            return true;
        }

        //clears the response file
        private void ClearResponse()
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\RequestResponse.txt"))
            {
                sw.WriteLine("");
            }
        }
    }
}
