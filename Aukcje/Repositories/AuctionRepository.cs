using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class AuctionRepository
    {
        public List<Auction> GetAuctions()
        {
            List<Auction> list; 
            using (var ctx = new bazaEntities())
            {
                list = ctx.Auctions.ToList();
            }
            return list;
        }

        public void AddAuctions(Auction auc)
        {
            using (var ctx = new bazaEntities())
            {
                ctx.Auctions.Add(auc);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Auction> GetAuctionById(int ID)
        {
            IEnumerable<Auction> list;
            using (var ctx = new bazaEntities())
            {
                list = ctx.Auctions.ToList();
                list = list.Where(p => p.ID == ID);
            }
            return list;
        }

        public IEnumerable<Models.CommentWithAuction> GetClosedAuctions(string UserName)
        {
            IEnumerable<Aukcje.Models.CommentWithAuction> list;
            IEnumerable<Aukcje.Auction> Auctions;
            IEnumerable<Aukcje.Comment> Comments;
            using (var ctx = new bazaEntities())
            {
                Auctions = ctx.Auctions.ToList();
                Comments = ctx.Comments.ToList();
            }
            Auctions = Auctions.Where(p => p.seller.Equals(UserName) && p.status == "zakonczone");

            list = from p in Auctions
                   join c in Comments
                   on p.commentID equals c.CommentID
                   select new Models.CommentWithAuction() { aukcja = p, Comment = c, ConsumerName = "asd" };

            return list;
        }

        public IEnumerable<Auction> GetAuctionsByUser(string user)
        {
            IEnumerable<Aukcje.Auction> list;
            using (var ctx = new bazaEntities())
            {
                list = from auction in ctx.Auctions
                       join _user in ctx.aspnet_Users
                       on auction.seller equals _user.UserName
                       where (_user.UserName == user)
                       select auction;
                list = list.ToList();
            }
            return list;
        }

        public void UpdateAuction(Aukcje.Auction objAuction, byte[] bytes)
        {
            int a = objAuction.ID;
            using (var ctx = new bazaEntities())
            {
                var updatedauction = ctx.Auctions.FirstOrDefault(p => p.ID == a);
                updatedauction.Title = objAuction.Title;
                updatedauction.Description = objAuction.Description;
                updatedauction.Price = objAuction.Price;
                if (bytes != null)
                {
                    updatedauction.Image = bytes;
                }

                ctx.SaveChanges();
            }
        }

        public void DeleteAuction(int Id)
        {
            using (var ctx = new bazaEntities())
            {
                var obj = ctx.Auctions.SingleOrDefault(p => p.ID == Id);
                ctx.Auctions.Remove(obj);
                ctx.SaveChanges();
            }
        }

        public byte[] GetAuctionImageBytes(int AuctionId)
        {
            byte[] binary;
            using (var ctx = new bazaEntities())
            {
                binary = ctx.Auctions.Where(p => p.ID == AuctionId).Select(p => p.Image).FirstOrDefault();
            }
            return binary;
        }
    }
}