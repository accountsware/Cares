﻿namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Status Web Model
    /// </summary>
    public class VehicleStatus
    {
        #region Public Properties
        
        /// <summary>
        /// Vehicle Status ID
        /// </summary>
        public short VehicleStatusId { get; set; }

        /// <summary>
        /// Vehicle Status Key
        /// </summary>
        public short? VehicleStatusKey { get; set; }

        /// <summary>
        /// Vehicle Status Code
        /// </summary>
        public string VehicleStatusCode { get; set; }

        /// <summary>
        /// Vehicle Status Name
        /// </summary>
        public string VehicleStatusName { get; set; }

        /// <summary>
        /// Vehicle Status Description
        /// </summary>
        public string VehicleStatusDescription { get; set; }

        /// <summary>
        /// Vehicle Status Code Name
        /// </summary>
        public string VehicleStatusCodeName
        {
            get
            {
                return string.Format("{0}-{1}", VehicleStatusCode, VehicleStatusName);
            }
        }

        #endregion
    }
}