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
    /// Country Repository
    /// </summary>
    public sealed class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CountryRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Country> DbSet
        {
            get
            {
                return db.Countries;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Countries for User Domain Key
        /// </summary>
        public override IEnumerable<Country> GetAll()
        {
            return DbSet.Select(country => country).OrderBy(country => country.CountryName).ToList();
        }

        /// <summary>
        /// Find by Id
        /// </summary>
        public Country Find(int id)
        {
            return DbSet.FirstOrDefault(country =>  country.CountryId == id);
        }
        #endregion
    }
}
