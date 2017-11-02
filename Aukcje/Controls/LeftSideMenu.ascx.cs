using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class LeftSideMenu : BaseView4Control<LeftSideMenuPresenter>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListViewSideCategoriesMenu.DataBind();
        }
        public IEnumerable<Aukcje.CategoriesTable> OnSelectingCategories()
        {
            AttachPresenter();
            return Presenter.ReturnCategoriesName();
        }
    }
}