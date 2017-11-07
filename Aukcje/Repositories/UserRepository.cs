using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class UserRepository
    {
        public IEnumerable<UserWithRating> GetUserWithRating(string UserName)
        {
            IEnumerable<Aukcje.UserWithRating> list;
            using (var ctx = new bazaEntities())
            {
                list = from p in ctx.aspnet_Users
                       join d in ctx.aspnet_Membership
                       on p.UserId equals d.UserId
                       where p.UserName.Equals(UserName)
                       select new UserWithRating()
                       {
                           currentUser = p,
                           rate = d.Rating
                       };
                list = list.ToList();
            }

            return list;
        }
    }
}