using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class SingleAuctionPresenter : BasePresenter<SingleAuction>
    {
        public IEnumerable<Aukcje.Auction> SelectItems()
        {
            IEnumerable<Auction> list = AuctionRepo.GetAuctionById(Convert.ToInt32(HttpContext.Current.Request.QueryString["ID"]));
            foreach (Auction auction in list)
            {
                auction.Price = CurrencyConverter.ConvertMoney(auction.Price);
            }
            return list;
        }

        public void AddToFavourites()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                string UserName = View.UserName;
                MembershipRepo.AddToFavourites(UserName, View.Id);
                CheckFavourites();
            }
            else
            {
                View.LabelAddToFavourites.Text = "You must be logged in to add auctions to favourites";
            }
        }

        public void CheckFavourites()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string UserName = View.UserName;
                string fav = MembershipRepo.ReturnFavouritesString(UserName) ;
                
                if (fav.IndexOf(View.Id.ToString() + '|') > -1)
                {
                    View.LabelAddToFavourites.Text = "Already added to Favourites";
                    View.ImageButtonAddToFavourites.ImageUrl = "~/Pictures/fill.png";
                    View.ImageButtonAddToFavourites.Enabled = false;
                }
            }
        }
    }
}