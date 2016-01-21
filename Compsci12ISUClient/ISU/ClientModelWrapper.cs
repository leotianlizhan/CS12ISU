/*
Tianli Zhan
Jan 13, 2016
Class that acts as a wrapper for all the subprograms from other programmer's models
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    class ClientModelWrapper
    {
        //stores the sharedvariables and each model
        SharedVariables _variables = new SharedVariables();
        TianliModel _tianliModel;
        AndrewModel _andrewModel;

        public ClientModelWrapper()
        {
            //initialize each model
            _tianliModel = new TianliModel(this, _variables);
            _andrewModel = new AndrewModel(this, _variables); 
        }

        /// <summary>
        /// Updates the client with possibly new posts
        /// </summary>
        /// <param name="amount">How many posts you want</param>
        /// <returns>True if updated successfully</returns>
        public bool UpdatePosts(int amount)
        {
            return _tianliModel.UpdatePosts(amount);
        }

        /// <summary>
        /// Updates the list of clubs
        /// </summary>
        /// <returns>True if successful</returns>
        public bool UpdateClubs()
        {
            return _tianliModel.UpdateClubs();
        }

        /// <summary>
        /// Login the admin
        /// </summary>
        /// <param name="username">Username for the admin</param>
        /// <param name="password">Password for the admin</param>
        /// <returns>True if successful</returns>
        public bool Login(string username, string password)
        {
            return _tianliModel.Login(username, password);
        }

        /// <summary>
        /// Publishes a new post
        /// </summary>
        /// <param name="id">ID of the club</param>
        /// <param name="content">Content you want to publish</param>
        /// <returns>True if request sent successfully</returns>
        public bool PublishPost(string id, string content)
        {
            return _tianliModel.PublishPost(id, content);
        }

        /// <summary>
        /// Filters the posts of only certain clubs
        /// </summary>
        /// <param name="clubs">Clubs that you want to filter</param>
        /// <returns>Filtered list of posts</returns>
        public List<Post> Filter(List<Club> clubs)
        {
            return _tianliModel.Filter(clubs);
        }

        /// <summary>
        /// Submit changes to the club's information, pass in the id and the new name, location, supervisor, and description
        /// </summary>
        /// <param name="id">id of the club</param>
        /// <param name="name">New Name</param>
        /// <param name="location">New Location</param>
        /// <param name="supervisor">New Supervisor</param>
        /// <param name="description">New Description</param>
        /// <returns>True if request submitted successfully</returns>
        public bool SubmitChanges(string id, string name, string location, string supervisor, string description)
        {
            return _tianliModel.SubmitChanges(id, name, location, supervisor, description);
        }

        /// <summary>
        /// Find a club based on its ID
        /// </summary>
        /// <param name="id">ID of the club to find</param>
        /// <returns>Club that was found</returns>
        public Club FindClub(string id)
        {
            return _tianliModel.FindClub(id);
        }

        /// <summary>
        /// Gets or sets the list of posts
        /// </summary>
        public List<Post> PostList
        {
            get
            {
                return _variables.PostList;
            }
            set
            {
                _variables.PostList = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of clubs
        /// </summary>
        public List<Club> ClubList
        {
            get
            {
                return _variables.ClubList;
            }
            set
            {
                _variables.ClubList = value;
            }
        }

        /// <summary>
        /// Gets or sets the club admin
        /// </summary>
        public ClubAdmin Admin
        {
            get
            {
                return _variables.Admin;
            }
            set
            {
                _variables.Admin = value;
            }
        }
    }
}
