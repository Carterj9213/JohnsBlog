using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JohnsBlog.Models
{
    public class BlogPost
    {
        //Properties
        public int Id { get; set; }

        //[Display(Name =whatever title here)]
        //, ErrorMessage = "custom saying")
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        //
        public string Slug { get; set; }

        [AllowHtml]       
        public string Body { get; set; }
        public string Abstract { get; set; }
        public string MediaUrl { get; set; }

        public bool Published { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        //Virtuals used for navigation
        public virtual ICollection<Comment> Comments { get; set; }
        

        //Constructor Code (this. infront of comments = is optional)
        public BlogPost()
        {
            Comments = new HashSet<Comment>();
        }











    }
}