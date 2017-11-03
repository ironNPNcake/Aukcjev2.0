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
            View.Menu.Items.Clear();
            View.Menu.Items.Add(RootMenu());
            string categoryString = View.queryString["category"];
            int CategoryInt = Convert.ToInt32(categoryString);
            if (!String.IsNullOrEmpty(categoryString))
            {
                string CategoryRes = Filters.TryFindCategoryResource(CategoryInt);
                View.Menu.Items.Add(new System.Web.UI.WebControls.MenuItem(CategoryRes, "0", null, $"~/AuctionsList.aspx?category={categoryString}"));
            }
        }
        public void UpdateTree(MenuEventArgs e)
        {
            UpdateTree();

        }
        private MenuItem RootMenu()
        {
            string cat = HttpContext.GetGlobalResourceObject("Resource", "Categories").ToString();
            MenuItem root = new MenuItem(cat);
            List<MenuItem> kids = new List<MenuItem>();
            List<CategoriesTable> list;
            using (var ctx = new bazaEntities())
            {
                list = ctx.CategoriesTables.ToList();
            }
            foreach (CategoriesTable catTable in list)
            {
                string resCategory = Filters.TryFindCategoryResource(catTable.ID);
                MenuItem temp = new MenuItem(resCategory, "0", null, $"~/AuctionsList.aspx?category={catTable.ID}");
                root.ChildItems.Add(temp);
            }
            return root;
        }
    }
}