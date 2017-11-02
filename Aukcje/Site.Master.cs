using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Aukcje
{
    public partial class Site : System.Web.UI.MasterPage//, ISiteMasterView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Session["lang"] = ddlLanguage.SelectedValue;

             if (!this.IsPostBack)
             {
                 if (ddlLanguage.Items.FindByValue(CultureInfo.CurrentCulture.Name) != null)
                 {
                     ddlLanguage.Items.FindByValue(CultureInfo.CurrentCulture.Name).Selected = true;
                     Session["lang"] = ddlLanguage.SelectedValue;
                 }
             }
             */


            if (Session["lang"]!=null)
            {
                if (Session["lang"].ToString() == "pl")
                    ddlLanguage.SelectedIndex = 1;
                else if (Session["lang"].ToString() == "en")
                    ddlLanguage.SelectedIndex = 0;
            }
            else if(Request.Cookies["lang"]!=null)
            {
                if (Request.Cookies["lang"].ToString() == "pl")
                    ddlLanguage.SelectedIndex = 1;
                else if (Request.Cookies["lang"].ToString() == "en")
                    ddlLanguage.SelectedIndex = 0;
            }
        }

        protected void Logout_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        protected void ddlLanguage_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            //            Session["lang"] = ddlLanguage.SelectedValue;
            //    Page.
        }
    }
}