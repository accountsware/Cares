﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Vehicle Make Domain Model
    /// </summary>
    public class VehicleMake
    {
        #region Persisted Properties
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        [Key]
        public short VehicleMakeId { get; set; }
        /// <summary>
        /// Vehicle Make Code
        /// </summary>
        [StringLength(100)]
        public string VehicleMakeCode { get; set; }
        /// <summary>
        /// Vehicle Make Name
        /// </summary>
        [StringLength(255)]
        public string VehicleMakeName { get; set; }
        /// <summary>
        /// Vehicle Make Description
        /// </summary>
        [StringLength(500)]
        public string VehicleMakeDescription { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Is ReadOnly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }
        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100)]
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion
    }
}
