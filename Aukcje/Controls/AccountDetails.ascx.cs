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
        public Image Image { get; set; }

        protected void UserPicture_DataBinding(object sender, EventArgs e)
        {
            Image = ListViewAccountDetails.Items[0].FindControl("UserPicture") as Image;
        }

        protected void UserPicture_Init(object sender, EventArgs e)
        {
         //   Image = ListViewAccountDetails.Items[0].FindControl("UserPicture") as Image;
        }
    }
}