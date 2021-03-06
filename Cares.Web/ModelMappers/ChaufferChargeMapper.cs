﻿using System.Linq;
using DomainModel = Cares.Models.DomainModels;
using DomainResponseModel = Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Chauffer Charge Mapper
    /// </summary>
    public static class ChaufferChargeMapper
    {

        #region Public
        /// <summary>
        /// Domain Model To Web Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.ChaufferChargeMainContent CreateFrom(this DomainResponseModel.ChaufferChargeMainContent source)
        {
            return new ApiModel.ChaufferChargeMainContent
            {
                ChaufferChargeMainId = source.ChaufferChargeMainId,
                Code = source.Code,
                Name = source.Name,
                CompanyId = source.CompanyId,
                CompanyCodeName = source.CompanyCodeName,
                DepartmentId = source.DepartmentId,
                OperationId = source.OperationId,
                OperationCodeName = source.OperationCodeName,
                TariffTypeId = source.TariffTypeId,
                TariffTypeCodeName = source.TariffTypeCodeName,
                Description = source.Description,
                StartDate = source.StartDate,
            };
        }

        /// <summary>
        /// Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.ChaufferChargeMain CreateFrom(this ApiModel.ChaufferChargeMain source)
        {
            return new DomainModel.ChaufferChargeMain
            {
                ChaufferChargeMainId = source.ChaufferChargeMainId,
                ChaufferChargeMainCode = source.Code,
                ChaufferChargeMainName = source.Name,
                TariffTypeCode = source.TariffTypeId.ToString(),
                ChaufferChargeMainDescription = source.Description,
                StartDt = source.StartDate,
                ChaufferCharges = source.ChaufferCharges!=null?source.ChaufferCharges.Select(c => c.CreateFrom()).ToList():null
            };
        }

        /// <summary>
        /// Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.ChaufferCharge CreateFrom(this ApiModel.ChaufferCharge source)
        {
            return new DomainModel.ChaufferCharge
            {
                ChaufferChargeId = source.ChaufferChargeId,
                DesigGradeId = source.DesigGradeId,
                ChaufferChargeRate = source.ChaufferChargeRate,
                StartDt = source.StartDt,
            };
        }

        /// <summary>
        /// Domain Model To Web Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.ChaufferCharge CreateFrom(this DomainModel.ChaufferCharge source)
        {
            return new ApiModel.ChaufferCharge
            {
                ChaufferChargeId = source.ChaufferChargeId,
                DesigGradeId = source.DesigGradeId,
                DesigGradeCodeName = source.DesigGrade != null ? source.DesigGrade.DesigGradeCode + " - " + source.DesigGrade.DesigGradeName : string.Empty,
                ChaufferChargeRate = source.ChaufferChargeRate,
                StartDt = source.StartDt,
                RevisionNumber = source.RevisionNumber,
            };
        }

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.ChaufferChargeSearchResponse CreateFrom(this DomainResponseModel.ChaufferChargeSearchResponse source)
        {
            return new ApiModel.ChaufferChargeSearchResponse
            {
                ChaufferChargeMains = source.ChaufferChargeMains.Select(c => c.CreateFrom()).ToList(),
                TotalCount = source.TotalCount
            };
        }
        #endregion

        #region  Base Data Response

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.ChaufferChargeBaseResponse CreateFrom(this DomainResponseModel.ChaufferChargeBaseResponse source)
        {
            return new ApiModel.ChaufferChargeBaseResponse
            {
                Companies = source.Companies.Select(c => c.CreateFrom()).ToList(),
                Departments = source.Departments.Select(c => c.CreateFrom()).ToList(),
                Operations = source.Operations.Select(c => c.CreateFrom()).ToList(),
                TariffTypes = source.TariffTypes.Select(c => c.CreateFromDropDown()).ToList(),
                DesigGrades = source.DesigGrades.Select(c => c.CreateFrom()).ToList(),

            };
        }
        #endregion
    }
}