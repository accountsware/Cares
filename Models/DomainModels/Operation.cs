﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DomainModels
{
    /// <summary>
    /// Operation Domain Model
    /// </summary>
    public class Operation
    {
        #region Persisted Properties

        /// <summary>
        /// Operation ID
        /// </summary>
        public long OperationId { get; set; }

        /// <summary>
        /// Operation Code
        /// </summary>
        [StringLength(100)]
        public string OperationCode { get; set; }

        /// <summary>
        /// Operation Name
        /// </summary>
        [StringLength(255)]
        public string OperationName { get; set; }
        /// <summary>
        /// Operation Description
        /// </summary>
        [StringLength(500)]
        public string OperationDescription { get; set; }
        
        /// <summary>
        /// Department ID
        /// </summary>
        [ForeignKey("Department"), Required]
        public long DepartmentId { get; set; }
        
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

        #region Reference Properties
        
        /// <summary>
        /// Department Reference
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// FleetPools performing this operation
        /// </summary>
        public virtual ICollection<FleetPool> FleetPools { get; set; }

        /// <summary>
        /// Operations Workplaces that use this workspace
        /// </summary>
        public virtual ICollection<OperationsWorkPlace> OperationsWorkPlaces { get; set; } 

        #endregion
    }
}
