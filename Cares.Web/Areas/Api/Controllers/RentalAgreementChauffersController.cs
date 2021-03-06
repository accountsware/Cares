﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.Common;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Chauffers Api Controller
    /// </summary>
    public class RentalAgreementChauffersController : ApiController
    {
        #region Private

        private readonly IEmployeeService employeeService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementChauffersController(IEmployeeService employeeService)
        {
            if (employeeService == null)
            {
                throw new ArgumentNullException("employeeService");
            }
            this.employeeService = employeeService;
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Get All Chauffers
        /// </summary>
        public IEnumerable<Chauffer> Post(GetRaChaufferRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            request.DesignationKey = (long)DesignationEnum.Chauffer;
            return employeeService.GetAllChauffers(request).Select(hg => hg.CreateChaufferFrom());
        }

        #endregion
    }
}