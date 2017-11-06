using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje.Controls
{
    public class FavouritesListPresenter : BasePresenter4Control<FavouritesList>
    {
        public IEnumerable<Auction> GetFavAuctions()
        {
            List<Auction> list;
            List<Auction> OutterList = new List<Auction>();

            string user = View.loggedUser;
            string favIds;

            using (var ctx = new bazaEntities())
            {
                favIds = (from searchedUser in ctx.aspnet_Users
                          join _user in ctx.aspnet_Membership
                          on searchedUser.UserId equals _user.UserId
                          where searchedUser.UserName == user
                          select _user.FavouritesItems).FirstOrDefault();
            }
            if (!string.IsNullOrEmpty(favIds))
            {
                List<string> favIdsArray = favIds.Split(new char[] { '|' }).ToList<string>();
                favIdsArray.Sort();
                favIdsArray.RemoveAt(0);
                List<int> favIdsArrayInt = new List<int>(favIdsArray.Select(int.Parse));

                using (var ctx = new bazaEntities())
                {
                    list = ctx.Auctions.ToList();
                }
                favIdsArrayInt.Sort();
              //  favIdsArrayInt.RemoveAt(0);
                favIdsArray = favIdsArrayInt.Select(p => p.ToString()).ToList();
                foreach (Auction _auc in list)
                {
                    if (Convert.ToString(_auc.ID) == favIdsArray.FirstOrDefault())
                    {
                        OutterList.Add(list.Where(p => p.ID == Convert.ToInt32(favIdsArray.First())).First());
                        favIdsArray.Remove(favIdsArray.First());
                    }
                }
            }

            foreach (Auction auc in OutterList)
            {
                string stat = auc.status;

                stat = HttpContext.GetGlobalResourceObject("Resource", stat).ToString();
                if (!string.IsNullOrEmpty(stat))
                    auc.status = stat;
            }
            return OutterList;

        }


        
    }
}