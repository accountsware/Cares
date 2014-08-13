﻿namespace Cares.Web.Models
{
    /// <summary>
    /// Hire Group Detail Web Model
    /// </summary>
    public class HireGroupDetaill
    {
        
        #region Public Properties
        
        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; }

        /// <summary>
        /// Hire Group Id
        /// </summary>
        public long HireGroupId { get; set; }

        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }

        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short VehicleMakeId { get; set; }

        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short VehicleCategoryId { get; set; }

        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        public short VehicleModelId { get; set; }

        /// <summary>
        /// Vehicle Category
        /// </summary>
        public VehicleCategory VehicleCategory { get; set; }

        /// <summary>
        /// Vehicle Make
        /// </summary>
        public VehicleMake VehicleMake { get; set; }

        /// <summary>
        /// Vehicle Model
        /// </summary>
        public VehicleModel VehicleModel { get; set; }

        /// <summary>
        /// Hire Group
        /// </summary>
        public HireGroup HireGroup { get; set; }

        #endregion

    }
}