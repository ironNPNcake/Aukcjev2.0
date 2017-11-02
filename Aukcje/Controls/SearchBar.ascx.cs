using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public partial class SearchBar : BaseView4Control<SearchBarPresenter>, ISearchBarView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonSearch_OnClick(object sender, ImageClickEventArgs e)
        {

            string product = "product=" + textSearchBar.Text;

            //  Response.Redirect(String.Format("~/AuctionsList.aspx?{0}&{1}",category,product));
            HttpContext.Current.Response.Redirect(String.Format("~/AuctionsList.aspx?{0}", queryString));
        }


        public void changeValueInTextSearchBar(string _text)
        {
            textSearchBar.Text = _text;
        }

        public void changeValueInDropDowCategoryList(int index)
        {
            DropDownCategories.SelectedIndex = index;
        }


        public Models.Categories FilterCategory
        {
            get { return (Models.Categories)DropDownCategories.SelectedIndex; }
            set { DropDownCategories.SelectedIndex = (int)value; }
        }

        public string SearchedItem
        {
            get { return textSearchBar.Text; }
            set { textSearchBar.Text = value; }
        }
        public string queryString
        {
            get
            {
                AttachPresenter();
                return Presenter.QueryString();
            }
        }
    }
}