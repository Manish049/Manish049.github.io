﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FFGSPL_dbEntities : DbContext
    {
        public FFGSPL_dbEntities()
            : base("name=FFGSPL_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<API_Hit> API_Hit { get; set; }
        public virtual DbSet<Brand_tbl> Brand_tbl { get; set; }
        public virtual DbSet<Franchise_tbl> Franchise_tbl { get; set; }
        public virtual DbSet<Product_tbl> Product_tbl { get; set; }
        public virtual DbSet<Requirement_data> Requirement_data { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User_tbl> User_tbl { get; set; }
    
        public virtual ObjectResult<Fran_Data_Result> Fran_Data(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Fran_Data_Result>("Fran_Data", idParameter);
        }
    
        public virtual ObjectResult<Franchise_Data_Result> Franchise_Data(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Franchise_Data_Result>("Franchise_Data", idParameter);
        }
    
        public virtual int RequestHit(string aPI, Nullable<int> hit)
        {
            var aPIParameter = aPI != null ?
                new ObjectParameter("API", aPI) :
                new ObjectParameter("API", typeof(string));
    
            var hitParameter = hit.HasValue ?
                new ObjectParameter("Hit", hit) :
                new ObjectParameter("Hit", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RequestHit", aPIParameter, hitParameter);
        }
    
        public virtual ObjectResult<User_Data_Result> User_Data(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Data_Result>("User_Data", emailParameter);
        }
    
        public virtual ObjectResult<FranCount_Data_Result> FranCount_Data(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FranCount_Data_Result>("FranCount_Data", idParameter);
        }
    }
}
