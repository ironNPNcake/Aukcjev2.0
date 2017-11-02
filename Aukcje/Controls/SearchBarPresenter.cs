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
            return $"product={View.SearchedItem}&category={(int)View.FilterCategory}";
        }
    }
}