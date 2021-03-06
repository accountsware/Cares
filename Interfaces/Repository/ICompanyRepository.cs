﻿using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;
namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Company Repository Interface
    /// </summary>
    public interface ICompanyRepository : IBaseRepository<Company, long>
    {
        /// <summary>
        /// Search Company
        /// </summary>
        IEnumerable<Company> SearchCompany(CompanySearchRequest request, out int rowCount);

        /// <summary>
        /// Get Company Details
        /// </summary>
        Company GetCompanyWithDetails(long id);

        /// <summary>
        /// Company Code validation check
        /// </summary>
        bool IsCompanyCodeExists(Company company);


        /// <summary>
        /// To identify if company is parent 
        /// </summary>
        bool IsComapnyParent(long companyId);


        /// <summary>
        /// To identify if OrgGroup contains any company
        /// </summary>
        bool IsOrgGroupContainCompany(long orgGroupId);
        
        /// <summary>
        /// Company association check with business segment
        /// </summary>
        bool IsCompanyAssiciatedWithBusinessSegment(long businessSegId);
    }
}
