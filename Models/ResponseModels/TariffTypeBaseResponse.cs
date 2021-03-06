﻿using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// tariff Type Base Response
    /// </summary>
    public sealed class TariffTypeBaseResponse
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffTypeBaseResponse()
        {
            Companies = new List<Company>();
            MeasurementUnits = new List<MeasurementUnit>();
            Departments = new List<Department>();
            Operations = new List<Operation>();
            PricingStrategies = new List<PricingStrategy>();
        }
        #endregion
       
        #region Public
        /// <summary>
        /// Companies
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }
        /// <summary>
        /// Measurement Unit 
        /// </summary>
        public IEnumerable<MeasurementUnit> MeasurementUnits { get; set; }
        /// <summary>
        /// Departments 
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }
        /// <summary>
        /// Operations 
        /// </summary>
        public IEnumerable<Operation> Operations { get; set; }
        /// <summary>
        /// List of Pricing Strategies
        /// </summary>
        public IEnumerable<PricingStrategy> PricingStrategies { get; set; }

        #endregion
    }
}
