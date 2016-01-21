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


namespace Compsci12ISUServer
{
    class Post
    {
        //stores the content and club ID of the post, as well as the file name
        private string _fileName;
        private string _content;
        private string _id;

        /// <summary>
        /// Creates a message with passed in values
        /// </summary>
        public Post(string fileName, string clubID, string content)
        {
            //set each variables to the values the user passed in
            FileName = fileName;
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
        /// <summary>
        /// Gets or sets the club ID of the post
        /// </summary>
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

        /// <summary>
        /// Gets or sets the file name of the post as it's stored
        /// </summary>
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }
    }
}