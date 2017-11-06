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
            IEnumerable<Auction> list = new List<Auction>();

            using (var ctx = new bazaEntities())
            {
                list = ctx.Auctions.ToList();
                list = list.Where(p => p.ID == Convert.ToInt32(HttpContext.Current.Request.QueryString["ID"]));
            }
            foreach (Auction auction in list)
            {
                auction.Price = CurrencyConverter.ConvertMoney(auction.Price);
            }
            return list;
        }

        public void AddToFavourites()
        {
            aspnet_Membership Users;
            string UserName = View.UserName;
            try
            {
                using (var ctx = new bazaEntities())
                {
                    Users = (from _User in ctx.aspnet_Users
                             join tempUser in ctx.aspnet_Membership
                             on _User.UserId equals tempUser.UserId
                             where _User.UserName == UserName
                             select tempUser).First();
                    string fav = Users.FavouritesItems;
                    if(string.IsNullOrEmpty(fav)|| fav.IndexOf(View.Id.ToString()+'|') < 0)
                    {
                        fav += $"{View.Id.ToString()}|";
                    }
                    Users.FavouritesItems = fav;
                    ctx.SaveChanges();
                }
                CheckFavourites();
            }
            catch
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write("Something Went Wrong Try Again Later");
                HttpContext.Current.Response.End();
                HttpContext.Current.Response.Flush();
            }
        }

        public void CheckFavourites()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                aspnet_Membership Users;
                string UserName = View.UserName;
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
                if (fav.IndexOf(View.Id.ToString() + '|') > -1)
                {
                    //View.LabelAddToFavourites.Text = "Already added to Favourites";
                    View.ImageButtonAddToFavourites.ImageUrl = "~/Pictures/fill.jpg";
                    View.ImageButtonAddToFavourites.Enabled = false;
                }
            }
        }
    }
}