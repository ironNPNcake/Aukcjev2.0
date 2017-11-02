using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Aukcje
{
    public interface ISingleAuctionView : IBaseView
    {
        string UserName { get; }
        int Id { get; }
        Label LblCheck { get; }
    }
}
