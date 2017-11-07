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
            string sellerName = HttpContext.Current.Request.QueryString["UID"]??View.UName;
            return AuctionRepo.GetClosedAuctions(sellerName);
        }
    }
}