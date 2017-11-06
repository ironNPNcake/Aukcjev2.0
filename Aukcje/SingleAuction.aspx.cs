using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje
{
    public partial class SingleAuction : BaseView<SingleAuctionPresenter>, ISingleAuctionView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                ListViewSingleAuction.DataBind();
        }

        public string UserName
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
        public int Id
        {
            get { return Convert.ToInt32(HttpContext.Current.Request.QueryString["ID"]); }
        }


        public IEnumerable<Auction> Select()
        {
            AttachPresenter();
            return Presenter.SelectItems();
        }
        protected void AddToFavourites_Click(object sender, ImageClickEventArgs e)
        {
            AttachPresenter();
            Presenter.AddToFavourites();
        }
        public ImageButton ImageButtonAddToFavourites
        {
            get { return ListViewSingleAuction.Items[0].FindControl("ImgBtnAddToFavourites") as ImageButton; }
        }
        public Label LabelAddToFavourites
        {
            get { return ListViewSingleAuction.Items[0].FindControl("lblAddedToFavourites") as Label; }
        }

        protected void ListViewSingleAuction_DataBound(object sender, EventArgs e)
        {
            AttachPresenter();
            Presenter.CheckFavourites();
        }
    }
}