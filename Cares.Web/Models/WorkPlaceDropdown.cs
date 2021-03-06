﻿

namespace Cares.Web.Models
{
    /// <summary>
    /// Work place dropdown 
    /// </summary>
    public class WorkPlaceDropdown
    {
        /// <summary>
        /// Work Place Id
        /// </summary>
        public long WorkPlaceId { get; set; }

        /// <summary>
        /// Work Place Code Name
        /// </summary>
        public string WorkPlaceCodeName { get; set; }

        /// <summary>
        /// Department Id
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        public long CompanyId { get; set; }
    }
}