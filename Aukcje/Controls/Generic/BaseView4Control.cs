using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje.Controls
{
    public class BaseView4Control<TPresenter> : System.Web.UI.UserControl, IBaseView where TPresenter : BasePresenter, new()
    {
        protected TPresenter Presenter;
        public void AttachPresenter()
        {
            Presenter = new TPresenter();
            Presenter.View = this;
        }
    }
}