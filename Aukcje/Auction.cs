//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aukcje
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auction
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
        public int Color { get; set; }
        public string Description { get; set; }
        public string seller { get; set; }
        public Nullable<int> commentID { get; set; }
        public string status { get; set; }
        public byte[] Image { get; set; }
    }
}
