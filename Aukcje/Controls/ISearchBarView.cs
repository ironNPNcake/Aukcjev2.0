using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aukcje.Controls
{
    public interface ISearchBarView : IBaseView
    {
        Models.Categories FilterCategory { get; set; }
        string SearchedItem { get; set; }
        string queryString { get; }
    }
}
