﻿using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Hire Group Detail Interface
    /// </summary>
    public interface IHireGroupDetailRepository: IBaseRepository<HireGroupDetail, long>
    {
        /// <summary>
        /// Get Hire Groups By Vehicle Make, Category, Model, Year and Hire Group Code
        /// For AutoComplete
        /// </summary>
        IEnumerable<HireGroupDetail> GetByCodeAndVehicleInfo(string searchText, long operationWorkPlaceId, DateTime startDtTime, DateTime endDtTime);

        /// <summary>
        /// Get Hire Group Details For Tarif fRate
        /// </summary>
        /// <returns></returns>
        IEnumerable<HireGroupDetail> GetHireGroupDetailsForTariffRate();

        /// <summary>
        /// Get Hire Group Detail By Hire Group Id
        /// </summary>
        IEnumerable<HireGroupDetail> GetHireGroupDetailByHireGroupId(long hireGroupId);

        /// <summary>
        /// Association check of HireGroup Detail and Vehicle Make
        /// </summary>
        bool IsHireGroupDetailAssociatedWithVehicleMake(long vehiclemakeId);


        /// <summary>
        /// Association check of HireGroup Detail and Vehicle Category
        /// </summary>
        bool IsHireGroupDetailAssociatedWithVehicleCategory(long vehicleCategoryId);

        /// <summary>
        /// Association check of HireGroup Detail and Vehicle Model
        /// </summary>
        bool IsHireGroupDetailAssociatedWithVehicleModel(long vehicleModelId);
    }
}
