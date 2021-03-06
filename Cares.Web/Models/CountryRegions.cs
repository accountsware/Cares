﻿using System.Collections.Generic;

namespace Cares.Web.Models
{
    /// <summary>
    /// Fleet Pool Base Data Response
    /// </summary>
    public class CountryRegions
    {
        #region Public
        /// <summary>
        /// List of Regions
        /// </summary>
        public IEnumerable<RegionDropDown> Regions { get; set; }
        #endregion
    }
}