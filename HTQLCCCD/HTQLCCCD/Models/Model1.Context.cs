﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HTQLCCCD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HeThongQLCCCDEntities2 : DbContext
    {
        public HeThongQLCCCDEntities2()
            : base("name=HeThongQLCCCDEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<appointment_schedule> appointment_schedule { get; set; }
        public virtual DbSet<authority> authorities { get; set; }
        public virtual DbSet<citizen> citizens { get; set; }
        public virtual DbSet<criminal_record> criminal_record { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<requirement> requirements { get; set; }
        public virtual DbSet<sending> sendings { get; set; }
        public virtual DbSet<state_leaders> state_leaders { get; set; }
    }
}
