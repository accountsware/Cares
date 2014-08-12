﻿using Cares.Models.DomainModels;
using System.Collections;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Hire Group Interface
    /// </summary>
    public interface IHireGroupService
    {
        /// <summary>
        /// Get Hire Groups By Vehicle Make, Category, Model, Year and Hire Group Code
        /// For AutoComplete
        /// </summary>
        IEnumerable<HireGroup> GetByCodeAndVehicleInfo(string searchText);

        /// <summary>
        /// Load roups, based on search filters
        /// </summary>
        HireGroupSearchResponse LoadHireGroups(HireGroupSearchRequest tarrifTypeRequest);
        
        /// <summary>
        /// Load Hire Group Base data
        /// </summary>
        /// <returns></returns>
        HireGroupBaseResponse LoadBaseData();
        /// <summary>
        /// Find Hire Group By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HireGroup FindById(long id);
        /// <summary>
        /// Delete Hire Group
        /// </summary>
        /// <param name="instance"></param>
        void DeleteHireGroup(HireGroup instance);
        /// <summary>
        /// Add Hire Group
        /// </summary>
        /// <param name="request"></param>
        void AddHireGroup(HireGroupAddRequest request);
        /// <summary>
        /// Update Hire Group
        /// </summary>
        /// <param name="request"></param>
        void UpdateHireGroup(HireGroupAddRequest request);
    }
}
