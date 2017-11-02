using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Aukcje
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request.QueryString["ID"]))
            {


                byte[] binary;
                int id = Convert.ToInt32(context.Request.QueryString["ID"]);
                using (var ctx = new bazaEntities())
                {
                    binary = ctx.Auctions.Where(p => p.ID == id).Select(p => p.Image).FirstOrDefault();
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