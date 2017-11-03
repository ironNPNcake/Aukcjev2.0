using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aukcje
{
    public class InsertNewItemPresenter : BasePresenter<InsertNewItem>
    {
        private void ClearLabels()
        {
            View.ControlLabel.Text = "";
            View.AuctionCategoryType = 0;
            View.AuctionColor = 0;
            View.AuctionDescrition = "";
            View.AuctionPrice = 0;
            View.AuctionName = "";
        }

        public void AddNewItem()
        {
            try
            {
                Auction currentItem = new Auction()
                {
                    Title = View.AuctionName,
                    //Category = (int)View.AuctionCategoryType,     //this is useful validator if User want to add item that category is not added but now when Categories are added dynamically it is useless
                    Category = View.AuctionCategoryTypeInt,
                    Color = View.AuctionColorInt,
                    Description = View.AuctionDescrition,
                    Price = View.AuctionPrice,
                    seller = System.Web.Security.Membership.GetUser().UserName,
                    status = "otwarte",
                    Image = View.AuctionImageBytes
                };
                using (var ctx = new bazaEntities())
                {
                    ctx.Auctions.Add(currentItem);
                    ctx.SaveChanges();
                }
            }
            catch
            {
                View.ControlLabel.Visible = true;

                View.ControlLabel.Text = "Somenthing went wrong try again lter";
                View.ControlLabel.Font.Size = 32;
            }
            ClearLabels();

            View.ControlLabel.Text = "Congrats! Your Item was succesfully added";
            View.ControlLabel.Font.Size = 32;
        }
        public IEnumerable<string> ReturnCategories2DDList()
        {
            List<string> list = Filters.ReturnCategoriesList().Select(p => p.CategoryResourceName).ToList<string>();

            return list;
        }
    }
}