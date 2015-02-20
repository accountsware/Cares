﻿using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Insurance Rate Repository
    /// </summary>
    public sealed class InsuranceRtRepository : BaseRepository<InsuranceRt>, IInsuranceRtRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRtRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<InsuranceRt> DbSet
        {
            get
            {
                return db.InsuranceRts;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get Insurance Rate Report data
        /// </summary>
        public IEnumerable<InsuranceRateReportResponse> GetInsuranceRateReportData()
        {
            var insuranceRateReportResponseQuery = from insuranceRt in db.InsuranceRts
                    join tarrifType in db.TariffTypes.Where(tt => tt.UserDomainKey == UserDomainKey) on
                    new {insuranceRt.InsuranceRtMain.TariffTypeCode} equals new {tarrifType.TariffTypeCode}
                                                   where (insuranceRt.UserDomainKey == UserDomainKey && tarrifType.UserDomainKey == UserDomainKey)
                select new InsuranceRateReportResponse
                {
                    InsuranceTypeCode = insuranceRt.InsuranceType.InsuranceTypeCode,
                    OperationCode = tarrifType.Operation.OperationCode,
                    TarrifTypeCode = insuranceRt.InsuranceRtMain.TariffTypeCode,
                    HireGroupCode = insuranceRt.HireGroupDetail.HireGroup.HireGroupCode,
                    VehicleMakeCode = insuranceRt.HireGroupDetail.VehicleMake.VehicleMakeCode,
                    VehicleModelCode = insuranceRt.HireGroupDetail.VehicleModel.VehicleModelCode,
                    VehicelCategoryCode = insuranceRt.HireGroupDetail.VehicleCategory.VehicleCategoryCode,
                    ModelYear = insuranceRt.HireGroupDetail.ModelYear,
                    RevisionNumber = insuranceRt.RevisionNumber,
                    InsuranceRate = insuranceRt.InsuranceRate,
                    StartDate = insuranceRt.StartDt
                };
            return insuranceRateReportResponseQuery.OrderBy(responseObject => responseObject.InsuranceTypeCode);

        }


        /// <summary>
        /// Get All Insurance Rate for User Domain Key
        /// </summary>
        public override IEnumerable<InsuranceRt> GetAll()
        {
            return DbSet.Where(insuranceRt => insuranceRt.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Insurance Rate By Insurance Rate MainI d
        /// </summary>
        /// <param name="insuranceRtMainId"></param>
        /// <returns></returns>
        public IEnumerable<InsuranceRt> GetInsuranceRtByInsuranceRtMainId(long insuranceRtMainId)
        {
            return DbSet.Where(insuranceRt => insuranceRt.UserDomainKey == UserDomainKey && insuranceRt.InsuranceRtMainId == insuranceRtMainId).ToList();
        }

        /// <summary>
        /// Get Insurance Rate for Ra Billing
        /// </summary>
        public IEnumerable<InsuranceRt> GetForRaBilling(string tariffTypeCode, long hireGroupDetailId, long insuranceTypeId,
            DateTime raRecCreatedDate)
        {
            return
                DbSet.Include(ir => ir.InsuranceRtMain).Where(ir => ir.UserDomainKey == UserDomainKey && !ir.IsDeleted && ir.HireGroupDetailId == hireGroupDetailId &&
                        ir.StartDt <= raRecCreatedDate && ir.InsuranceTypeId == insuranceTypeId && ir.InsuranceRtMain.TariffTypeCode == tariffTypeCode)
                        .OrderByDescending(ir => ir.RevisionNumber).ToList();
        }

        /// <summary>
        /// Get Insurance Rate for Ra
        /// </summary>
        public IEnumerable<InsuranceRt> GetAllForRa()
        {
            return DbSet.Where(ir => ir.UserDomainKey == UserDomainKey && !ir.IsDeleted && ir.ChildInsuranceRtId == null).ToList();
        }


        /// <summary>
        /// Association check B/W Insurance Type and Insurance RT
        /// </summary>
        public bool IsInsuranceTypeAssociatedWithInsuranceRt(long insuranceTypeId)
        {
            return DbSet.Count(insuranceRt => insuranceRt.InsuranceTypeId == insuranceTypeId && insuranceRt.UserDomainKey == UserDomainKey) > 0;
        }

        /// <summary>
        /// Get Available Insurance Rate ForWebApi
        /// </summary>
        public IEnumerable<WebApiAvailableInsurance> GetAvailableInsuranceRtForWebApi(string tarrifTypeCode,
            DateTime startDt,
            long userDomainKey)
        {
            var query = from insurances in db.InsuranceRts
                join
                    insuranceRtMain in db.InsuranceRtMains on
                    new {insurances.InsuranceRtMainId} equals new {insuranceRtMain.InsuranceRtMainId}
                where
                    (insuranceRtMain.TariffTypeCode.Equals(tarrifTypeCode) && insurances.UserDomainKey == userDomainKey &&
                     insurances.StartDt <= startDt)
                select new WebApiAvailableInsurance
                {
                    InsuranceRate = (insuranceRtMain.InsuranceRates
                        .Where(rate => rate.StartDt <= startDt)
                        .OrderBy(rate => rate.RevisionNumber)
                        .FirstOrDefault()) != null
                        ? insuranceRtMain.InsuranceRates.
                            Where(rate => rate.StartDt <= startDt)
                            .OrderBy(rate => rate.RevisionNumber)
                            .FirstOrDefault()
                            .InsuranceRate
                        : 0,
                    InsuranceTypeId = insurances.InsuranceTypeId,
                    InsuranceTypeName = insurances.InsuranceType.InsuranceTypeName,
                    TariffTypeName = insuranceRtMain.TariffTypeCode, // name is not available here
                };
            return query.OrderBy(insurances => insurances.InsuranceRate).ToList();
        }
        #endregion
    }
}
