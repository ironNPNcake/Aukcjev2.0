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
            using (var ctx = new bazaEntities())
            {
                aspnet_Membership user = (from userU in ctx.aspnet_Users
                                          join userM in ctx.aspnet_Membership
                                          on userU.UserId equals userM.UserId
                                          where userU.UserName == UserName
                                          select userM).FirstOrDefault();
                user.Image = PictureBytes;
                ctx.SaveChanges();
            }
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