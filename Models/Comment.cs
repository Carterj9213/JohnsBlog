using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohnsBlog.Models
{
    public class Comment
    {
        //Primary key
        public int Id { get; set; }

        //Foreign key
        public int BlogPostId { get; set; }
        public string AuthorId { get; set; }

        public string CommentBody { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public string UpdateReason { get; set; }

        //Navigational properties
        public virtual BlogPost BlogPost { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}