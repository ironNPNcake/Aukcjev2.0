using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class BrandRepository
    {
        public IEnumerable<string>GetBrands(int CategoryId)
        {
            List<string> list;
            List<Auction> AuctionsList;
            using (var ctx = new bazaEntities())
            {
                AuctionsList = ctx.Auctions.Where(p => p.Brand != null).ToList();
            }
            if (CategoryId > 0)
                AuctionsList = AuctionsList.Where(p => p.Category == CategoryId).ToList();

            list = AuctionsList.Select(p => p.Brand).Distinct().OrderBy(p => p).ToList();
            return list;
        }
    }
}