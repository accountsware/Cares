﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DomainModels
{
    /// <summary>
    /// Business Parnter In Type Domain Model
    /// </summary>
    public class BusinessPartnerInType
    {
        #region Persisted Properties
        /// <summary>
        /// Business Partner In Type Id
        /// </summary>
        [Key, Column(Order = 2), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BusinessPartnerInTypeId { get; set; }
        /// <summary>
        /// Business Partner In Type Description
        /// </summary>
        [StringLength(500)]
        public string BusinessPartnerInTypeDescription { get; set; }
        /// <summary>
        /// Business Partner In Type From Date
        /// </summary>
        public DateTime? FromDate { get; set; }
        /// <summary>
        /// Business Partner In Type To Date
        /// </summary>
        public DateTime? ToDate { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        [Key, ForeignKey("BusinessPartner"), Column(Order = 1)]
        public long BusinessPartnerId { get; set; }
        /// <summary>
        /// Business Partner Sub Type Id
        /// </summary>
        [Required]
        public int BusinessPartnerSubTypeId { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        [Required]
        public long RowVersion { get; set; }
        /// <summary>
        /// Business Partner Rating Type Id
        /// </summary>
        public int? BpRatingTypeId { get; set; }
        /// <summary>
        /// User Domain Key
        /// </summary>
        [Required]
        public long UserDomainKey { get; set; }
        
        #endregion

        #region Reference Properties
      
        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }
        
        /// <summary>
        /// Business Partner Rating Type
        /// </summary>
        public virtual BpRatingType BpRatingType { get; set; }

        /// <summary>
        /// Business Partner Sub Type
        /// </summary>
        public virtual BusinessPartnerSubType BusinessPartnerSubType { get; set; }
        
        #endregion
    }
}
