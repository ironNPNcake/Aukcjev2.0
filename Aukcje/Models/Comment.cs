using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje.Models
{
    public class CommentWithAuction
    {
        public Aukcje.Comment Comment { get; set; }
        public Auction aukcja { get; set; }
        public string ConsumerName { get; set; }
    }
}