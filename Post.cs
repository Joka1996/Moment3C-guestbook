using System;
using System.Collections.Generic;
using System.Text;

namespace Moment3
{
   public class Post : Object
    {
        //properties
        public string Author { get; set; }
        public string Content { get; set; }
        public List<Post> GuestBook = new List<Post>();
        //constructor
       /* public Post(int id, string author, string content)
        {
            this.Id = id;
            this.Author = author;
            this.Content = content;
        }*/
    }
}
