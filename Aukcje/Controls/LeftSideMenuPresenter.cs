using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public class LeftSideMenuPresenter : BasePresenter4Control<LeftSideMenu>
    {
        public List<Aukcje.CategoriesTable> ReturnCategoriesName()
        {
            return Filters.ReturnCategoriesList();
        }

    }
}