﻿using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Business Parnter Base Data Domain Model
    /// </summary>
    public class BusinessPartnerBaseDataResponse
    {
        #region Public Properties
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> ResponseCompanies { get; set; }
        /// <summary>
        /// Payment Terms
        /// </summary>
        public IEnumerable<PaymentTerm> ResponsePaymentTerms { get; set; }
        /// <summary>
        /// Business Partner Payment Types 
        /// </summary>
        public IEnumerable<BpRatingType> ResponseBPRatingTypes { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<BusinessLegalStatus> ResponseBusinessLegalStatuses { get; set; }
        /// <summary>
        /// System Guarnator 
        /// </summary>
        public IEnumerable<BusinessPartner> ResponseBusinessPartners { get; set; }
        /// <summary>
        /// Dealing Employees 
        /// </summary>
        public IEnumerable<Employee> ResponseDealingEmployees { get; set; }
        /// <summary>
        /// Occupation Types
        /// </summary>
        public IEnumerable<OccupationType> ResponseOccupationTypes { get; set; }
        /// <summary>
        /// Business Partner Companies 
        /// </summary>
        public IEnumerable<BusinessPartnerCompany> ResponseBusinessPartnerCompanies { get; set; }
        /// <summary>
        /// Countries
        /// </summary>
        public IEnumerable<Country> ResponseCountries { get; set; }
        /// <summary>
        /// Business Segments
        /// </summary>
        public IEnumerable<BusinessSegment> ResponseBusinessSegments { get; set; }
        /// <summary>
        /// Business Partner SubTypes
        /// </summary>
        public IEnumerable<BusinessPartnerSubType> ResponseBusinessPartnerSubTypes { get; set; }
        /// <summary>
        /// Phone Types
        /// </summary>
        public IEnumerable<PhoneType> ResponsePhoneTypes { get; set; }
        /// <summary>
        /// Address Types
        /// </summary>
        public IEnumerable<AddressType> ResponseAddressTypes { get; set; }
        /// <summary>
        /// Marketing Channels
        /// </summary>
        public IEnumerable<MarketingChannel> ResponseMarketingChannels { get; set; }
        /// <summary>
        /// Business Partner Relationship Types
        /// </summary>
        public IEnumerable<BusinessPartnerRelationshipType> ResponseBusinessPartnerRelationshipTypes { get; set; }
        /// <summary>
        /// Regions
        /// </summary>
        public IEnumerable<Region> ResponseRegions { get; set; }
        /// <summary>
        /// Sub Regions
        /// </summary>
        public IEnumerable<SubRegion> ResponseSubRegions { get; set; }
        /// <summary>
        /// Cities 
        /// </summary>
        public IEnumerable<City> ResponseCities { get; set; }
        /// <summary>
        /// Areas
        /// </summary>
        public IEnumerable<Area> ResponseAreas { get; set; }
        #endregion
    }
}
