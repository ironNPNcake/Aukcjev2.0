using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aukcje.Controls
{
    public interface IAccountDetailsView : IBaseView
    {
        string UName { get; }
    }
}
