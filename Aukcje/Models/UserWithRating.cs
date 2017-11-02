using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class UserWithRating
    {
        public aspnet_Users currentUser { get; set; }
        public int? rate { get; set; }
    }
}