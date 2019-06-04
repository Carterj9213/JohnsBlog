using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JohnsBlog.Models;

namespace JohnsBlog.Helpers
{
    public class CommentHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static List<Comment> RecentComments()
        {
            return db.Comments.OrderByDescending(c => c.Created).Take(5).ToList();
        }
    }
}