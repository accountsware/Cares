﻿using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Status Mapper
    /// </summary>
    public static class VehicleStatusMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleStatus CreateFrom(this Cares.Models.DomainModels.VehicleStatus source)
        {
            return new VehicleStatus
            {
                VehicleStatusId = source.VehicleStatusId,
                VehicleStatusName = source.VehicleStatusName,
                VehicleStatusCode = source.VehicleStatusCode
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleStatusDropDown CreateFromDropDown(this Cares.Models.DomainModels.VehicleStatus source)
        {
            return new VehicleStatusDropDown
            {
                VehicleStatusId = source.VehicleStatusId,
                VehicleStatusCodeName = source.VehicleStatusCode+" - "+source.VehicleStatusName
            };
        }
        #endregion
    }
}