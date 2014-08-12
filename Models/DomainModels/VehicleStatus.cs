﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Status Domain Model
    /// </summary>
    public class VehicleStatus
    {
        #region Persisted Properties
        
        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// Vehicle Status Code
        /// </summary>
        [StringLength(100), Required]
        public string VehicleStatusCode { get; set; }

        /// <summary>
        /// Vehicle Status Name
        /// </summary>
        [StringLength(255)]
        public string VehicleStatusName { get; set; }

        /// <summary>
        /// Vehicle Status Description
        /// </summary>
        [StringLength(500)]
        public string VehicleStatusDescription { get; set; }

        /// <summary>
        /// Vehicle Status Key
        /// </summary>
        public short? VehicleStatusKey { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

        /// <summary>
        /// Availability Check
        /// </summary>
        [Required]
        public bool AvailabilityCheck { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        [Required]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        [Required]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        [Required]
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100), Required]
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        [Required]
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        [StringLength(100), Required]
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle Sub Statuses
        /// </summary>
        public virtual ICollection<VehicleSubStatus> VehicleSubStatus { get; set; }

        /// <summary>
        /// Vehicles having this Vehicle Status
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        #endregion
    }
}
