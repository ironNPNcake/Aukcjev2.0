using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class AccountDetails : BaseView4Control<AccountDetailsPresenter>, IAccountDetailsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }
        public IEnumerable SelectUser()
        {
            AttachPresenter();
            return Presenter.ShowUserDetails();
        }

        public string UName
        {
            get
            {
                if (String.IsNullOrEmpty(HttpContext.Current.Request.QueryString["UID"]))
                    return HttpContext.Current.User.Identity.Name;
                return HttpContext.Current.Request.QueryString["UID"];
            }
        }
        public Image Image
        {
            get
            {
                return ListViewAccountDetails.Items[0].FindControl("UserPicture") as System.Web.UI.WebControls.Image;
            }
        }

        protected void ListViewAccountDetails_DataBound(object sender, EventArgs e)
        {
            AttachPresenter();
            Presenter.UpdatePicture();
        }
    }
}