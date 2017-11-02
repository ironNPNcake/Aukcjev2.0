using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class FavouritesList : BaseView4Control<FavouritesListPresenter>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Aukcje.Auction> LstVwFavouritesAuctions_GetData()
        {
            AttachPresenter();
            return Presenter.GetFavAuctions();
        }
        public string loggedUser
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
        protected void Auction_OnClick(object sender, CommandEventArgs e)
        {
            HttpContext.Current.Response.Redirect(String.Format("~/SingleAuction.aspx?ID={0}", e.CommandArgument));
        }



    }
}