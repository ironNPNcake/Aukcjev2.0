using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class BrandFilter : BaseView4Control<BrandFilterPresenter>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AttachPresenter();
            Presenter.UpdateBrands();
        }
        public CheckBoxList CheckBoxBrandsList
        {
            get { return checkBoxBrandsSet; }
            set { checkBoxBrandsSet = value; }
        }
        public IEnumerable<string> SelectBrands()
        {
            AttachPresenter();
            return Presenter.SelectBrands();
        }
    }
}