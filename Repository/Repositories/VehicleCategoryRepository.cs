﻿using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Vehicle Category Repository
    /// </summary>
    public class VehicleCategoryRepository: BaseRepository<VehicleCategory>, IVehicleCategoryRepository
    {
          #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleCategoryRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleCategory> DbSet
        {
            get
            {
                return db.VehicleCategories;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Categories for User Domain Key
        /// </summary>
        public override IQueryable<VehicleCategory> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}