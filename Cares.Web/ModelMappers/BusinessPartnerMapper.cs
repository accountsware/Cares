﻿using System.Collections.Generic;
using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    public static class BusinessPartnerMapper
    {
        #region Business Partner Mappers

        /// <summary>
        ///  Create listview web api model from domain model
        /// </summary>
        public static Models.BusinessPartnerListView CreateFrom(this BusinessPartner source)
        {
            return new Models.BusinessPartnerListView
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerListId = (source.IsIndividual ? "I" : "C") + "-" + source.BusinessPartnerId,
                BusinessPartnerListName = source.BusinessPartnerName,
                BusinessPartnerName = (source.IsIndividual ? "I" : "C") + "-" + source.BusinessPartnerId + '-' + source.BusinessPartnerName,
                IsIndividual = source.IsIndividual ? "Individual" : "Company",
                BPRatingTypeName = source.BPRatingType != null ? source.BPRatingType.BpRatingTypeCode + '-' + source.BPRatingType.BpRatingTypeName : "",
                CompanyName = source.Company.CompanyCode + '-' + source.Company.CompanyName
            };

        }

        /// <summary>
        ///  Create dropdown web api model from domain model
        /// </summary>
        public static Models.BusinessPartnerDropDown CreateDropDownModelFrom(this BusinessPartner source)
        {
            return new Models.BusinessPartnerDropDown
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerCodeName = source.BusinessPartnerCode + " - " + source.BusinessPartnerName
            };

        }

        /// <summary>
        ///  Create detail web api model from domain model
        /// </summary>
        public static Models.BusinessPartnerDetail CreateApiDetailFromDomainModel(this BusinessPartner source)
        {
            return new Models.BusinessPartnerDetail
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption,
                IsIndividual = source.IsIndividual,
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                PaymentTermId = source.PaymentTermId,
                BPRatingTypeId = source.BPRatingTypeId,
                BusinessPartnerCode = source.BusinessPartnerCode,
                BusinessPartnerEmailAddress = source.BusinessPartnerEmailAddress,
                BusinessPartnerIsValid = source.BusinessPartnerIsValid,
                CompanyId = source.CompanyId,
                DealingEmployeeId = source.DealingEmployeeId,
                IsSystemGuarantor = source.IsSystemGuarantor,
                NonSystemGuarantor = source.NonSystemGuarantor,
                SystemGuarantorId = source.SystemGuarantorId,
                BusinessPartnerIndividual = source.BusinessPartnerIndividual.CreateFrom(),
                BusinessPartnerCompany = source.BusinessPartnerCompany.CreateFrom(),
                BusinessPartnerInTypes = source.BusinessPartnerInTypes.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerPhoneNumbers = source.BusinessPartnerPhoneNumbers.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerAddressList = source.BusinessPartnerAddressList.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerMarketingChannels = source.BusinessPartnerMarketingChannels.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerRelationshipItemList = source.BusinessPartnerRelationshipItemList.Select(x => x.CreateFrom()).ToList()
            };
        }

        /// <summary>
        ///  Create detail web api model from domain model
        /// </summary>
        public static Models.BusinessPartnerDetail CreateFromForRa(this BusinessPartner source)
        {
            if (source == null)
            {
                return null;
            }

            return new Models.BusinessPartnerDetail
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption,
                IsIndividual = source.IsIndividual,
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                PaymentTermId = source.PaymentTermId,
                BPRatingTypeId = source.BPRatingTypeId,
                BusinessPartnerCode = source.BusinessPartnerCode,
                BusinessPartnerEmailAddress = source.BusinessPartnerEmailAddress,
                BusinessPartnerIsValid = source.BusinessPartnerIsValid,
                CompanyId = source.CompanyId,
                DealingEmployeeId = source.DealingEmployeeId,
                IsSystemGuarantor = source.IsSystemGuarantor,
                NonSystemGuarantor = source.NonSystemGuarantor,
                SystemGuarantorId = source.SystemGuarantorId,
                BusinessPartnerIndividual = source.BusinessPartnerIndividual != null ? source.BusinessPartnerIndividual.CreateFrom() : new ApiModel.BusinessPartnerIndividual(),
                BusinessPartnerCompany = source.BusinessPartnerCompany != null ? source.BusinessPartnerCompany.CreateFrom() : new ApiModel.BusinessPartnerCompany(),
                BusinessPartnerPhoneNumbers = source.BusinessPartnerPhoneNumbers != null ? source.BusinessPartnerPhoneNumbers.Select(x => x.CreateFrom()).ToList() : new List<ApiModel.Phone>(),
                BusinessPartnerAddressList = source.BusinessPartnerAddressList != null ? source.BusinessPartnerAddressList.Select(x => x.CreateFrom()).ToList() : new List<ApiModel.Address>(),
                PaymentTerm = source.PaymentTerm != null ? source.PaymentTerm.CreateFrom() : null
            };
        }

        /// <summary>
        ///  Create domain model from  web api listview model
        /// </summary>
        public static BusinessPartner CreateFrom(this Models.BusinessPartnerListView source)
        {
            return new BusinessPartner
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
            };
        }

        /// <summary>
        ///  Create domain model from  web api detail model
        /// </summary>
        public static BusinessPartner CreateFrom(this Models.BusinessPartnerDetail source)
        {
            return new BusinessPartner
            {
                BusinessPartnerId = source.BusinessPartnerId.HasValue ? (long)source.BusinessPartnerId : 0,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption,
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                NonSystemGuarantor = source.NonSystemGuarantor,
                IsIndividual = source.IsIndividual,
                IsSystemGuarantor = source.IsSystemGuarantor,
                SystemGuarantorId = source.SystemGuarantorId,
                PaymentTermId = source.PaymentTermId,
                BPRatingTypeId = source.BPRatingTypeId,
                DealingEmployeeId = source.DealingEmployeeId,
                CompanyId = source.CompanyId,
                BusinessPartnerIsValid = true,
                BusinessPartnerEmailAddress = source.BusinessPartnerEmailAddress,
                BusinessPartnerIndividual = source.BusinessPartnerIndividual != null ? source.BusinessPartnerIndividual.CreateFrom() : new BusinessPartnerIndividual(),
                BusinessPartnerCompany = source.BusinessPartnerCompany != null ? source.BusinessPartnerCompany.CreateFrom() : new BusinessPartnerCompany(),
                BusinessPartnerInTypes = source.BusinessPartnerInTypes != null  ? source.BusinessPartnerInTypes.Select(x => x.CreateFrom()).ToList() : new List<BusinessPartnerInType>(),
                BusinessPartnerPhoneNumbers = source.BusinessPartnerPhoneNumbers != null ? source.BusinessPartnerPhoneNumbers.Select(x => x.CreateFrom()).ToList() : new List<Phone>(),
                BusinessPartnerAddressList = source.BusinessPartnerAddressList != null ? source.BusinessPartnerAddressList.Select(x => x.CreateFrom()).ToList() : new List<Address>(),
                BusinessPartnerMarketingChannels = source.BusinessPartnerMarketingChannels != null ? 
                source.BusinessPartnerMarketingChannels.Select(x => x.CreateFrom()).ToList() : new List<BusinessPartnerMarketingChannel>(),
                BusinessPartnerRelationshipItemList = source.BusinessPartnerRelationshipItemList != null ? 
                source.BusinessPartnerRelationshipItemList.Select(x => x.CreateFrom()).ToList() : new List<BusinessPartnerRelationship>()
            };
        }

        #endregion

        #region Business Patner Response Mapper

        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static Models.BusinessPartnerSearchResponse CreateFrom(this  BusinessPartnerSearchResponse source)
        {
            return new Models.BusinessPartnerSearchResponse
            {
                TotalCount = source.TotalCount,
                BusinessPartners = source.BusinessPartners.Select(p => p.CreateFrom())
            };
        }
        #endregion

        #region Business Partner Base Date Response Mapper

        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static Models.BusinessPartnerBaseResponse CreateFrom(this BusinessPartnerBaseDataResponse source)
        {
            return new Models.BusinessPartnerBaseResponse
            {
                ResponseBPRatingTypes = source.ResponseBPRatingTypes.Select(x => x.CreateFrom()),
                ResponsePaymentTerms = source.ResponsePaymentTerms.Select(x => x.CreateFrom()),
                ResponseBusinessPartners = source.ResponseBusinessPartners.Select(x => x.CreateDropDownModelFrom()),
                ResponseCompanies = source.ResponseCompanies.Select(x => x.CreateFrom()),
                ResponseDealingEmployees = source.ResponseDealingEmployees.Select(x => x.CreateFrom()),
                ResponseBusinessLegalStatuses = source.ResponseBusinessLegalStatuses.Select(x => x.CreateFrom()),
                ResponseBusinessPartnerCompanies = source.ResponseBusinessPartnerCompanies.Select(x => x.CreateFrom()),
                ResponseOccupationTypes = source.ResponseOccupationTypes.Select(x => x.CreateFrom()),
                ResponseCountries = source.ResponseCountries.Select(x => x.CreateFrom()),
                ResponseBusinessSegments = source.ResponseBusinessSegments.Select(x => x.CreateFrom()),
                ResponseBusinessPartnerSubTypes = source.ResponseBusinessPartnerSubTypes.Select(x => x.CreateFrom()),
                ResponsePhoneTypes = source.ResponsePhoneTypes.Select(x => x.CreateFrom()),
                ResponseAddressTypes = source.ResponseAddressTypes.Select(x => x.CreateFrom()),
                ResponseMarketingChannels = source.ResponseMarketingChannels.Select(x => x.CreateFrom()),
                ResponseBusinessPartnerRelationshipTypes = source.ResponseBusinessPartnerRelationshipTypes.Select(x => x.CreateFrom()),
                ResponseRegions = source.ResponseRegions.Select(x=>x.CreateFrom()),
                ResponseSubRegions = source.ResponseSubRegions.Select(x=>x.CreateFrom()),
                ResponseCities = source.ResponseCities.Select(x=>x.CreateFrom()),
                ResponseAreas = source.ResponseAreas.Select(x=>x.CreateFrom())
            };
        }
        #endregion

        #region Business Partner Individual Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerIndividual CreateFrom(this BusinessPartnerIndividual source)
        {
            if (source == null)
            {
                return null;
            }

            return new ApiModel.BusinessPartnerIndividual
            {
                BusinessPartnerId = source.BusinessPartnerId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                GenderStatus = source.GenderStatus,
                Initials = source.Initials,
                IqamaExpiryDate = source.IqamaExpiryDate,
                DateOfBirth = source.DateOfBirth,
                CompanyAddress = source.CompanyAddress,
                CompanyPhone = source.CompanyPhone,
                BusinessPartnerCompanyId = source.BusinessPartnerCompanyId,
                CompanyName = source.CompanyName,
                TaxRegisterationCode = source.TaxRegisterationCode,
                TaxNumber = source.TaxNumber,
                PassportNumber = source.PassportNumber,
                PassportExpiryDate = source.PassportExpiryDate,
                PassportCountryId = source.PassportCountryId,
                OccupationTypeId = source.OccupationTypeId,
                NicNumber = source.NicNumber,
                NicExpiryDate = source.LiscenseExpiryDate,
                LiscenseNumber = source.LiscenseNumber,
                LiscenseExpiryDate = source.LiscenseExpiryDate,
                MiddleName = source.MiddleName,
                MaritalStatusCode = source.MaritalStatusCode,
                IsCompanyExternal = source.IsCompanyExternal,
                IqamaNo = source.IqamaNo
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerIndividual CreateFrom(this ApiModel.BusinessPartnerIndividual source)
        {
            if (source == null)
            {
                return null;
            }

            return new BusinessPartnerIndividual
            {
                BusinessPartnerId = source.BusinessPartnerId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                GenderStatus = source.GenderStatus,
                Initials = source.Initials,
                IqamaExpiryDate = source.IqamaExpiryDate,
                DateOfBirth = source.DateOfBirth,
                CompanyAddress = source.CompanyAddress,
                CompanyPhone = source.CompanyPhone,
                BusinessPartnerCompanyId = source.BusinessPartnerCompanyId,
                CompanyName = source.CompanyName,
                TaxRegisterationCode = source.TaxRegisterationCode,
                TaxNumber = source.TaxNumber,
                PassportNumber = source.PassportNumber,
                PassportExpiryDate = source.PassportExpiryDate,
                PassportCountryId = source.PassportCountryId,
                OccupationTypeId = source.OccupationTypeId,
                NicNumber = source.NicNumber,
                NicExpiryDate = source.LiscenseExpiryDate,
                LiscenseNumber = source.LiscenseNumber,
                LiscenseExpiryDate = source.LiscenseExpiryDate,
                MiddleName = source.MiddleName,
                MaritalStatusCode = source.MaritalStatusCode,
                IsCompanyExternal = source.IsCompanyExternal,
                IqamaNo = source.IqamaNo
            };
        }

        #endregion

        #region Business Partner Company Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerCompany CreateFrom(this BusinessPartnerCompany source)
        {
            if (source == null)
            {
                return new ApiModel.BusinessPartnerCompany();
            }

            return new ApiModel.BusinessPartnerCompany
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerCompanyCode = source.BusinessPartnerCompanyCode,
                BusinessPartnerCompanyName = source.BusinessPartnerCompanyName,
                BusinessPartnerCompanyCodeName = source.BusinessPartnerCompanyCode + " - "+source.BusinessPartnerCompanyName,
                BusinessSegmentId = source.BusinessSegmentId,
                AccountNumber = source.AccountNumber,
                EstablishedSince = source.EstablishedSince,
                SwiftCode = source.SwiftCode
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerCompany CreateFrom(this ApiModel.BusinessPartnerCompany source)
        {
            if (source == null)
            {
                return null;
            }

            return new BusinessPartnerCompany
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerCompanyCode = source.BusinessPartnerCompanyCode,
                BusinessPartnerCompanyName = source.BusinessPartnerCompanyName,
                BusinessSegmentId = source.BusinessSegmentId,
                AccountNumber = source.AccountNumber,
                EstablishedSince = source.EstablishedSince,
                SwiftCode = source.SwiftCode
            };
        }

        #endregion

        #region Business Partner SubType Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerSubTypeDropDown CreateFrom(this BusinessPartnerSubType source)
        {
            return new ApiModel.BusinessPartnerSubTypeDropDown
            {
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                BusinessPartnerSubTypeCodeName = source.BusinessPartnerSubTypeCode + " - " + source.BusinessPartnerSubTypeName,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerSubType CreateFrom(this ApiModel.BusinessPartnerSubTypeDropDown source)
        {
            return new BusinessPartnerSubType
            {
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                BusinessPartnerSubTypeName = source.BusinessPartnerSubTypeCodeName
            };
        }

        #endregion

        #region Business Partner InType Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerInType CreateFrom(this BusinessPartnerInType source)
        {
            if (source == null)
            {
                return null;
            }

            return new ApiModel.BusinessPartnerInType
                   {
                       BusinessPartnerInTypeId = source.BusinessPartnerInTypeId,
                       BusinessPartnerInTypeDescription = source.BusinessPartnerInTypeDescription,
                       BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                       BusinessPartnerSubTypeName =
                           source.BusinessPartnerSubType != null
                               ? (source.BusinessPartnerSubType.BusinessPartnerSubTypeCode + '-' +
                                  source.BusinessPartnerSubType.BusinessPartnerSubTypeName)
                               : string.Empty,
                       FromDate = source.FromDate,
                       ToDate = source.ToDate,
                       BusinessPartnerId = source.BusinessPartnerId > 0 ? source.BusinessPartnerId : 0,
                       BpRatingTypeId = source.BpRatingTypeId,
                       BpRatingTypeName =
                           source.BpRatingType != null
                               ? (source.BpRatingType.BpRatingTypeCode + '-' + source.BpRatingType.BpRatingTypeName)
                               : string.Empty
                   };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerInType CreateFrom(this ApiModel.BusinessPartnerInType source)
        {
            if (source == null)
            {
                return null;
            }

            return new BusinessPartnerInType
            {
                BusinessPartnerInTypeId = source.BusinessPartnerInTypeId != null ? (long)source.BusinessPartnerInTypeId : 0,
                BusinessPartnerInTypeDescription = source.BusinessPartnerInTypeDescription,
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                FromDate = source.FromDate,
                ToDate = source.ToDate,
                BusinessPartnerId = source.BusinessPartnerId != null ? (long)source.BusinessPartnerId : 0,
                BpRatingTypeId = source.BpRatingTypeId
            };
        }

        #endregion

        #region Business Partner Marketing Channel Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerMarketingChannel CreateFrom(this BusinessPartnerMarketingChannel source)
        {
            if (source == null)
            {
                return null;
            }

            return new ApiModel.BusinessPartnerMarketingChannel
            {
                BusinessPartnerMarketingChannelId = source.BusinessPartnerMarketingChannelId,
                MarketingChannelId = source.MarketingChannelId,
                MarketingChannelName = source.MarketingChannel != null ? (source.MarketingChannel.MarketingChannelCode + "-" + source.MarketingChannel.MarketingChannelName) : string.Empty,
                BusinessPartnerId = source.BusinessPartnerId
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerMarketingChannel CreateFrom(this ApiModel.BusinessPartnerMarketingChannel source)
        {
            if (source == null)
            {
                return null;
            }

            return new BusinessPartnerMarketingChannel
            {
                BusinessPartnerMarketingChannelId = source.BusinessPartnerMarketingChannelId != null ? (long)source.BusinessPartnerMarketingChannelId : 0,
                MarketingChannelId = source.MarketingChannelId,
                BusinessPartnerId = source.BusinessPartnerId != null ? (long)source.BusinessPartnerId : 0
            };
        }

        #endregion

        #region Business Partner Relationship Types Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerRelationshipTypeDropDown CreateFrom(this BusinessPartnerRelationshipType source)
        {
            return new ApiModel.BusinessPartnerRelationshipTypeDropDown
            {
                BusinessPartnerRelationshipTypeId = source.BusinessPartnerRelationshipTypeId,
                BusinessPartnerRelationshipTypeCodeName = source.BusinessPartnerRelationshpTypeCode + " - " + source.BusinessPartnerRelationshipTypeName
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerRelationshipType CreateFrom(
            this ApiModel.BusinessPartnerRelationshipTypeDropDown source)
        {
            if (source == null)
            {
                return null;
            }

            return new BusinessPartnerRelationshipType
                   {
                       BusinessPartnerRelationshipTypeId = source.BusinessPartnerRelationshipTypeId,
                       BusinessPartnerRelationshipTypeName = source.BusinessPartnerRelationshipTypeCodeName
                   };
        }
        #endregion

        #region Business Partner Relationship Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerRelationship CreateFrom(this BusinessPartnerRelationship source)
        {
            if (source == null)
            {
                return null;
            }

            return new ApiModel.BusinessPartnerRelationship
            {
                BusinessPartnerRelationshipTypeId = source.BusinessPartnerRelationshipTypeId,
                BusinessPartnerRelationshipTypeName = source.BusinessPartnerRelationshipType != null ?
                (source.BusinessPartnerRelationshipType.BusinessPartnerRelationshpTypeCode + " - " +
                source.BusinessPartnerRelationshipType.BusinessPartnerRelationshipTypeName) : string.Empty,
                BusinessPartnerId = source.BusinessPartnerId,
                SecondaryBusinessPartnerId = source.SecondaryBusinessPartnerId,
                SecondaryBusinessPartnerCodeName = source.SecondaryBusinessPartner != null?
                source.SecondaryBusinessPartner.BusinessPartnerCode + " - "+ source.SecondaryBusinessPartner.BusinessPartnerName: string.Empty,
                BusinessPartnerRelationshipId = source.BusinessPartnerRelationshipId
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerRelationship CreateFrom(
            this ApiModel.BusinessPartnerRelationship source)
        {
            if (source == null)
            {
                return null;
            }

            return new BusinessPartnerRelationship
            {
                BusinessPartnerRelationshipId = source.BusinessPartnerRelationshipId != null ? (int)source.BusinessPartnerRelationshipId : 0,
                BusinessPartnerId = source.BusinessPartnerId != null ? (long)source.BusinessPartnerId : 0,
                BusinessPartnerRelationshipTypeId = source.BusinessPartnerRelationshipTypeId,
                SecondaryBusinessPartnerId = source.SecondaryBusinessPartnerId
            };
        }
        #endregion
    }
}
