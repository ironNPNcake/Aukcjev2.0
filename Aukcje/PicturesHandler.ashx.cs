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
        AuctionRepository _aRepo;
        AuctionRepository AuctionRepo
        {
            get
            {
                if (_aRepo == null)
                    _aRepo = new AuctionRepository();
                return _aRepo;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request.QueryString["ID"]))
            {
                int id = Convert.ToInt32(context.Request.QueryString["ID"]);
                byte[] binary = AuctionRepo.GetAuctionImageBytes(id);

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