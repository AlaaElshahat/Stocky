//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string discount { get; set; }
        public System.DateTime production_date { get; set; }
        public System.DateTime expire_in { get; set; }
        public int Category_id { get; set; }
        public Nullable<int> addedby { get; set; }
        public string code { get; set; }
        public Nullable<System.DateTime> addedat { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
