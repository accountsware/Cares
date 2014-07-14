﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Measurement Unit Domain Model
    /// </summary>
    public class MeasurementUnit
    {
        #region Persisted Properties
        /// <summary>
        /// Measurement Unit ID
        /// </summary>
        public int MeasurementUnitId { get; set; }
        /// <summary>
        /// Measurement Unit Code
        /// </summary>
        [StringLength(100)]
        public string MeasurementUnitCode { get; set; }
        /// <summary>
        /// Measurement Unit Name
        /// </summary>
        [StringLength(255)]
        public string MeasurementUnitName { get; set; }
        /// <summary>
        /// Measurement Unit Description
        /// </summary>
        [StringLength(255)]
        public string MeasurementUnitDescription { get; set; }
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
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        [StringLength(100)]
        public string RecCreatedBy { get; set; }
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
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion
    }
}
