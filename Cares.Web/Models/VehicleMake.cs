﻿namespace Cares.Web.Models
{
    /// <summary>
    /// Vehicle Make Web Model
    /// </summary>
    public class VehicleMake
    {
        #region Public Properties
        /// <summary>
        /// Vehicle Make ID
        /// </summary>
        public short VehicleMakeId { get; set; }
        /// <summary>
        /// Vehicle Make Code
        /// </summary>
        public string VehicleMakeCode { get; set; }
        /// <summary>
        /// Vehicle Make Name
        /// </summary>
        public string VehicleMakeName { get; set; }
        /// <summary>
        /// Vehicle Make Description
        /// </summary>
        public string VehicleMakeDescription { get; set; }

        /// <summary>
        /// VehicleMake Code Name
        /// </summary>
        public string VehicleMakeCodeName
        {
            get
            {
                return string.Format("{0}-{1}", VehicleMakeCode, VehicleMakeName);
            }
        }
        #endregion
    }
}