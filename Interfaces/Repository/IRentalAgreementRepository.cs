﻿using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Rental Agreement Repository Interface
    /// </summary>
    public interface IRentalAgreementRepository : IBaseRepository<RaMain, long>
    {
        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(RaMain raMain);
        
        /// <summary>
        /// Get all Ra Main
        /// </summary>
        RaMainForRaQueueSearchResponse GetRaMainsForRaQueue(RaQueueSearchRequest request);
    }
}
