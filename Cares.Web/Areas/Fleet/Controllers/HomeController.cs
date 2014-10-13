﻿using System.Web.Mvc;

namespace Cares.Web.Areas.Fleet.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /FleetPool/Home/
        public ActionResult Index()
        {
            return View();
        }
       
        //
        // GET: /HireGroup/Home/
        public ActionResult HireGroup()
        {
            return View();
        }

        // GET: /Vehicle/Home/
        public ActionResult Vehicle()
        {
            return View();
        }

        public ActionResult VehicleCheckList()
        {
            return View();
        }

        public ActionResult MaintenanceTypeGroup()
        {
            return View();
        }
        public ActionResult MaintenanceType()
        {
            return View();
        }
        public ActionResult InsuranceType()
        {
            return View();
        }
        public ActionResult VehicleMake()
        {
            return View();
        }
        public ActionResult VehicleCategory()
        {
            return View();
        }
        public ActionResult VehicleModel()
        {
            return View();
        }
        public ActionResult VehicleStatus()
        {
            return View();
        }
	}
}