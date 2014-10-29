﻿using System.Collections.Generic;
using Cares.Interfaces.IReportServices;
using Cares.Interfaces.Repository;
using Cares.Models.ReportModels;
using Cares.Repository.Repositories;

namespace Cares.Implementation.ReportServices
{
    /// <summary>
    /// 
    /// </summary>
    public class DailyActionService : IDailyActionService
    {
        #region Private

        private readonly IRentalAgreementRepository rentalAgreementRepository;

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public DailyActionService(IRentalAgreementRepository rentalAgreementRepository)
        {
            this.rentalAgreementRepository = rentalAgreementRepository;
        }

        #endregion
        #region Public

        public IList<DailyActionReportResponse> LoadDailyActionReportDetail()
        {
            return rentalAgreementRepository.GetDailyActionReport();

        }

        #endregion

    }
}