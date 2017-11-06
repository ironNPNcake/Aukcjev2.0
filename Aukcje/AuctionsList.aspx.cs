using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aukcje.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
//using System.Data.Entity.Infrastructure;
//using System.Data.Entity.Infrastructure.Interception;

namespace Aukcje
{
    public partial class AuctionsList : BaseView<AuctionsListPresenter>, IAuctionsListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                ListViewAuctionsList.DataBind();
            }
        }
        public IEnumerable Select()
        {
            AttachPresenter();
            return Presenter.SelectAuctionsList();
        }


        protected void Auction_OnClick(object sender, CommandEventArgs e)
        {
            //AttachPresenter();
            Response.Redirect(String.Format("~/SingleAuction.aspx?ID={0}",e.CommandArgument));
        }

        public decimal FilterLowPrice
        {
            get
            {
                if(!String.IsNullOrEmpty(textLowPrice.Text))
                    return Convert.ToDecimal(textLowPrice.Text);
                return 0;
            }
            set { textLowPrice.Text = value.ToString(); }
        }

        public decimal FilterHighPrice
        {
            get
            {
                if(!String.IsNullOrEmpty(textHighPrice.Text))
                    return Convert.ToDecimal(textHighPrice.Text);
                return 999999999999999999;
            }
            set { textHighPrice.Text = value.ToString(); }
        }

        public Models.Categories FilterCategory
        {
            get
            {
                string categoryID = Request.QueryString["category"];
                if (!string.IsNullOrEmpty(categoryID))
                    return (Models.Categories)Convert.ToInt32(categoryID);
                return (Models.Categories)0;
            }
        }

        public string SearchedItem
        {
            get { return Request.QueryString["product"]; }
        }

        public CheckBoxList FilterColorCheckBoxList
        {
            get { return FiltersCheckBoxes.FilterColorCheckBoxList; }
            set { FiltersCheckBoxes.FilterColorCheckBoxList = value; }
        }
        public CheckBoxList FilterBrandsCheckBoxList
        {
            get { return BrandFilter.CheckBoxBrandsList; }
            set { BrandFilter.CheckBoxBrandsList = value; }
        }
    }


}