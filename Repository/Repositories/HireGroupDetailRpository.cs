﻿using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Hire Group Detail Repository
    /// </summary>
    public sealed class HireGroupDetailRpository : BaseRepository<HireGroupDetail>, IHireGroupDetailRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupDetailRpository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroupDetail> DbSet
        {
            get
            {
                return db.HireGroupDetails;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Vehicle Models for User Domain Key
        /// </summary>
        public override IQueryable<HireGroupDetail> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}