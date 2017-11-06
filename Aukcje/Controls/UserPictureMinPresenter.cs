using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje.Controls
{
    public class UserPictureMinPresenter : BasePresenter4Control<UserPictureMin>
    {
        public void UpdatePicture()
        {
            View.UserPictureProp.ImageUrl = $"~/UserPictureHandler.ashx?LoggedUserName={HttpContext.Current.Request.LogonUserIdentity.Name}";
        }
    }
}