﻿using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Vehicle Leased Info Domain Model
    /// </summary>
    public class VehicleLeasedInfo
    {
        #region Persisted Properties

        /// <summary>
        /// Vehicle ID
        /// </summary>
        public long VehicleId { get; set; }

        /// <summary>
        /// Down Payment
        /// </summary>
        public decimal? DownPayment { get; set; }

        /// <summary>
        /// Leased Start Date
        /// </summary>
        public DateTime? LeasedStartDate { get; set; }

        /// <summary>
        /// Leased Finish Date
        /// </summary>
        public DateTime? LeasedFinishDate { get; set; }

        /// <summary>
        /// Monthly Payment
        /// </summary>
        public decimal? MonthlyPayment { get; set; }

        /// <summary>
        /// Purchased From
        /// </summary>
        public string LeasedFrom { get; set; }

        /// <summary>
        /// Interest Rate
        /// </summary>
        public double? InterestRate { get; set; }

        /// <summary>
        /// Prinicipal Payment
        /// </summary>
        public decimal? PrinicipalPayment { get; set; }

        /// <summary>
        /// First Payment Date
        /// </summary>
        public DateTime? FirstPaymentDate { get; set; }
        
        /// <summary>
        /// Last Month Payment
        /// </summary>
        public decimal? LastMonthPayment { get; set; }

        /// <summary>
        /// Lease To Ownership
        /// </summary>
        public bool? LeaseToOwnership { get; set; }

        /// <summary>
        /// First Month Payment
        /// </summary>
        public decimal? FirstMonthPayment { get; set; }

        /// <summary>
        /// BP Main ID
        /// </summary>
        public long? BPMainId { get; set; }

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
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
         public long UserDomainKey { get; set; }


        #endregion

        #region Reference Properties

        /// <summary>
        /// Vehicle
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Business Partner 
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }

        #endregion
    }
}
