using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JohnsBlog.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;

namespace JohnsBlog.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page, string searchStr)
        {
            ViewBag.Search = searchStr;
            var blogList = IndexSearch(searchStr);

            int pageSize = 2; // display three blog posts at a time on this page
            int pageNumber = (page ?? 1);

            return View(blogList.ToPagedList(pageNumber, pageSize));
        }

        public IQueryable<BlogPost> IndexSearch(string searchStr)
        {
            IQueryable<BlogPost> result = null;
            if (searchStr != null)
            {
                result = db.BlogPosts.AsQueryable();
                result = result.Where(p => p.Title.Contains(searchStr) ||
                                    p.Body.Contains(searchStr) ||
                                    p.Comments.Any(c => c.CommentBody.Contains(searchStr) ||
                                                    c.Author.FirstName.Contains(searchStr) ||
                                                    c.Author.LastName.Contains(searchStr) ||
                                                    c.Author.DisplayName.Contains(searchStr) ||
                                                    c.Author.Email.Contains(searchStr)));
            }
            else
            {
                result = db.BlogPosts.AsQueryable();
            }
            return result.OrderByDescending(p => p.Created);
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            var model = new EmailModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var standardBodyMessage = $"<h3>You have received an email from {model.FromEmail}</h3>";
                    standardBodyMessage += $"<br /> {model.Body}";

                    var from = "JohnBlog<jc56wrestling@yahoo.com>";
                    var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = model.Subject,
                        Body = $"{standardBodyMessage}",
                        IsBodyHtml = true
                    };
                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);
                    return RedirectToAction("Index", "BlogPosts");
                    //return View(new EmailModel());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);

        }

       

    }
}