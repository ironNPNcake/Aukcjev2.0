using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class UserPictureMin : BaseView4Control<UserPictureMinPresenter>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AttachPresenter();
                Presenter.UpdatePicture();
            }
        }
        public Image UserPictureProp
        {
            get { return UserPicture; }
        }
    }
}