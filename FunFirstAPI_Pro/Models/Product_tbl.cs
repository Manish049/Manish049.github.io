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
    
    public partial class Product_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product_tbl()
        {
            this.Franchise_tbl = new HashSet<Franchise_tbl>();
        }
    
        public int pr_id { get; set; }
        public string pr_name { get; set; }
        public string pr_createdby { get; set; }
        public Nullable<System.DateTime> pr_createdat { get; set; }
        public string pr_updatedby { get; set; }
        public Nullable<System.DateTime> pr_updatedat { get; set; }
        public string pr_isdeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Franchise_tbl> Franchise_tbl { get; set; }
    }
}
