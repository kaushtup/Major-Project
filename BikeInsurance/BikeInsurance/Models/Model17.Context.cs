﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BikeInsurance.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BikeInsuranceEntities17 : DbContext
    {
        public BikeInsuranceEntities17()
            : base("name=BikeInsuranceEntities17")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCCHP> tblCCHPs { get; set; }
        public virtual DbSet<tblClaimData> tblClaimDatas { get; set; }
        public virtual DbSet<tblCompanyName> tblCompanyNames { get; set; }
        public virtual DbSet<tblLoteNo> tblLoteNoes { get; set; }
        public virtual DbSet<tblTestingSet> tblTestingSets { get; set; }
        public virtual DbSet<tblTrainingSet> tblTrainingSets { get; set; }
        public virtual DbSet<tblTypeCover> tblTypeCovers { get; set; }
        public virtual DbSet<tblUnclaimData> tblUnclaimDatas { get; set; }
        public virtual DbSet<tblUserData> tblUserDatas { get; set; }
        public virtual DbSet<tblYM> tblYMs { get; set; }
        public virtual DbSet<tblZone> tblZones { get; set; }
    }
}
