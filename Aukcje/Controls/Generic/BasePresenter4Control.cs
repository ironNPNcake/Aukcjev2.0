using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aukcje;

namespace Aukcje.Controls
{
    public abstract class BasePresenter4Control<TView> : BasePresenter where TView : IBaseView
    {
        AuctionRepository _aRepo;
        public AuctionRepository AuctionRepo
        {
            get
            {
                if (_aRepo == null)
                    _aRepo = new AuctionRepository();
                return _aRepo;
            }
        }
        ColorRepository _cRepo;
        public ColorRepository ColorRepo
        {
            get
            {
                if (_cRepo == null)
                    _cRepo = new ColorRepository();
                return _cRepo;
            }
        }
        MembershipRepository _mRepo;
        public MembershipRepository MembershipRepo
        {
            get
            {
                if (_mRepo == null)
                    _mRepo = new MembershipRepository();
                return _mRepo;
            }
        }
        UserRepository _uRepo;
        public UserRepository UserRepo
        {
            get
            {
                if (_uRepo == null)
                    _uRepo = new UserRepository();
                return _uRepo;
            }
        }
        CategoryRepository _ctRepo;
        public CategoryRepository CategoryRepo
        {
            get
            {
                if (_ctRepo == null)
                    _ctRepo = new CategoryRepository();
                return _ctRepo;
            }
        }
        public new TView View
        {
            get
            {
                return (TView)base.View;
            }
            set
            {
                View = value;
            }
        }
    }
}