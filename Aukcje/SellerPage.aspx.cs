using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aukcje.Models;

namespace Aukcje
{
    public partial class SellerPage : BaseView<SellerPagePresenter>, ISellerPageView
    {
        // UID is User name
        protected void Page_Load(object sender, EventArgs e)
        {
            AttachPresenter();
            if (Presenter.ThisIsTheLoggedUser())
            {
                Page.Response.Redirect($"UserAccountPage.aspx?UID={HttpContext.Current.Request.QueryString["UID"]}");
            }
        }

       
        public string queryStringUID
        {
            get { return HttpContext.Current.Request.QueryString["UID"]; }
        }
    }
}