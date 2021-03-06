﻿using Cares.Models.Common;

namespace Cares.Models.RequestModels
{
    /// <summary>
    /// Tariff Rate Request Domain Model
    /// </summary>
    public sealed class TariffRateSearchRequest : GetPagedListRequest
    {
        /// <summary>
        /// Tariff Rate Id
        /// </summary>
        public int? TariffTypeId { get; set; }        
        
        /// <summary>
        /// Operation Id
        /// </summary>
        public long? OperationId { get; set; }
        
        /// <summary>
        /// tariff Rate Order By
        /// </summary>
        public TariffRateByColumn TariffRateByOrder
        {
            get
            {
                return (TariffRateByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
