using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public class YourAuctionsPresenter : BasePresenter4Control<YourAuctions>
    {
        public IEnumerable ShowHisAuctions()
        {
            IEnumerable<Aukcje.Auction> list;
            string user = View.loggedUser;
            using (var ctx = new bazaEntities())
            {
                list = from auction in ctx.Auctions
                       join _user in ctx.aspnet_Users
                       on auction.seller equals _user.UserName
                       where (_user.UserName == user)
                       select auction;
                list = list.ToList();
            }
            foreach (Auction auction in list)
            {
                auction.Price = CurrencyConverter.ConvertMoney(auction.Price);
            }
            return list;
        }

        public void UpdateAuction(Aukcje.Auction objAuction, byte[] bytes)
        {
            int a = objAuction.ID;
            using (var ctx = new bazaEntities())
            {
                var updatedauction = ctx.Auctions.FirstOrDefault(p => p.ID == a);
                updatedauction.Title = objAuction.Title;
                updatedauction.Description = objAuction.Description;
                updatedauction.Price = objAuction.Price;
                if (View.ImageBytes != null)
                {
                    updatedauction.Image = View.ImageBytes;
                }

                ctx.SaveChanges();
            }
        }

        public void DeleteAuctoin(CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            using (var ctx = new bazaEntities())
            {
                var obj = ctx.Auctions.SingleOrDefault(p => p.ID == id);
                ctx.Auctions.Remove(obj);
                ctx.SaveChanges();
            }
            View.ListView.EditIndex = -1;
            View.ListView.DataBind();
        }

    }

}