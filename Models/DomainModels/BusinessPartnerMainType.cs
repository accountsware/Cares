﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.DomainModels
{
    /// <summary>
    /// Business Partner Main Type Domain Model
    /// </summary>
    public class BusinessPartnerMainType
    {
        #region Persisted Properties
        
        /// <summary>
        /// BusinessPartner MainType ID
        /// </summary>
        public int BusinessPartnerMainTypeId { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType Code
        /// </summary>
        [StringLength(100)]
        [Required]
        public string BusinessPartnerMainTypeCode { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType Key
        /// </summary>
        public int BusinessPartnerMainTypeKey { get; set; }
        
        /// <summary>
        /// BusinessPartner MainType Name
        /// </summary>
        [StringLength(255)]
        public string BusinessPartnerMainTypeName { get; set; }

        /// <summary>
        /// BusinessPartner MainType Description
        /// </summary>
        [StringLength(500)]
        public string BusinessPartnerMainTypeDescription { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }

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
        [Required]
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Business Partner Sub Type
        /// </summary>
        public ICollection<BusinessPartnerSubType> BusinessPartnerSubTypes { get; set; }

        #endregion
    }
}
