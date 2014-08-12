﻿using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;


namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// tariff Type Service Interface
    /// </summary>
    public interface ITariffTypeService
    {
        /// <summary>
        /// Get All tariff Types
        /// </summary>
        IEnumerable<TariffType> LoadAll();
        /// <summary>
        /// Load tariff type, based on search filters
        /// </summary>
        TariffTypeResponse LoadtariffTypes(TariffTypeRequest tariffTypeRequest);
        /// <summary>
        /// Find tariff Type By ID
        /// </summary>
        TariffTypeDetailResponse FindDetailById(long id);
        /// <summary>
        /// Add tariff Type
        /// </summary>
        TariffType AddtariffType(TariffType tariffType);
        /// <summary>
        /// Update tariff Type
        /// </summary>
        TariffType UpdatetariffType(TariffType tariffType);
        /// <summary>
        /// Get All Base Data
        /// </summary>
        TariffTypeBaseResponse GetBaseData();
    }
}
