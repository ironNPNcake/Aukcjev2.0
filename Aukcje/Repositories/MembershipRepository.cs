using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class MembershipRepository
    {
        public void UpdateUserPicture(string UserName, byte[] PictureBytes)
        {
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
        }
        public void AddToFavourites(string UserName, int Id)
        {
            aspnet_Membership Users;
            using (var ctx = new bazaEntities())
            {
                Users = (from _User in ctx.aspnet_Users
                         join tempUser in ctx.aspnet_Membership
                         on _User.UserId equals tempUser.UserId
                         where _User.UserName == UserName
                         select tempUser).First();
                string fav = Users.FavouritesItems;
                if (string.IsNullOrEmpty(fav) || fav.IndexOf(Id.ToString() + '|') < 0)
                {
                    fav += $"{Id.ToString()}|";
                }
                Users.FavouritesItems = fav;
                ctx.SaveChanges();
            }
        }
        public string ReturnFavouritesString(string UserName)
        {
            aspnet_Membership Users;
            string fav;
            using (var ctx = new bazaEntities())
            {
                Users = (from _User in ctx.aspnet_Users
                         join tempUser in ctx.aspnet_Membership
                         on _User.UserId equals tempUser.UserId
                         where _User.UserName == UserName
                         select tempUser).First();
                fav = Users.FavouritesItems;
            }
            return fav;
        }
        public byte[] GetUserImageBytes(string loggedUserName)
        {
            byte[] binary;
            using (var ctx = new bazaEntities())
            {
                binary = (from userM in ctx.aspnet_Membership
                          join userU in ctx.aspnet_Users
                          on userM.UserId equals userU.UserId
                          where userU.UserName == loggedUserName
                          select userM.Image).FirstOrDefault();
            }
            return binary;
        }
    }
}