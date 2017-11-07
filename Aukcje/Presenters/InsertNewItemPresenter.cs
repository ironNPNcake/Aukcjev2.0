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
                string _Brand;
                if (View.DropDownDownListBrand.Visible)
                    _Brand = View.TxtBoxInsertNewBrandProp.Text;
                else
                    _Brand = View.DropDownDownListBrand.SelectedItem.Text;
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
                    Brand = _Brand,
                    Image = View.AuctionImageBytes
                };
                if(View.TxtBoxInsertNewColorProp.Visible)
                {
                    FiltersTable newColor = new FiltersTable()
                    {
                        FilterResourceName = View.TxtBoxInsertNewColorProp.Text
                    };
                    ColorRepo.AddColor(newColor);
                }
                AuctionRepo.AddAuctions(currentItem);
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
        public void CheckIfNewBrand()
        {
            if (View.DropDownDownListBrand.SelectedIndex == View.DropDownDownListBrand.Items.Count - 1)
            {
                View.TxtBoxInsertNewBrandProp.Visible = true;
            }
            else
                View.TxtBoxInsertNewBrandProp.Visible = false;

        }
        public void CheckIfNewColor()
        {
            if (View.DropDownListColor.SelectedIndex == View.DropDownListColor.Items.Count - 1)
                View.TxtBoxInsertNewColorProp.Visible = true;
            else
                View.TxtBoxInsertNewColorProp.Visible = false;
        }
        public IEnumerable<string> SelectBrands()
        {
            List<string> list = new List<string>();

            list = Filters.ReturnBrandsList(View.AuctionCategoryTypeInt);

            list.Add("+Add new Brand");
            return list;
        }
        public IEnumerable<FiltersTable> SelectFiltersColors()
        {
            List<FiltersTable> list = Filters.ReturnFiltersList().ToList();
            list.Add(new FiltersTable { FilterResourceName = "+Add New Color" });
            return list;
        }
    }
}