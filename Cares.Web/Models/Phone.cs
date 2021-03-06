﻿namespace Cares.Web.Models
{
    /// <summary>
    /// Phone Web Api Model
    /// </summary>
    public class Phone
    {
        #region Phone Persisted Properties
        /// <summary>
        /// Phone ID
        /// </summary>
        public long? PhoneId { get; set; }
        /// <summary>
        /// Is Default
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long? BusinessPartnerId { get; set; }
        /// <summary>
        /// Phone Type ID
        /// </summary>
        public short PhoneTypeId { get; set; }
        /// <summary>
        /// Phone Type Key
        /// </summary>
        public short? PhoneTypeKey { get; set; }
        /// <summary>
        /// Phone Type Name
        /// </summary>
        public string PhoneTypeName { get; set; }
        /// <summary>
        /// Work Location ID
        /// </summary>
        public long? WorkLocationId { get; set; }
        #endregion
    }
}