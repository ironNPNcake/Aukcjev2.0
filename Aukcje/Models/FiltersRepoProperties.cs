using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public partial class Filters
    {
        static AuctionRepository _aRepo;
        public static AuctionRepository AuctionRepo
        {
            get
            {
                if (_aRepo == null)
                    _aRepo = new AuctionRepository();
                return _aRepo;
            }
        }
        static ColorRepository _cRepo;
        public static ColorRepository ColorRepo
        {
            get
            {
                if (_cRepo == null)
                    _cRepo = new ColorRepository();
                return _cRepo;
            }
        }
        static MembershipRepository _mRepo;
        public static MembershipRepository MembershipRepo
        {
            get
            {
                if (_mRepo == null)
                    _mRepo = new MembershipRepository();
                return _mRepo;
            }
        }
        static UserRepository _uRepo;
        public static UserRepository UserRepo
        {
            get
            {
                if (_uRepo == null)
                    _uRepo = new UserRepository();
                return _uRepo;
            }
        }
        static CategoryRepository _ctRepo;
        public static CategoryRepository CategoryRepo
        {
            get
            {
                if (_ctRepo == null)
                    _ctRepo = new CategoryRepository();
                return _ctRepo;
            }
        }
        static BrandRepository _bRepo;
        public static BrandRepository BrandRepo
        {
            get
            {
                if (_bRepo == null)
                    _bRepo = new BrandRepository();
                return _bRepo;
            }
        }
    }
}