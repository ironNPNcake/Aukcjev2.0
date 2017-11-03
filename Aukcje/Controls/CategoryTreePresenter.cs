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
            Menu newMenu = new Menu();
            MenuItem root = new MenuItem("Categories");
            newMenu.Items.Add(root);
            if (View.Menu.Items.Count > 1)
                View.Menu.Items.RemoveAt(1);


            string categoryString = View.queryString["category"];
            int CategoryInt = Convert.ToInt32(categoryString);
            if (!String.IsNullOrEmpty(categoryString))
            {
                string CategoryRes = Filters.TryFindCategoryResource(CategoryInt);
                View.Menu.Items.Add(new System.Web.UI.WebControls.MenuItem(CategoryRes, "0", null, $"~/AuctionsList.aspx?category={categoryString}"));
            }
            View.Menu = newMenu;
        }
        public void UpdateTree(MenuEventArgs e)
        {
            UpdateTree();

        }
    }
}