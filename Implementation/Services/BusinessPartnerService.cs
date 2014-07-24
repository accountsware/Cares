﻿using System;
using System.Globalization;
using Castle.MicroKernel.Registration;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
{
    /// <summary>
    /// Business Partner Service
    /// </summary>
    public class BusinessPartnerService : IBusinessPartnerService
    {
        #region Private
        private readonly IBusinessPartnerRepository businessPartnerRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerService(IBusinessPartnerRepository businessPartnerRepository)
        {
            this.businessPartnerRepository = businessPartnerRepository;
        }

        #endregion

        #region Public
        /// <summary>
        /// Load All Business Partners
        /// </summary>
        public BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest)
        {
            return businessPartnerRepository.GetAllBusinessPartners(businessPartnerSearchRequest);
        }
        /// <summary>
        /// Find business partner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartner FindBusinessPartner(int id)
        {
            return businessPartnerRepository.Find(id);
        }
        /// <summary>
        /// Delete Business Partner
        /// </summary>
        /// <param name="businessPartner"></param>
        public void DeleteBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = FindBusinessPartner((int)businessPartner.BusinessPartnerId);
            if (businessPartnerDbVersion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Business Partner with Id {0} not found!", businessPartner.BusinessPartnerId));
            }
            businessPartnerRepository.Delete(businessPartnerDbVersion);
            businessPartnerRepository.SaveChanges();
        }
        /// <summary>
        /// Add business partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        public bool AddBusinessPartner(BusinessPartner businessPartner)
        {
            if (ValidateBusinessPartner(businessPartner))
            {
                //set master (business partner) properties
                businessPartner.BusinessPartnerCode = "BP-Screen";
                businessPartner.UserDomainKey = businessPartnerRepository.UserDomainKey;
                businessPartner.IsActive = true;
                businessPartner.IsDeleted = false;
                businessPartner.IsPrivate = false;
                businessPartner.IsReadOnly = false;
                businessPartner.RecCreatedDt = DateTime.Now;
                businessPartner.RecLastUpdatedDt = DateTime.Now;
                businessPartner.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.RowVersion = 0;

                //set child (business partner individual) properties
                businessPartner.BusinessPartnerIndividual.RecCreatedBy =
                    businessPartner.BusinessPartnerIndividual.RecLastUpdatedBy =
                        businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.BusinessPartnerIndividual.RecCreatedDt =
                    businessPartner.BusinessPartnerIndividual.RecLastUpdatedDt =
                        DateTime.Now;
                businessPartner.BusinessPartnerIndividual.UserDomainKey = businessPartnerRepository.UserDomainKey;

                //set child (business partner company) properties
                businessPartner.BusinessPartnerCompany.RecCreatedBy =
                    businessPartner.BusinessPartnerCompany.RecLastUpdatedBy =
                        businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.BusinessPartnerCompany.RecCreatedDt =
                    businessPartner.BusinessPartnerCompany.RecLastUpdatedDt =
                        DateTime.Now;
                businessPartner.BusinessPartnerCompany.UserDomainKey = businessPartnerRepository.UserDomainKey;

                // save data
                businessPartnerRepository.Add(businessPartner);
                businessPartnerRepository.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Validate Business Partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        private bool ValidateBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = businessPartnerRepository.GetBusinessPartnerByName(businessPartner.BusinessPartnerName, (int)businessPartner.BusinessPartnerId);
            return businessPartnerDbVersion == null;
        }
        /// <summary>
        /// Update business partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        public bool UpdateBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = FindBusinessPartner((int)businessPartner.BusinessPartnerId);
            if (businessPartnerDbVersion != null)
            {
                // set master(business partner) properties
                businessPartnerDbVersion.BusinessPartnerName = businessPartner.BusinessPartnerName;
                businessPartnerDbVersion.BusinessPartnerDesciption = businessPartner.BusinessPartnerDesciption;
                businessPartnerDbVersion.IsSystemGuarantor = businessPartner.IsSystemGuarantor;
                businessPartnerDbVersion.NonSystemGuarantor = businessPartner.NonSystemGuarantor;
                businessPartnerDbVersion.IsIndividual = businessPartner.IsIndividual;
                businessPartnerDbVersion.BusinessPartnerEmailAddress = businessPartner.BusinessPartnerEmailAddress;
                businessPartnerDbVersion.CompanyId = businessPartner.CompanyId;
                businessPartnerDbVersion.SystemGuarantorId = businessPartner.SystemGuarantorId;
                businessPartnerDbVersion.BusinessLegalStatusId = businessPartner.BusinessLegalStatusId;
                businessPartnerDbVersion.DealingEmployeeId = businessPartner.DealingEmployeeId;
                businessPartnerDbVersion.PaymentTermId = businessPartner.PaymentTermId;
                businessPartnerDbVersion.BPRatingTypeId = businessPartner.BPRatingTypeId;
                
                businessPartnerDbVersion.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                businessPartnerDbVersion.RowVersion = businessPartnerDbVersion.RowVersion + 1;

                //set child (buiness partner individual properties)
                businessPartnerDbVersion.BusinessPartnerIndividual.BusinessPartnerId = businessPartner.BusinessPartnerIndividual.BusinessPartnerId;
                businessPartnerDbVersion.BusinessPartnerIndividual.FirstName = businessPartner.BusinessPartnerIndividual.FirstName;
                businessPartnerDbVersion.BusinessPartnerIndividual.MiddleName = businessPartner.BusinessPartnerIndividual.MiddleName;
                businessPartnerDbVersion.BusinessPartnerIndividual.LastName = businessPartner.BusinessPartnerIndividual.LastName;
                businessPartnerDbVersion.BusinessPartnerIndividual.Initials = businessPartner.BusinessPartnerIndividual.Initials;
                businessPartnerDbVersion.BusinessPartnerIndividual.GenderStatus = businessPartner.BusinessPartnerIndividual.GenderStatus;
                businessPartnerDbVersion.BusinessPartnerIndividual.MaritalStatusCode = businessPartner.BusinessPartnerIndividual.MaritalStatusCode;
                businessPartnerDbVersion.BusinessPartnerIndividual.OccupationTypeId = businessPartner.BusinessPartnerIndividual.OccupationTypeId;
                businessPartnerDbVersion.BusinessPartnerIndividual.LastName = businessPartner.BusinessPartnerIndividual.LastName;
                businessPartnerDbVersion.BusinessPartnerIndividual.DateOfBirth = businessPartner.BusinessPartnerIndividual.DateOfBirth;
                businessPartnerDbVersion.BusinessPartnerIndividual.NicNumber = businessPartner.BusinessPartnerIndividual.NicNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.NicExpiryDate = businessPartner.BusinessPartnerIndividual.NicExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.IqamaNo = businessPartner.BusinessPartnerIndividual.IqamaNo;
                businessPartnerDbVersion.BusinessPartnerIndividual.IqamaExpiryDate = businessPartner.BusinessPartnerIndividual.IqamaExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportNumber = businessPartner.BusinessPartnerIndividual.PassportNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportExpiryDate = businessPartner.BusinessPartnerIndividual.PassportExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportCountryId = businessPartner.BusinessPartnerIndividual.PassportCountryId;
                businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseNumber = businessPartner.BusinessPartnerIndividual.LiscenseNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseExpiryDate = businessPartner.BusinessPartnerIndividual.LiscenseExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.TaxRegisterationCode = businessPartner.BusinessPartnerIndividual.TaxRegisterationCode;
                businessPartnerDbVersion.BusinessPartnerIndividual.TaxNumber = businessPartner.BusinessPartnerIndividual.TaxNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.IsCompanyExternal = businessPartner.BusinessPartnerIndividual.IsCompanyExternal;
                businessPartnerDbVersion.BusinessPartnerIndividual.BusinessPartnerCompnayId = businessPartner.BusinessPartnerIndividual.BusinessPartnerCompnayId;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyName = businessPartner.BusinessPartnerIndividual.CompanyName;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyPhone = businessPartner.BusinessPartnerIndividual.CompanyPhone;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyAddress = businessPartner.BusinessPartnerIndividual.CompanyAddress;

                businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion = businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion + 1;
                businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;

                //set child (buiness partner company properties)
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerId = businessPartner.BusinessPartnerId;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyCode =
                    businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyCode;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyName =
                    businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyName;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessSegmentId =
                    businessPartner.BusinessPartnerCompany.BusinessSegmentId;
                businessPartnerDbVersion.BusinessPartnerCompany.AccountNumber =
                    businessPartner.BusinessPartnerCompany.AccountNumber;
                businessPartnerDbVersion.BusinessPartnerCompany.EstablishedSince =
                    businessPartner.BusinessPartnerCompany.EstablishedSince;
                businessPartnerDbVersion.BusinessPartnerCompany.SwiftCode =
                    businessPartner.BusinessPartnerCompany.SwiftCode;

                businessPartnerDbVersion.BusinessPartnerCompany.RowVersion =
                    businessPartnerDbVersion.BusinessPartnerCompany.RowVersion + 1;
                businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;

                // save changes
                businessPartnerRepository.SaveChanges();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Get Business Partner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartner FindBusinessPartnerById(long id)
        {
            return businessPartnerRepository.GetById(id);
        }
        #endregion




    }
}
