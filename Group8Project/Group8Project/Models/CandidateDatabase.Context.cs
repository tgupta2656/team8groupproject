﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group8Project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_128040_group8Entities : DbContext
    {
        public DB_128040_group8Entities()
            : base("name=DB_128040_group8Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CandidatePolicy> CandidatePolicies { get; set; }
        public virtual DbSet<CandidateTable> CandidateTables { get; set; }
        public virtual DbSet<PolicyyTable> PolicyyTables { get; set; }
    }
}