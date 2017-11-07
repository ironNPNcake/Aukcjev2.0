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
        MembershipRepository _mRepo;
        MembershipRepository MembershipRepo
        {
            get
            {
                if (_mRepo == null)
                    _mRepo = new MembershipRepository();
                return _mRepo;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request.QueryString["UserName"]))
            {
                string loggedUserName = Convert.ToString(context.Request.QueryString["UserName"]);
                byte[] binary = MembershipRepo.GetUserImageBytes(loggedUserName);

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