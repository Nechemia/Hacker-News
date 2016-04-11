using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackerNews.Models
{
    public class UpvoteUnique
    {
        public int UpvoteAmount { get; set; }
        public bool NotUnique { get; set; }
    }
}