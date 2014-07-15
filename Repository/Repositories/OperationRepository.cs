﻿using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Operation Repository
    /// </summary>
    public sealed class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OperationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Operation> DbSet
        {
            get
            {
                return db.Operations;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Organization Groups for User Domain Key
        /// </summary>
        public override IQueryable<Operation> GetAll()
        {
            return DbSet.Where(operation => operation.UserDomainKey == UserDomaingKey);
        }
        #endregion
    }
}