using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Compsci12ISUServer
{
    class AndrewModel
    {
        /// <summary>
        /// Create a new model wrapper object
        /// </summary>
        private ServerModelWrapper _wrapper;
        // Create a new shared variables object
        private SharedVariables _variables;
        
        // Create a new logger object
        private static Logger _logger = new Logger();

        // Create and store constant strings for request verbs
        private const string GET = "GET";
        private const string POST = "POST";
        private const string ERROR = "ERROR";
        private const string NEW_ADMIN = "NEW CLUBADMIN";
        private const string NEW_CLUB = "NEW CLUB";
        private const string ASSIGN = "ASSIGN";
        private const string LOGIN = "LOGIN";
        // Create and store constant strings for request nouns
        private const string LIST_OF_POSTS = "listofPosts";

        // Create and store constant strings for regex patterns
        // private const string PAT_LIST_OF_POSTS = @"^([\w]*)\(([0-9]+)\)";
        private const string PAT_LIST_OF_POSTS = @"^listofPosts\(([0-9]+)\)";
        private const string PAT_CLUB_INFO = @"^club\(([^|]*)\|([^|]*)\|([^|]*)\|([^|]*)\|([^|]*)\)";
        private const string PAT_POST = @"^\(([^|]*)\|([^|]*)\)$";

        /// <summary>
        /// Creates an object with Andrew's subprograms in the main class
        /// </summary>
        /// <param name="variables">SharedVariables object that has all of the variables shared between the team.</param>
        /// <param name="wrapper">Model wrapper object that contains all of the team's subprograms.</param>
        public AndrewModel(SharedVariables variables, ServerModelWrapper wrapper)
        {            
            _wrapper = wrapper;
            _variables = variables;
        }

        /// <summary>
        /// Check if the server data stored in a specified directory exists.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>Returns true if it is valid, and false otherwise.</returns>
        public bool VerifyValidServerDirectory(string path)
        {
            // Check if the directory exists
            if (Directory.Exists(path))
            {
                // Store the specified location of server data.
                _variables.ServerDirectory = path;
                
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create the folders to store server data at the location previously specified in the launch parameters.
        /// </summary>
        public void GeneratePseudoDirectoryStructure()
        {
            try
            {
                // Check if the clubs directory does not exist
                if (!Directory.Exists(_variables.ServerDirectory + "/clubs"))
                {
                    // Create the directory so the server can write or retrieve data to/from them.
                    Directory.CreateDirectory(_variables.ServerDirectory + "/clubs");
                    _logger.Log("Clubs directory in " + _variables.ServerDirectory + " was not found, creating it.", 0);
                }
                else // if it does exist
                {
                    _logger.Log("Found clubs directory in " + _variables.ServerDirectory + " directory.", 0);
                }

                // Check if the posts directory does not exist
                if (!Directory.Exists(_variables.ServerDirectory + "/posts"))
                {
                    // Create the directory so the server can write or retrieve data to/from them.
                    Directory.CreateDirectory(_variables.ServerDirectory + "/posts");
                    _logger.Log("Posts directory in " + _variables.ServerDirectory + " was not found, creating it.", 0);
                }
                else // if it does exist
                {
                    _logger.Log("Found posts directory in " + _variables.ServerDirectory + " directory.", 0);
                }

                // Check if the users directory does not exist
                if (!Directory.Exists(_variables.ServerDirectory + "/users"))
                {
                    // Create the directory so the server can write or retrieve data to/from them.
                    Directory.CreateDirectory(_variables.ServerDirectory + "/users");
                    _logger.Log("Users directory in " + _variables.ServerDirectory + " was not found, creating it.", 0);
                }
                else // if it does exist
                {
                    _logger.Log("Found users directory in " + _variables.ServerDirectory + " directory.", 0);
                }

                // Check if the pseudo requests directory does not exist
                if (!Directory.Exists(_variables.ServerDirectory + "/pseudo_requests"))
                {
                    // Create the directory so the server can write or retrieve data to/from them.
                    Directory.CreateDirectory(_variables.ServerDirectory + "/pseudo_requests");
                    _logger.Log("Pseudo requests directory in " + _variables.ServerDirectory + " was not found, creating it.", 0);
                }
                else // if it does exist
                {
                    _logger.Log("Found pseudo requests directory in " + _variables.ServerDirectory + " directory.", 0);
                }

                // Check if the admins directory does not exist
                if (!Directory.Exists(_variables.ServerDirectory + "/admins"))
                {
                    // Create the directory so the server can write or retrieve data to/from them.
                    Directory.CreateDirectory(_variables.ServerDirectory + "/admins");
                    _logger.Log("admins directory in " + _variables.ServerDirectory + " was not found, creating it.", 0);
                }
                else // if it does exist
                {
                    _logger.Log("Found admins directory in " + _variables.ServerDirectory + " directory.", 0);
                }
            }
            catch (Exception e) // if there is an i/o issue when creating the directories
            {
                _logger.Log(e.ToString(), 2);
            }
        }

        /// <summary>
        /// Respond to all requests sent to the server by the active clients.
        /// </summary>
        public void RequestHandler()
        {
            // Store the list of unprocessed requests
            List<string> requestsList = CheckForNewRequest();
            // Create a new regex object
            Regex regex;
            // Create a new match object
            Match match;
            // Create a new group object
            Group group;

            // Loop through each unprocessed request and process it
            foreach (string requestPath in requestsList)
            {
                // Retrieve and store the verb in the specified request
                string verb = GetRequestVerb(requestPath);
                // Retrieve and store the noun in the specified request
                string noun = GetRequestNoun(requestPath);

                // Check if the verb matches the GET verb
                if (verb == GET)
                {
                    // Check if the noun matches the pattern stored for retrieving the list of posts
                    if (Regex.IsMatch(noun, PAT_LIST_OF_POSTS))
                    {
                        // Instantiate a new regex object with the pattern stored for retrieving the list of posts
                        regex = new Regex(PAT_LIST_OF_POSTS);
                        // Search the noun for a match
                        match = regex.Match(noun);
                        // Retrieve the integer value from the first matching group- this is the quantifier for the noun
                        group = match.Groups[1];

                        // Save the origin data value of the request at the specified location to a string variable
                        string origin = GetRequestOrigin(requestPath);
                        // Check if the result is not an error
                        if (origin != ERROR)
                        {
                            // Create an integer variable to store the quantity parameter
                            int quantity;
                            // Convert the quantity from string to int
                            int.TryParse(group.ToString(), out quantity);
                            // Respond with the list of posts, taking into consideration the quantity
                            RespondWithListOfPosts(origin, quantity);
                        }
                    }
                }
                else if (verb == POST) // if the verb matches the POST verb
                {
                    //if the noun matches the edit-club-info command
                    if (Regex.IsMatch(noun, PAT_CLUB_INFO))
                    {
                        // Instantiate a new regex object with the pattern stored for editing the club info
                        regex = new Regex(PAT_CLUB_INFO);
                        // Look for a match
                        match = regex.Match(noun);

                        // Retrieve the string value from the first matching group- this is the ID of the club
                        group = match.Groups[1];
                        // Store the ID of the club
                        string ID = group.ToString();
                        // Retrieve the string value from the second matching group- this is the name of the club
                        group = match.Groups[2];
                        // Store the name of the club
                        string name = group.ToString();
                        // Retrieve the string value from the third matching group- this is the meeting location of the club
                        group = match.Groups[3];
                        // Store the meeting location of the club
                        string location = group.ToString();
                        // Retrieve the string value from the fourth matching group- this is the organizer of the club
                        group = match.Groups[4];
                        // Store the organizer of the club
                        string organizer = group.ToString();
                        // Retrieve the string value from the fifth matching group- this is the description for the club
                        group = match.Groups[5];
                        // Store the description for the club
                        string description = group.ToString();

                        // Check if the client has a valid origin
                        if (GetRequestOrigin(requestPath) != ERROR)
                        {
                            // Edit the club info
                            EditClubData(ID, name, location, organizer, description);
                        }
                    }
                    else if(Regex.IsMatch(noun, PAT_POST)) // check if the user wants to publish a new post
                    {
                        _wrapper.PublishPost(requestPath, GetRequestOrigin(requestPath));
                    }
                    else
                    {
                        _logger.Log("Did not find valid noun for the request stored at \"" + requestPath + "\", deleting request and skipping to the next one.", 1);
                    }
                }
                else if (verb == NEW_ADMIN)
                {
                    _wrapper.CreateAdmin(requestPath);
                }
                else if (verb == NEW_CLUB)
                {
                    _wrapper.CreateClub(requestPath);
                }
                else if(verb == ASSIGN)
                {
                    _wrapper.Assign(requestPath);
                }
                else if(verb == LOGIN)
                {
                    _wrapper.Login(requestPath, GetRequestOrigin(requestPath));
                }
                else // if the verb does not match the currently defined ones
                {
                    _logger.Log("Did not find valid verb for the request stored at \"" + requestPath + "\", deleting request and skipping to the next one.", 1);
                }
                // Delete the request file
                File.Delete(requestPath);
            }

        }

        /// <summary>
        /// Check to see if there are unprocessed request(s) to respond to inside ./pseudo_requests.
        /// </summary>
        /// <returns>Returns the string list of unprocessed request names.</returns>
        private List<string> CheckForNewRequest()
        {
            // String array to hold the list of unprocessed requests.
            string[] requests = Directory.GetFiles(_variables.ServerDirectory + "/pseudo_requests", "*.txt");
            // String list to hold the list of unprocessed requests.
            List<string> requestsList = new List<string>();

            // Store the list of requests
            requestsList = requests.ToList<string>();

            // Check if there are more than 0 requests
            if (requestsList.Count > 0)
            {
                // Check if there is one request
                if (requestsList.Count == 1)
                {
                    // Log debug message
                    _logger.Log("Found 1 request that has not yet been processed.", 0);
                    // Return the list of file names
                    return requestsList;
                }
                else // if more than one request
                {
                    // Log debug message
                    _logger.Log("Found " + requestsList.Count.ToString() + " requests that still have to be processed.", 0);
                    // Return the list of file names
                    return requestsList;
                }
            }
            else // if no requests are found
            {
                // Log debug message
                _logger.Log("No unprocessed requests were found.", 0);
                // Return the list of file names
                return requestsList;
            }

        }

        /// <summary>
        /// Get the verb of the request stored at the specified file path.
        /// </summary>
        /// <param name="path">The path to the simulated request text file.</param>
        /// <returns>Returns the verb (e.g. GET, POST, etc).</returns>
        private string GetRequestVerb(string path)
        {
            // Make sure the file at specified path still exists
            if (File.Exists(path))
            {
                // Instantiate a new streamreader object to read the file located at the path passed in
                using (StreamReader sr = new StreamReader(path))
                {
                    // Get the first line
                    string currentLine = sr.ReadLine();
                    // Check if the line contains the GET verb
                    if (currentLine.Contains(GET))
                    {
                        // Return GET
                        return GET;
                    }
                    else if (currentLine.Contains(POST)) // Check if the line contains the POST verb
                    {
                        // Return POST
                        return POST;
                    }
                    else if(currentLine == NEW_ADMIN) // check if the line is the NEW_ADMIN verb
                    {
                        //return NEW_ADMIN
                        return NEW_ADMIN;
                    }
                    else if(currentLine == NEW_CLUB) // check if the line is the NEW_CLUB verb
                    {
                        //return NEW_CLUB
                        return NEW_CLUB;
                    }
                    else if(currentLine == ASSIGN) // check if the line is the ASSIGN verb
                    {
                        //return ASSIGN
                        return ASSIGN;
                    }
                    else if(currentLine == LOGIN) // check if the line is the LOGIN verb
                    {
                        //return LOGIN
                        return LOGIN;
                    }
                    else // no matching verbs found
                    {
                        // Return ERROR
                        return ERROR;
                    }
                }
            }
            else // if somehow the file no longer exists
            {
                // Log debug data and report error to output feed
                _logger.Log("Could not retrieve request verb from file specified at \"" + path + "\"- it does not exist anymore (thrown by _wrapper.GetRequestVerb using the path from _wrapper.CheckForNewRequest).", 1);
                // Return ERROR
                return ERROR;
            }
        }

        /// <summary>
        /// Get the noun of the request stored at the specified file path and any associated parameters.
        /// </summary>
        /// <param name="path">The path to the simulated request text file.</param>
        /// <returns>Returns the noun (e.g. GET, POST, etc).</returns>
        private string GetRequestNoun(string path)
        {
            // Make sure the file at specified path still exists
            if (File.Exists(path))
            {
                // Instantiate a new streamreader object to read the file located at the path passed in
                using (StreamReader sr = new StreamReader(path))
                {
                    // Get the first line
                    string currentLine = sr.ReadLine();
                    // Try to replace the GET verb with a space
                    currentLine = currentLine.Replace(GET, " ");
                    // Try to replace the POST verb with a space
                    currentLine = currentLine.Replace(POST, " ");
                    // Trim leading/trailing spaces
                    currentLine = currentLine.Trim();
                    // Return the formatted current line (the noun)
                    return currentLine;
                }
            }
            else // if somehow the file no longer exists
            {
                // Log debug data and report error to output feed
                _logger.Log("Could not retrieve request noun from file specified at \"" + path + "\"- it does not exist anymore (thrown by _wrapper.GetRequestNoun using the path from _wrapper.CheckForNewRequest).", 1);
                // Return ERROR
                return ERROR;
            }
        }

        /// <summary>
        /// Gets the origin of the request stored at the specified file path.
        /// </summary>
        /// <param name="path">The path to the simulated request text file.</param>
        /// <returns>Returns the absolute path of where the client claims to be located.</returns>
        private string GetRequestOrigin(string path)
        {
            // Make sure the file at specified path still exists
            if (File.Exists(path))
            {
                // Instantiate a new streamreader object to read the file located at the path passed in
                using (StreamReader sr = new StreamReader(path))
                {
                    // Keep looping through the lines until you reach the end of the file
                    while (sr.Peek() != -1)
                    {
                        // Get the first line
                        string currentLine = sr.ReadLine();
                        // 
                        if (currentLine.StartsWith("Origin: "))
                        {
                            // Replace the tag with space
                            currentLine = currentLine.Replace("Origin: ", " ");
                            // Replace the quotation marks with space
                            currentLine = currentLine.Replace("\"", " ");
                            // Cull leading/trailing whitespace characters
                            currentLine = currentLine.Trim();
                            // Return the origin file path (the noun)
                            return currentLine;
                        }                        
                    }
                    return ERROR;
                }
            }
            else // if somehow the file no longer exists
            {
                // Log debug data and report error to output feed
                _logger.Log("Could not retrieve request noun from file specified at \"" + path + "\"- it does not exist anymore (thrown by _wrapper.GetRequestNoun using the path from _wrapper.CheckForNewRequest).", 1);
                // Return ERROR
                return ERROR;
            }
        }

        /// <summary>
        /// Sends a response to the client containing a list of posts in the quantity requested.
        /// </summary>
        /// <param name="target">The file path location of the client.</param>
        /// <param name="quantifier">The amount of posts to send.</param>
        private void RespondWithListOfPosts(string target, int quantifier)
        {
            try // attempt to write a response to target
            {
                //// Instantiate a new streamwriter object to write a response to the target
                //using (StreamWriter sw = new StreamWriter(target + "/RequestResponse.txt"))
                //{
                    int startTime = Environment.TickCount;
                    // String array to hold the list of posts.
                    string[] posts = Directory.GetFiles(_variables.ServerDirectory + "/posts", "*.txt");
                    // Create a new string list to store the list of posts to send
                    List<string> postsList = new List<string>();

                    // Use streamreader to access the list of posts
                    using (StreamReader sr = new StreamReader(_variables.ServerDirectory + "/posts/ListOfPosts.txt"))
                    {
                        // Create a counter and set to 0
                        int counter = 0;
                        // Loop until the end of the file
                        while (sr.Peek() != -1 && counter < quantifier)
                        {
                            // Add the text file named in the line to the posts list
                            postsList.Add(sr.ReadLine());
                            // Increment counter by 1
                            counter++;
                        }
                    }

                    // Loop through each post in the list of posts
                    foreach (string indPost in postsList)
                    {
                        // Upon making sure the file still exists...
                        if (File.Exists(_variables.ServerDirectory + "/posts/" + indPost))
                        {
                            // ...copy the post to the origin of the request
                            File.Copy(_variables.ServerDirectory + "/posts/" + indPost, target + "/" + indPost, true);                            
                        }
                    }

                    // Cleanup and reset variables
                    postsList.Clear();
                    _logger.Log("Time taken to respond: " + (Environment.TickCount - startTime), 0);

                    // Obsolete sorting code
                    #region 
                    /*
                    // Create a counter integer to store the iterations
                    int counter = 0;
                    // 
                    List<DateTime> files = new List<DateTime>();

                    // Sort files
                    foreach (string indPost in posts)
                    {
                        // 
                        DateTime result = new DateTime();
                        DateTime.TryParse(indPost.Substring(0, indPost.Length - 5), out result);
                        files.Add(result);
                        // files.Sort((a, b) => b.CompareTo(a));
                    }
                    files.Sort((a, b) => b.CompareTo(a));
                    */
                    #endregion 
                //}
            }
            catch (Exception e) // in case of unexpected error
            {
                _logger.Log(e.ToString(), 2);
            }
        }

        /// <summary>
        /// Edit the club info.
        /// </summary>
        /// <param name="id">The ID of an existing club.</param>
        /// <param name="name">The new name of the club.</param>
        /// <param name="location">The new location of the club.</param>
        /// <param name="organizer">The new organizer of the club.</param>
        /// <param name="description">The new description of the club.</param>
        private void EditClubData(string id, string name, string location, string organizer, string description)
        {
            try // attempt to edit the club data with the given ID
            {
                // Loop through all the clubs in the list
                for(int i=0; i<_variables.Clubs.Count; i++)
                {
                    // If the club in the current iteration of the loop's ID matches the ID from the request
                    if (_variables.Clubs[i].ID == id.Trim())
                    {
                        // Update the club information for the matched specified club
                        _variables.Clubs[i].Name = name;
                        _variables.Clubs[i].Location = location;
                        _variables.Clubs[i].Supervisor = organizer;
                        _variables.Clubs[i].Description = description;
                        // Break out of the foreach loop
                        break;
                    }
                }
                //record the club information in the file
                using (StreamWriter sw = new StreamWriter(_variables.ServerDirectory + "/clubs/ListOfClubs.txt"))
                {
                    //loop through all the clubs in the list
                    for (int i = 0; i < _variables.Clubs.Count; i++)
                    {
                        //update the file with new information
                        sw.WriteLine("[|" + _variables.Clubs[i].ID + "|" + _variables.Clubs[i].Name + "|" + _variables.Clubs[i].Location + "|" + _variables.Clubs[i].Supervisor + "|" + _variables.Clubs[i].Description + "|]");
                    }
                }
            }
            catch (Exception e) // in case of unexpected error
            {
                _logger.Log(e.ToString(), 2);
            }
        }
    }
}
