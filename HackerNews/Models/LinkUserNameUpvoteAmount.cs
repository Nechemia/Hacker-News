using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackerNews.Models
{
    public class LinkUserNameUpvoteAmount
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public int AmountOfUpvotes { get; set; }

    }
}