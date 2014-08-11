﻿using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class RegionMapper
    {
        #region Public

        #region Region
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.Region CreateFrom(this Region source)
        {
            return new ApiModel.Region
            {
                RegionId = source.RegionId,
                RegionCustomId = source.RegionId.ToString()+"-"+source.RegionCode+"-"+source.RegionName,
                RegionCode = source.RegionCode,
                RegionName = source.RegionName,
                Country = source.Country != null ? source.Country.CountryCode + " - " + source.Country.CountryName : string.Empty,
                CountryId = source.CountryId
            };
        }
        #endregion        
        #endregion

        #region Sub Region
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.SubRegion CreateFrom(this SubRegion source)
        {
            return new ApiModel.SubRegion()
            {
                SubRegionId = source.SubRegionId,
                SubRegionCustomId = source.SubRegionId.ToString()+"-"+source.SubRegionCode+"-"+source.SubRegionName,
                SubRegionCode = source.SubRegionCode,
                SubRegionName = source.SubRegionName,
                RegionId = source.RegionId
            };
        }
        #endregion
        #endregion
        
        #endregion
    }
}