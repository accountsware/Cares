﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Models.IdentityModels;
using Models.LoggerModels;
using Models.MenuModels;

namespace Repository.BaseRepository
{
    /// <summary>
    /// Base Db Context. Implements Identity Db Context over Application User
    /// </summary>
    public sealed class BaseDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Private
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once NotAccessedField.Local
        private IUnityContainer container;
        #endregion
        #region Protected
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<OrgGroup>().HasKey(org => org.OrgGroupId);
            modelBuilder.Entity<OrgGroup>().Property(org => org.OrgGroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<BusinessSegment>().HasKey(bs => bs.BusinessSegmentId);
            modelBuilder.Entity<BusinessSegment>().Property(bs => bs.BusinessSegmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Company>().HasKey(company => company.CompanyId);
            modelBuilder.Entity<Company>().Property(company => company.CompanyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Country>().HasKey(country => country.CountryId);
            modelBuilder.Entity<Country>().Property(country => country.CountryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Department>().HasKey(department => department.DepartmentId);
            modelBuilder.Entity<Department>().Property(department => department.DepartmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Operation>().HasKey(operation => operation.OperationId);
            modelBuilder.Entity<Operation>().Property(operation => operation.OperationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MeasurementUnit>().HasKey(ms => ms.MeasurementUnitId);
            modelBuilder.Entity<MeasurementUnit>().Property(ms => ms.MeasurementUnitId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<BpRatingType>().HasKey(bprType => bprType.BpRatingTypeId);
            modelBuilder.Entity<BpRatingType>().Property(bprType => bprType.BpRatingTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
        #endregion
        #region Constructor
        public BaseDbContext()
        {            
        }
        #endregion
        #region Public

        public BaseDbContext(string connectionString,IUnityContainer container)
            : base(connectionString)
        {
            this.container = container;
        }
        #region Logger

        /// <summary>
        /// Logs
        /// </summary>
        public DbSet<Log> Logs { get; set; }
        /// <summary>
        /// Log Categories
        /// </summary>
        public DbSet<LogCategory> LogCategories { get; set; }
        /// <summary>
        /// Category Logs
        /// </summary>
        public DbSet<CategoryLog> CategoryLogs { get; set; }
        #endregion
        #region Menu Rights and Security
        /// <summary>
        /// Menu Rights
        /// </summary>
        public DbSet<MenuRight> MenuRights { get; set; }
        /// <summary>
        /// Menu
        /// </summary>
        public DbSet<Menu> Menus { get; set; }
        #endregion
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        /// <summary>
        /// Companies DB Set
        /// </summary>
        public DbSet<Company> Companies { get; set; }
        /// <summary>
        /// Business Segments DB Set
        /// </summary>
        public DbSet<BusinessSegment> BusinessSegments { get; set; }
        /// <summary>
        /// Organization Groups DB Set
        /// </summary>
        public DbSet<OrgGroup> OrgGroups { get; set; }
        /// <summary>
        /// Countries DB Set
        /// </summary>
        public DbSet<Country> Countries { get; set; }
        /// <summary>
        /// Department DB Set
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// Operation DB Set
        /// </summary>
        public DbSet<Operation> Operations { get; set; }
        /// <summary>
        /// Measurement Unit DB Set
        /// </summary>
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        /// <summary>
        /// Business Partner Rating Type DB Set
        /// </summary>
        public DbSet<BpRatingType> BpRatingTypes { get; set; }

        #endregion
    }
}
