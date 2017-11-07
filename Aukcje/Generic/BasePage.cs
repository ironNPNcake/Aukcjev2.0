using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Threading;

namespace Aukcje
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {

            string controlInvokeThePostBack = Request.Form["__EventTarget"];
            if (!string.IsNullOrEmpty(controlInvokeThePostBack))
            {
                if (controlInvokeThePostBack.Contains("ddlLanguage"))
                {
                    Session["lang"] = Request.Form[controlInvokeThePostBack];
                }
            }

            if (!string.IsNullOrEmpty(Request["lang"]))
            {

                Session["lang"] = Request["lang"];
            }
            string lang = Convert.ToString(Session["lang"]);
            string culture = string.Empty;
            if (lang.ToLower().CompareTo("en") == 0 || string.IsNullOrEmpty(culture))
            {
                culture = "en";
            }
            if (lang.ToLower().CompareTo("pl") == 0)
            {
                culture = "pl";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            base.InitializeCulture();

        }
    }
}