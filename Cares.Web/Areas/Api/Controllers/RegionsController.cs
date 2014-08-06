﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Web;
using Interfaces.IServices;

namespace Cares.Web.Areas.Api.Controllers
{
    public class RegionsController : ApiController
    {

        #region Private
        private readonly ICountryRegionsService countryRegionsService;
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionsController(ICountryRegionsService countryRegionsservice)
        {
            if (countryRegionsservice == null)
            {
                throw new ArgumentNullException("countryRegionsservice");
            }
            this.countryRegionsService = countryRegionsservice;
        }

        #endregion


        #region Public
        // GET api/<controller>
        public IEnumerable<Region> Get(int countryId)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            var abc = countryRegionsService.GetCoutryRegion(countryId);
            IEnumerable<Region> abcd = abc.Select(x => x.CreateFrom());
            return abcd;
        }
        #endregion

    }
}