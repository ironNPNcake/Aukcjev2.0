using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public class BrandFilterPresenter :BasePresenter<BrandFilter>
    {
        public void UpdateBrands()
        {
            List<int> indexes = new List<int>();
            for(int i =0;i<View.CheckBoxBrandsList.Items.Count;i++)
            {
                if (View.CheckBoxBrandsList.Items[i].Selected)
                    indexes.Add(Convert.ToInt32(i));
            }
            View.CheckBoxBrandsList.DataBind();
            for (int i = View.CheckBoxBrandsList.Items.Count; i > 0; i--)
            {
                if (indexes.LastOrDefault() == i)
                {
                    View.CheckBoxBrandsList.Items[i - 1].Selected = true;
                    indexes.RemoveAt(indexes.Count - 1);
                }

            }
        }
        public IEnumerable<string> SelectBrands()
        {
            string catId = HttpContext.Current.Request.QueryString["category"];
            if(!string.IsNullOrEmpty(catId))
                return Filters.ReturnBrandsList(Convert.ToInt32(catId));
            return Filters.ReturnBrandsList();
        }
    }
}