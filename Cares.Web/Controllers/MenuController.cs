﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cares.Implementation.Identity;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Web.ViewModels.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Cares.Web.Controllers
{
    /// <summary>
    /// Menu Controller to load menu items
    /// </summary>
    public class MenuController : Controller
    {
        // ReSharper disable InconsistentNaming
        private readonly IMenuRightsService menuRightService;
        // ReSharper restore InconsistentNaming
        
        /// <summary>
        /// Menu Controller Constructure
        /// </summary>
        /// <param name="menuRightService"></param>
        public MenuController(IMenuRightsService menuRightService)
        {
            this.menuRightService = menuRightService;
        }
        
        /// <summary>
        /// User Manger for logged in user credientals
        /// </summary>
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        /// <summary>
        /// Load Menu items with respect to roles
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult LoadMenu()
        {
            MenuViewModel menuVM = new MenuViewModel();
            //string userName = HttpContext.User.Identity.Name;
            //if (!String.IsNullOrEmpty(userName))
            //{
                //ApplicationUser userResult = UserManager.FindByEmail(userName);
                //IList<IdentityUserRole> roles = userResult.Roles.ToList();
                //if (roles.Count > 0)
                //{
            IQueryable<MenuRight> menuItems = menuRightService.FindMenuItemsByRoleId("73953B69-8C5A-458F-A75B-399EF9E16371");

                    //save menu items in session
                    //Session["UserPermissionSet"] = menuItems;

            menuVM = new MenuViewModel
                        {
                            MenuRights = menuItems,
                            MenuHeaders = menuItems.Where(x => x.Menu.IsRootItem)
                        };
                //}
            //}
            return View(menuVM);
        }
	}
}