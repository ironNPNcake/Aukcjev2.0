using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje.Controls
{
    public class AccountDetailsPresenter :BasePresenter4Control<AccountDetails>
    {
        public IEnumerable ShowUserDetails()
        { 
            string UName = View.UName;
            return UserRepo.GetUserWithRating(UName);
        }
        
        public void UpdatePicture()
        {
                View.Image.ImageUrl = String.Format("~/UserPictureHandler.ashx?UserName={0}", View.UName);
        }
    }
}