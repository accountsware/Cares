﻿using System.Linq;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
{
    /// <summary>
    /// Bisness Partner Rating Type Service
    /// </summary>
    public class BPRatingTypeService : IBPRatingTypeService
    {
        #region Private
        private readonly IBpRatingTypeRepository bpRatingTypeRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bpRatingTypeRepository"></param>
        public BPRatingTypeService(IBpRatingTypeRepository bpRatingTypeRepository)
        {
            this.bpRatingTypeRepository = bpRatingTypeRepository;
        }
        #endregion
        #region Public
        /// <summary>
        /// Load All
        /// </summary>
        /// <returns></returns>
        public IQueryable<BpRatingType> LoadAll()
        {
            return bpRatingTypeRepository.GetAll();
        }
        #endregion
    }
}