using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Label = System.Web.UI.WebControls.Label;

namespace Aukcje
{
    public interface IInsertNewItemView : IBaseView
    {
        string AuctionName { get; set; }
        decimal AuctionPrice { get; set; }
        Models.Categories AuctionCategoryType { get; set; }
        Models.Colors AuctionColor{ get; set; }
        string AuctionDescrition { get; set; }
        byte[] AuctionImageBytes { get; }
        Label ControlLabel { get; set; }
    }
}
