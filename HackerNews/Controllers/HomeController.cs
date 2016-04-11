
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using HackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackerNews.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index(string slug)
        {
            Manager m = new Manager();
            var allLinks = m.GetAllLinks();
            
            return View(allLinks);
        }
        [Route("User/{id}")]
        public ActionResult Users(int id)
        {
            Manager m = new Manager();
            var allLinksForUser = m.GetAllLinksByUser(id);

            return View(allLinksForUser);
        }
        [Authorize]
        public ActionResult AddLink()
        {
            Manager m = new Manager();
            var name = User.Identity.Name;
            var user = m.GetUserId(name);
            var id = user.Id;
            return View(id);
        }
        [HttpPost]
        public ActionResult AddLink(string title, string url, int id)
        {
            Manager m = new Manager();
            Link l = new Link ();
            l.Title = title;
            l.Url = url;;
            l.UserId = id;
            m.AddLink(l);

            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult UpVote(int linkId)
        {
            Manager m = new Manager();
            var name = User.Identity.Name;
            var user = m.GetUserId(name);
            UpVote uv = new UpVote();
            uv.UserId = user.Id;
            uv.LinkId = linkId;
            var Upvotes = m.GetUpvotes();
            
            bool notUnique = Upvotes.Any(i => i.UserId == uv.UserId && i.LinkId == uv.LinkId);
            if (!notUnique)
            {
                m.AddUpVote(uv);
            }
            
            int upvoteAmount = m.GetUpvoteAmount(linkId);
            UpvoteUnique u = new UpvoteUnique();
            u.UpvoteAmount = upvoteAmount;
            u.NotUnique = notUnique;
            return Json(u);
        }

        

        }
}
