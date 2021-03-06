﻿using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Employee Job Info Repository
    /// </summary>
    public interface IEmpJobInfoRepository : IBaseRepository<EmpJobInfo, long>
    {
        /// <summary>
        /// To check the asssociation of design grade and emp job info 
        /// </summary>
        bool IsEmpJobInfoAssociatedWithDesignGrade(long designGradeId);

        /// <summary>
        /// To check the asssociation of Designation and emp job info 
        /// </summary>
        bool IsEmpJobInfoAssociatedWithDesignation(long designationId);

        /// <summary>
        /// To check the asssociation of Job Type and emp job info 
        /// </summary>
        bool IsEmpJobInfoAssociatedWithJobType(long jobTypeId);
    }
}
