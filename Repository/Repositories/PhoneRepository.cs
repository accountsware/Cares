﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Phone Repository
    /// </summary>
    public sealed class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public PhoneRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Phone> DbSet
        {
            get
            {
                return db.Phones;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Phone for User Domain Key
        /// </summary>
        /// 
        public override IEnumerable<Phone> GetAll()
        {
            return DbSet.Where(phones => phones.UserDomainKey == UserDomainKey).ToList();
        }
        /// <summary>
        /// Find Phone by Id
        /// </summary>
        public PhoneType Find(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get associated Phones with Work Location Id
        /// </summary>
        public IEnumerable<Phone> GetPhonesByWorkLocationId(long workLocationId)
        {
            return DbSet.Where(phone => phone.UserDomainKey == UserDomainKey && phone.WorkLocation.WorkLocationId == workLocationId).ToList();
        }
        #endregion
    }
}
