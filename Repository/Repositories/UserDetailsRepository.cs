﻿using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    public class UserDetailsRepository : BaseRepository<UserDetail>, IUserDetailsRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserDetailsRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<UserDetail> DbSet
        {
            get
            {
                return db.UserDetails;
            }
        }

        #endregion        
    }
}
