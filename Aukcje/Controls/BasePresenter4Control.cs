using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aukcje;

namespace Aukcje.Controls
{
    public abstract class BasePresenter4Control<TView> : BasePresenter where TView : IBaseView
    {
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