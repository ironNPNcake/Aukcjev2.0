using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    /// <summary>
    /// Summary description for UserPictureHandler
    /// </summary>
    public class UserPictureHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request.QueryString["UserName"]))
            {


                byte[] binary;
                string loggedUserName = Convert.ToString(context.Request.QueryString["UserName"]);
                using (var ctx = new bazaEntities())
                {
                    binary = (from userM in ctx.aspnet_Membership
                              join userU in ctx.aspnet_Users
                              on userM.UserId equals userU.UserId
                              where userU.UserName == loggedUserName
                              select userM.Image).FirstOrDefault();
                }

                //   list = list.Where(p => p.ID == 2);
                //var prop = list.GetType().GetProperty("Image");



                //var obj = prop.GetValue(list);
                //byte[] binary = obj as byte[];
                if (binary != null && binary.Length > 0)
                {
                    context.Response.ContentType = "image/jpeg";
                    context.Response.BinaryWrite(binary);
                }

            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}