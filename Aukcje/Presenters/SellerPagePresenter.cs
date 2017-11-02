using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Aukcje
{
    public class SellerPagePresenter : BasePresenter<SellerPage>
    {

        public bool ThisIsTheLoggedUser()
        {
            string UID = View.queryStringUID;

            if (!string.IsNullOrEmpty(UID))
            {
                string name = HttpContext.Current.User.Identity.Name;
                if (name == UID)
                {
                    return true;
                }
            }

            return false;
        }
    }
}