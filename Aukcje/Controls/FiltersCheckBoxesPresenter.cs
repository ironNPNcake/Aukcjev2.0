using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public class FiltersCheckBoxesPresenter : BasePresenter4Control<FiltersCheckBoxes>
    {
        public void UpdateColors()
        {
            List<int> indexes = new List<int>();
            foreach (ListItem i in View.FilterColorCheckBoxList.Items)
            {
                if (i.Selected)
                    indexes.Add(Convert.ToInt32(i.Value));
            }
            View.FilterColorCheckBoxList.DataBind();
            for (int i = View.FilterColorCheckBoxList.Items.Count; i > 0; i--)
            {

                if (indexes.LastOrDefault() == i)
                {
                    View.FilterColorCheckBoxList.Items[i - 1].Selected = true;
                    indexes.RemoveAt(indexes.Count - 1);
                }

            }
        }

    }

}