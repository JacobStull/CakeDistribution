﻿using CakeDistribution.Models.Employee;
using CakeDistribution.Services.Employee;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CakeDistribution.WebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            var model = new EmployeeListItem[0];
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);

            service.CreateEmployee(model);
            return RedirectToAction("Index");
        }


    }
}