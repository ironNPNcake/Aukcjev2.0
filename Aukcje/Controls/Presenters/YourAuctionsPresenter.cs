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
            list = AuctionRepo.GetAuctionsByUser(user);
            foreach (Auction auction in list)
            {
                auction.Price = CurrencyConverter.ConvertMoney(auction.Price);
            }
            return list;
        }

        public void UpdateAuction(Aukcje.Auction objAuction)
        {
            AuctionRepo.UpdateAuction(objAuction, View.ImageBytes);
        }

        public void DeleteAuction(CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            AuctionRepo.DeleteAuction(id);
            View.ListView.EditIndex = -1;
            View.ListView.DataBind();
        }

    }

}