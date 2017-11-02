using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aukcje
{
    public partial class SitePoor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["lang"] != null)
                {
                    ddlLanguage.Items.FindByValue(Session["lang"].ToString()).Selected = true;
                }
            }
        }
    }
}