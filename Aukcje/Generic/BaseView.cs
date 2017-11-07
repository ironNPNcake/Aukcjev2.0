using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public class BaseView<TPresenter> : BasePage, IBaseView where TPresenter : BasePresenter, new()
    {
        protected TPresenter Presenter;
        public BaseView()
        {
            AttachPresenter();
        }
        public void AttachPresenter()
        {
            Presenter = new TPresenter();
            Presenter.View = this;
        }
    }
}