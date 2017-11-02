using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aukcje
{
    public abstract class BasePresenter<TView>: BasePresenter where TView:IBaseView
    {
        public new TView View
        {
            get
            {
                return (TView)base.View;
            }
            set
            {
                base.View = value;
            }
        }
    }
}