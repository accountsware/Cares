﻿using System.Web.Mvc;

namespace Cares.Web.Areas.BusinessPartner.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Business Partner Home Controller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DocumentGroup()
        {
            return View();
        }
        public ActionResult BusinessPartnerMainType()
        {
            return View();
        }
        public ActionResult Document()
        {
            return View();
        }
	}
}