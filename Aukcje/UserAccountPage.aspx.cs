using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje
{
    public partial class UserAccountPage : BaseView<UserAccountPagePresenter>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Request.IsAuthenticated)
                Page.Response.Redirect("Default.aspx");
            if(!Page.IsPostBack)
            {
                //AccountDetails.Image.ImageUrl = "~/Pictures/Auction01.jpg";
            }
        }

        protected void showChangeProfilePicture_Click(object sender, EventArgs e)
        {
            AttachPresenter();
            Presenter.ShowChangeProfilePicture();
        }
        public Button ButtonShowChangeProfileProp { get { return changeProfilePictureShow; } }
        public Button ButtonChangeProfilePictureProp { get { return ButtonProfilePicture; } }
        public FileUpload FileUploadProfilePictureProp { get { return FileUploadProfilePicture; } }

        protected void changeProfilePicture_Click(object sender, EventArgs e)
        {
            AttachPresenter();
            Presenter.ChangeProfilePicture();
        }
    }
}