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
            string favIds = MembershipRepo.ReturnFavouritesString(user);
            if (!string.IsNullOrEmpty(favIds))
            {
                List<string> favIdsArray = favIds.Split(new char[] { '|' }).ToList<string>();
                favIdsArray.Sort();
                favIdsArray.RemoveAt(0);
                List<int> favIdsArrayInt = new List<int>(favIdsArray.Select(int.Parse));

                list = AuctionRepo.GetAuctions();
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

                //stat = HttpContext.GetGlobalResourceObject("Resource", stat).ToString();
                if (!string.IsNullOrEmpty(stat))
                    auc.status = stat;
            }
            return OutterList;

        }


        
    }
}