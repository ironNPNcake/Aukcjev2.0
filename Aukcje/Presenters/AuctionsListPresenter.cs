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
            if((int)View.FilterCategory>0)
            list = list.Where(p => p.Category == (int)View.FilterCategory);
            //     ((Aukcje.Site)this.Page.Master).changeValueInDropDowCategoryList((int)category);

            if (!String.IsNullOrEmpty(View.SearchedItem))
            {
                list = list.Where(p => (p.Title.IndexOf(View.SearchedItem, StringComparison.OrdinalIgnoreCase) >= 0));
                //     ((Aukcje.Site)this.Page.Master).changeValueInTextSearchBar(SearchedItem);
            }


            list = list.Where(p => p.Price >= View.FilterLowPrice && p.Price <= View.FilterHighPrice);
            //color filtering

            List<Auction> tempList = new List<Auction>();
            if (View.FilterColorCheckBoxList.SelectedIndex > -1)
            {
                foreach (ListItem listItem in View.FilterColorCheckBoxList.Items)
                {
                    if (listItem.Selected)
                    {
                        tempList.AddRange(list.Where(p => p.Color == Convert.ToInt32(listItem.Value)).ToList());
                    }
                }
                list = tempList;
            }
            //brand filtering

            tempList = new List<Auction>();
            if(View.FilterBrandsCheckBoxList.SelectedIndex > -1)
            {
                foreach (ListItem listItem in View.FilterBrandsCheckBoxList.Items)
                {
                    if (listItem.Selected)
                        tempList.AddRange(list.Where(p => p.Brand == Convert.ToString(listItem.Text)).ToList());
                }
                list = tempList;
            }


            foreach (Auction auction in list)
            {
                auction.Price = CurrencyConverter.ConvertMoney(auction.Price);
            }
            return list;
        }

    }
}