﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Goliaz.Dto
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class goliazco_FWEntities : DbContext
    {
        public goliazco_FWEntities()
            : base("name=goliazco_FWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<LOG_ERROR> LOG_ERROR { get; set; }
        public DbSet<REPORT_DAY> REPORT_DAY { get; set; }
        public DbSet<USERS> USERS { get; set; }
        public DbSet<DAYS> DAYS { get; set; }
        public DbSet<DAYS_REPORT> DAYS_REPORT { get; set; }
        public DbSet<DAYS_CONFIG> DAYS_CONFIG { get; set; }
    }
}
