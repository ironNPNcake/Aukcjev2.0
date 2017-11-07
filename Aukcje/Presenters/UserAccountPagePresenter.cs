using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class UserAccountPagePresenter : BasePresenter<UserAccountPage>
    {
        public void ChangeProfilePicture()
        {
            byte[] PictureBytes = View.FileUploadProfilePictureProp.FileBytes;
            string UserName = HttpContext.Current.User.Identity.Name;
            MembershipRepo.UpdateUserPicture(UserName, PictureBytes);

            View.ButtonShowChangeProfileProp.Visible = true;
            View.FileUploadProfilePictureProp.Visible = false;
            View.ButtonChangeProfilePictureProp.Visible = false;
        }
        public void ShowChangeProfilePicture()
        {
            View.ButtonShowChangeProfileProp.Visible = false;
            View.FileUploadProfilePictureProp.Visible = true;
            View.ButtonChangeProfilePictureProp.Visible = true;
        }
    }
}