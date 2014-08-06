﻿using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Phone Mapper
    /// </summary>
    public static class PhoneMapper
    {
        #region Public
        /// <summary>
        ///  Create domain model from web api model
        /// </summary>
        public static DomainModel.Phone CreateFrom(this ApiModel.Phone source)
        {
            return new DomainModel.Phone
            {
                PhoneId = source.PhoneId != null ? (long)source.PhoneId : 0,
                IsDefault = source.IsDefault,
                PhoneNumber = source.PhoneNumber,
                PhoneTypeId = source.PhoneTypeId,
                BusinessPartnerId = source.BusinessPartnerId
            };
        }
        /// <summary>
        ///  Create Web Api model from domain model
        /// </summary>
        public static ApiModel.Phone CreateFrom(this DomainModel.Phone source)
        {
            return new ApiModel.Phone
            {
                PhoneId = source.PhoneId,
                IsDefault = source.IsDefault,
                PhoneNumber = source.PhoneNumber,
                PhoneTypeId = source.PhoneTypeId,
                PhoneTypeName = source.PhoneType != null ? (source.PhoneType.PhoneTypeCode + '-' + source.PhoneType.PhoneTypeName) : string.Empty,
                BusinessPartnerId = source.BusinessPartnerId
            };
        }
        #endregion
    }
}