using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Aukcje.Controls
{
    public interface IYourAuctionsView : IBaseView
    {
        string loggedUser{ get; }
        ListView ListView { get; }
        byte[] ImageBytes { get; set; }
    }
}
