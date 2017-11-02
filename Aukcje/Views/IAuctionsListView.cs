using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Aukcje
{
    public interface IAuctionsListView : IBaseView
    {
        decimal FilterLowPrice { get; set; }
        decimal FilterHighPrice { get; set; }
        Models.Categories FilterCategory { get; set; }
        string SearchedItem { get; }
    }
}
