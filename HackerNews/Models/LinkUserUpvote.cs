using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackerNews.Models
{
    public class LinkUserUpvote
    {
        public List<User> Users {get;set;}
        public List<UpVote> Upvotes { get; set; }
        public List<Link> Links { get; set; }
    }
}