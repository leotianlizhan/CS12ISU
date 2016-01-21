/*
Tianli Zhan
Jan 13, 2016
Class that defines posts, which are messages for users to see
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISU
{
    class Post
    {
        //stores the content and club ID of the post
        private string _content;
        private string _id;

        /// <summary>
        /// Creates a message with passed in values
        /// </summary>
        public Post(string clubID, string content)
        {
            //set each variables to the values the user passed in
            _id = clubID;
            Content = content;
        }
        /// <summary>
        /// Gets or sets the content of the post
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }
            private set
            {
                _content = value;
            }
        }
        public string ID
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
    }
}