﻿using System;
using System.Collections.Generic;
namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Hire Group Detail Domain Model
    /// </summary>
    public class HireGroupDetail
    {
        #region Persisted Properties

        /// <summary>
        /// Hire Group Detail Id
        /// </summary>
        public long HireGroupDetailId { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        /// <summary>
        /// Hire Group ID
        /// </summary>
        public long HireGroupId { get; set; }

        /// <summary>
        /// Vehicle Category ID
        /// </summary>
        public short VehicleCategoryId { get; set; }
        /// <summary>
        /// Model Year
        /// </summary>
        public short ModelYear { get; set; }
        /// <summary>
        /// Vehicle Model ID
        /// </summary>
        public short VehicleModelId { get; set; }
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short VehicleMakeId { get; set; }
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
        public string RecLastUpdatedBy { get; set; }
        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        #endregion

        #region Reference Properties
        /// <summary>
        /// Hire Group
        /// </summary>
        public virtual HireGroup HireGroup { get; set; }
        /// <summary>
        /// Vehicle Category
        /// </summary>
        public virtual VehicleCategory VehicleCategory { get; set; }
        /// <summary>
        /// Vehicle Make
        /// </summary>
        public virtual VehicleMake VehicleMake { get; set; }
        /// <summary>
        /// Vehicle Model
        /// </summary>
        public virtual VehicleModel VehicleModel { get; set; }

        /// <summary>
        /// Vehicle Image Hire Group Details Associated to this Hire Group Detail
        /// </summary>
        public virtual ICollection<VehicleImageHireGroupDetail> VehicleImageHireGroupDetails { get; set; }

        /// <summary>
        /// Standard Rates
        /// </summary>
        public virtual ICollection<StandardRate> StandardRates { get; set; }

        /// <summary>
        /// Insurance Rates
        /// </summary>
        public virtual ICollection<InsuranceRt> InsuranceRates { get; set; }

        /// <summary>
        /// Additional Charges
        /// </summary>
        public virtual ICollection<AdditionalCharge> AdditionalCharges { get; set; }

        /// <summary>
        /// Ra HireGroups
        /// </summary>
        public virtual ICollection<RaHireGroup> RaHireGroups { get; set; }

        /// <summary>
        /// RaAdditional Charges
        /// </summary>
        public virtual ICollection<RaAdditionalCharge> RaAdditionalCharges { get; set; }

        #endregion
    }
}
