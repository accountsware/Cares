﻿using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels.ViewModels;
using System;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Register User Service 
    /// </summary>
    public class RegisterUserService : IRegisterUserService
    {
        #region Private

        private ILicenseDetailsDefaultRepository licenseDetailsDefaultRepository;
        private IDomainLicenseDetailsRepository domainLicenseDetailsRepository;
        private IUserRepository userRepository;

        public RegisterUserService(ILicenseDetailsDefaultRepository licenseDetailsDefaultRepository, IDomainLicenseDetailsRepository domainLicenseDetailsRepository,
            IUserRepository userRepository)
        {
            this.licenseDetailsDefaultRepository = licenseDetailsDefaultRepository;
            this.domainLicenseDetailsRepository = domainLicenseDetailsRepository;
            this.userRepository = userRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Add License Details and return user  domain key
        /// </summary>
        public double AddLicenseDetail(RegisterViewModel userModel)
        {
            LicenseDetailsDefault licenseDetailsDefaultById = licenseDetailsDefaultRepository.GetLicenseDetailsDefaultByTypeId(Convert.ToInt32(userModel.AccountType));
            double maxUserDomainKey = userRepository.GetMaxUserDomainKey();
            #region Adding Domain License Details

            DomainLicenseDetail licenseDetailObject = domainLicenseDetailsRepository.Create();
             
            licenseDetailObject.UserDomainKey = Convert.ToInt64(maxUserDomainKey + 1);
            licenseDetailObject.RaPerMonth = licenseDetailsDefaultById.RaPerMonth;
            licenseDetailObject.Employee = licenseDetailsDefaultById.Employee;
            licenseDetailObject.Branches = licenseDetailsDefaultById.Branches;
            licenseDetailObject.FleetPools = licenseDetailsDefaultById.FleetPools;
            licenseDetailObject.Vehicles = licenseDetailsDefaultById.Vehicles;
            licenseDetailObject.IsActive = true;
            licenseDetailObject.IsDeleted = false;
            licenseDetailObject.IsPrivate = false;
            licenseDetailObject.IsReadOnly = false;
            licenseDetailObject.RecCreatedBy = "";
            licenseDetailObject.RecCreatedDt = DateTime.Now;
            licenseDetailObject.RecLastUpdatedBy = "";
            licenseDetailObject.RecLastUpdatedDt = DateTime.Now;
            domainLicenseDetailsRepository.Add(licenseDetailObject);
            domainLicenseDetailsRepository.SaveChanges();
            #endregion

            return maxUserDomainKey;
        }
        #endregion
    }
}