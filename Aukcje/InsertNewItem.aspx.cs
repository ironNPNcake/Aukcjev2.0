using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aukcje.Models;
using Label = System.Reflection.Emit.Label;

namespace Aukcje
{
    public partial class InsertNewItem : BaseView<InsertNewItemPresenter>, IInsertNewItemView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
                Response.Redirect(String.Format("Membership/Login.aspx?rdrect={0}",HttpContext.Current.Request.Url.AbsolutePath));
        }

        protected void InsertButton_OnClick(object sender, EventArgs e)
        {
            AttachPresenter();
            Presenter.AddNewItem();
        }

        public string AuctionName
        {
            get { return textAuctionName.Text; }
            set { textAuctionName.Text = value; }
        }

        public decimal AuctionPrice
        {
            get { return Convert.ToDecimal(textCost.Text); }
            set { textCost.Text = value.ToString(); }
        }

        public Models.Categories AuctionCategoryType
        {
            get { return (Models.Categories)dropDownCategoryList.SelectedIndex+1; }
            set { dropDownCategoryList.SelectedIndex = (int)value+1; }
        }
        public int AuctionCategoryTypeInt
        {
            get { return dropDownCategoryList.SelectedIndex + 1; }
        }

        public Colors AuctionColor
        {
            get { return (Models.Colors) DropDownColorList.SelectedIndex; }
            set { DropDownColorList.SelectedIndex = (int)value; }
        }
        public int AuctionColorInt
        {
            get { return DropDownColorList.SelectedIndex+1; }
        }

        public string AuctionDescrition
        {
            get { return textDescription.Text; }
            set { textDescription.Text = value; }
        }

        public byte[] AuctionImageBytes
        {
            get { return FileUpload.FileBytes; }
        }

        public System.Web.UI.WebControls.Label ControlLabel
        {
            get { return textAllWorks; }
            set { textAllWorks = value; }
        }
        public IEnumerable<string> SelectCategories()
        {
            AttachPresenter();
            return Presenter.ReturnCategories2DDList();
        }
    }
}