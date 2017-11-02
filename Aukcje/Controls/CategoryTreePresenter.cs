using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public class CategoryTreePresenter : BasePresenter4Control<CategoryTree>
    {
        public void UpdateTree()
        {
            if (View.Menu.Items.Count > 1)
                View.Menu.Items.RemoveAt(1);


            string categoryString = View.queryString["category"];
            if (!String.IsNullOrEmpty(categoryString))
            {
                string CategoryRes;
                switch (categoryString)
                {
                    case "0":
                        CategoryRes = Resources.Resource.Electronics;
                        break;
                    case "1":
                        CategoryRes = Resources.Resource.Clothes;
                        break;
                    case "2":
                        CategoryRes = Resources.Resource.HomeAndGarden;
                        break;
                    default:
                        CategoryRes = Resources.Resource.AllCategories;
                        break;

                }

                View.Menu.Items.Add(new System.Web.UI.WebControls.MenuItem(CategoryRes, "0", null, $"~/AuctionsList.aspx?category={categoryString}"));

            }
        }
        public void UpdateTree(MenuEventArgs e)
        {
            UpdateTree();

        }
    }
}