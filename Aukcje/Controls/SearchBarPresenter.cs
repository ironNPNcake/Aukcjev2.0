using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje.Controls
{
    public class SearchBarPresenter : BasePresenter4Control<SearchBar>
    {
        public string QueryString()
        {
            if((int)View.FilterCategory>0)
             return $"product={View.SearchedItem}&category={(int)View.FilterCategory}";
            return $"product={View.SearchedItem}";
        }
        public IEnumerable<string> SelectCategories()
        {
            List<string> list = new List<string> { "All Categories" };
             list.AddRange(Filters.ReturnCategoriesList().Select(p => p.CategoryResourceName).ToList<string>());

            return list;
        }
    }
}