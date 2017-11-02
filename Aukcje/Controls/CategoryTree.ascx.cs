using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class CategoryTree : BaseView4Control<CategoryTreePresenter>, ICategoryTreeView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                AttachPresenter();
                Presenter.UpdateTree();
            }

        }
        public System.Collections.Specialized.NameValueCollection queryString
        {
            get
            {
                return HttpContext.Current.Request.QueryString;
            }
        }
        public Menu Menu
        {
            get
            {
                return Menu1;
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            AttachPresenter();
            Presenter.UpdateTree(e);
        }
    }
}