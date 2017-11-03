using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class FiltersCheckBoxes : BaseView4Control<FiltersCheckBoxesPresenter>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AttachPresenter();
            Presenter.UpdateColors();
        }
        public CheckBoxList FilterColorCheckBoxList
        {
            get { return checkBoxFilteringSet; }
            set { checkBoxFilteringSet = value; }
        }
    }
}