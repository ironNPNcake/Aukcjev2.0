using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aukcje.Models;

namespace Aukcje.Controls
{
    public partial class CommentsSection : BaseView4Control<CommentsSectionPresenter>, ICommentsSectionView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<Aukcje.Models.CommentWithAuction> SelectComment()
        {
            AttachPresenter();
            return Presenter.SelectComments();
        }

        public string UName
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
    }
}