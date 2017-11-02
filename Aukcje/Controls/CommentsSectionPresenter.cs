using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aukcje.Models;

namespace Aukcje.Controls
{
    public class CommentsSectionPresenter : BasePresenter4Control<CommentsSection>
    {
        public IEnumerable<Aukcje.Models.CommentWithAuction> SelectComments()
        {
            IEnumerable<Aukcje.Models.CommentWithAuction> list = new List<CommentWithAuction>();
            IEnumerable<Aukcje.Auction> Auctions;
            IEnumerable<Aukcje.Comment> Comments;
            using (var ctx = new bazaEntities())
            {
                Auctions = ctx.Auctions.ToList();
                Comments = ctx.Comments.ToList();
            }
            string sellerName = HttpContext.Current.Request.QueryString["UID"]??View.UName;

            Auctions = Auctions.Where(p => p.seller.Equals(sellerName) && p.status == "zakonczone");

            list = from p in Auctions
                join c in Comments
                on p.commentID equals c.CommentID
                select new CommentWithAuction() { aukcja = p, Comment = c, ConsumerName = "asd" };

            return list;
        }
    }
}