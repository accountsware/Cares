﻿using System;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Additional Charge Service
    /// </summary>
    public class AdditionalChargeService : IAdditionalChargeService
    {
        #region Private
        /// <summary>
        /// Private members
        /// </summary>
        private readonly IAdditionalChargeRepository additionalChargeRepository;
        private readonly IAdditionalChargeTypeRepository additionalChargeTypeRepository;
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        #endregion

        #region Constructor
        /// <summary>
        ///  Constructor
        /// </summary>
        public AdditionalChargeService(IAdditionalChargeRepository additionalChargeRepository, IAdditionalChargeTypeRepository additionalChargeTypeRepository,
         IHireGroupDetailRepository hireGroupDetailRepository)
        {
            this.additionalChargeRepository = additionalChargeRepository;
            this.additionalChargeTypeRepository = additionalChargeTypeRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Load Additional Charge Base data
        /// </summary>
        public AdditionalChargeBaseResponse GetBaseData()
        {
            return new AdditionalChargeBaseResponse
            {
                HireGroupDetails = hireGroupDetailRepository.GetAll(),
            };
        }

        /// <summary>
        /// Load Additional Charge Based on search criteria
        /// </summary>
        /// <returns></returns>
        public AdditionalChargeSearchResponse LoadAll(AdditionalChargeSearchRequest request)
        {
            return additionalChargeTypeRepository.GetAdditionalCharges(request);
        }

        /// <summary>
        /// Save Additional Charge
        /// </summary>
        /// <param name="additionalChargeType"></param>
        /// <returns></returns>
        public AdditionalChargeType SaveAdditionalCharge(AdditionalChargeType additionalChargeType)
        {
            AdditionalChargeType additionalChargeTypeDbVersion =
                additionalChargeTypeRepository.Find(additionalChargeType.AdditionalChargeTypeId);
            if (additionalChargeTypeDbVersion == null) //Add Case
            {
                additionalChargeType.IsActive = true;
                additionalChargeType.IsDeleted = additionalChargeType.IsPrivate = additionalChargeType.IsReadOnly = false;
                additionalChargeType.RecLastUpdatedBy = additionalChargeType.RecCreatedBy = additionalChargeTypeRepository.LoggedInUserIdentity;
                additionalChargeType.RecCreatedDt = additionalChargeType.RecLastUpdatedDt = DateTime.Now;
                additionalChargeType.RowVersion = 0;
                additionalChargeType.AdditionalChargeKey = 0;
                additionalChargeType.UserDomainKey = additionalChargeTypeRepository.UserDomainKey;

                if (additionalChargeType.AdditionalCharges != null)
                {
                    foreach (var item in additionalChargeType.AdditionalCharges)
                    {
                        item.IsActive = true;
                        item.IsDeleted = item.IsPrivate = item.IsReadOnly = false;
                        item.RecLastUpdatedBy = item.RecCreatedBy = additionalChargeTypeRepository.LoggedInUserIdentity;
                        item.RecCreatedDt = item.RecLastUpdatedDt = DateTime.Now;
                        item.RowVersion = 0;
                        item.RevisionNumber = 0;
                        item.UserDomainKey = additionalChargeTypeRepository.UserDomainKey;
                    }
                }
                additionalChargeTypeRepository.Add(additionalChargeType);
                additionalChargeTypeRepository.SaveChanges();
            }
            else //Update Case
            {
                additionalChargeTypeDbVersion.RecLastUpdatedBy = additionalChargeTypeRepository.LoggedInUserIdentity;
                additionalChargeTypeDbVersion.RecLastUpdatedDt = DateTime.Now;

                additionalChargeTypeRepository.SaveChanges();
            }
            return new AdditionalChargeType
            {
                AdditionalChargeTypeId = additionalChargeType.AdditionalChargeTypeId,
                AdditionalChargeTypeCode = additionalChargeType.AdditionalChargeTypeCode,
                AdditionalChargeTypeName = additionalChargeType.AdditionalChargeTypeName,
                AdditionalChargeTypeDescription = additionalChargeType.AdditionalChargeTypeDescription,
                IsEditable = additionalChargeType.IsEditable,
            };

        }

        /// <summary>
        /// Delete Additional Charge
        /// </summary>
        /// <param name="additionalChargeType"></param>
        public void DeleteAdditionalCharge(AdditionalChargeType additionalChargeType)
        {
            additionalChargeTypeRepository.Delete(additionalChargeType);
            additionalChargeTypeRepository.SaveChanges();
        }

        /// <summary>
        /// Find Additional Charge By Id
        /// </summary>
        /// <param name="additionalChargeTypeId"></param>
        /// <returns></returns>
        public AdditionalChargeType FindById(long  additionalChargeTypeId)
        {
            return additionalChargeTypeRepository.Find(additionalChargeTypeId);
        }

        #endregion
    }
}
