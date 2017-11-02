using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class YourAuctions : BaseView4Control<YourAuctionsPresenter>, IYourAuctionsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IEnumerable Select()
        {
            AttachPresenter();
            return Presenter.ShowHisAuctions();
        }


        protected void Auction_OnClick(object sender, CommandEventArgs e)
        {
            HttpContext.Current.Response.Redirect(String.Format("~/SingleAuction.aspx?ID={0}", e.CommandArgument));
        }

        public void Update(Aukcje.Auction objAuction)
        {
            AttachPresenter();
            Presenter.UpdateAuction(objAuction, ImageBytes);
        }


        protected void BtnDelete_OnCommandOnClick(object sender, CommandEventArgs e)
        {
            AttachPresenter();
            Presenter.DeleteAuctoin(e);
        }

        protected void ListViewAuctions_OnItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            FileUpload fUpld = ListViewAuctions.Items[e.ItemIndex].FindControl("FileUploadUpdate") as FileUpload;
            if (fUpld.HasFile)
            {
                ImageBytes = fUpld.FileBytes;
            }
            else
            {
                ImageBytes = null;
            }
        }

        public string loggedUser
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public ListView ListView
        {
            get { return ListViewAuctions; }
        }

        public byte[] ImageBytes { get; set; }
    }
}