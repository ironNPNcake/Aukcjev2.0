using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aukcje
{
    public interface IBasePresenter
    {
        IBaseView View { get; set; }
    }
}
