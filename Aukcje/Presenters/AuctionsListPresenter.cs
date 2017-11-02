using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aukcje
{
    public class AuctionsListPresenter : BasePresenter<AuctionsList>
    {

        public IEnumerable SelectAuctionsList()
        {
            IEnumerable<Auction> list;
            using (var ctx = new bazaEntities())
            {
                list = ctx.Auctions.ToList();
            }
            list = list.Where(p => p.status == "otwarte");
            //catgory filtering
                list = list.Where(p => p.Category == (int)View.FilterCategory);
                //     ((Aukcje.Site)this.Page.Master).changeValueInDropDowCategoryList((int)category);

            if (!String.IsNullOrEmpty(View.SearchedItem))
            {
                list = list.Where(p => (p.Title.IndexOf(View.SearchedItem, StringComparison.OrdinalIgnoreCase) >= 0));
                //     ((Aukcje.Site)this.Page.Master).changeValueInTextSearchBar(SearchedItem);
            }


            list = list.Where(p => p.Price >= View.FilterLowPrice && p.Price <= View.FilterHighPrice);
            //color filtering
            foreach (ListItem listItem in View.FilterColorCheckBoxList.Items)
            {
                if (listItem.Selected)
                {
                    list = list.Where(p =>
                        (View.FilterColorCheckBoxList.Items[0].Selected ? p.Color == 0 : false) ||
                        (View.FilterColorCheckBoxList.Items[1].Selected ? p.Color == 1 : false) ||
                        (View.FilterColorCheckBoxList.Items[2].Selected ? p.Color == 2 : false)
                    );
                    break;
                }
            }

            foreach (Auction auction in list)
            {
                auction.Price = CurrencyConverter.ConvertMoney(auction.Price);
            }
            return list;
        }

    }
}