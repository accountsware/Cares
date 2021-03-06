﻿using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Pricing Strategy Service
    /// </summary>
    public class PricingStrategyService : IPricingStrategyService
    {
        #region Private
        private readonly IPricingStrategyRepository pricingStrategyRepository;
        #endregion
       
        #region Constructor

        public PricingStrategyService(IPricingStrategyRepository pricingStrategyRepository)
        {
            this.pricingStrategyRepository = pricingStrategyRepository;
        }
        #endregion
       
        #region Public
        /// <summary>
        /// Load All Pricing Stragety
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PricingStrategy> LoadAll()
        {
            return pricingStrategyRepository.GetAll();
        }
        #endregion
    }
}
