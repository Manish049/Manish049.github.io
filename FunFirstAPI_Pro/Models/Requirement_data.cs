//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FunFirstAPI_Pro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requirement_data
    {
        public int req_id { get; set; }
        public Nullable<System.DateTime> req_datetime { get; set; }
        public Nullable<int> req_jan { get; set; }
        public Nullable<int> req_feb { get; set; }
        public Nullable<int> req_mar { get; set; }
        public Nullable<int> req_apr { get; set; }
        public Nullable<int> req_may { get; set; }
        public Nullable<int> req_jun { get; set; }
        public Nullable<int> req_jul { get; set; }
        public Nullable<int> req_aug { get; set; }
        public Nullable<int> req_sep { get; set; }
        public Nullable<int> req_oct { get; set; }
        public Nullable<int> req_nov { get; set; }
        public Nullable<int> req_dec { get; set; }
        public Nullable<int> req_user { get; set; }
        public Nullable<int> req_franchise { get; set; }
    
        public virtual Franchise_tbl Franchise_tbl { get; set; }
        public virtual User_tbl User_tbl { get; set; }
    }
}
