using CakeDistribution.Models.Employee;
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
            var service = CreateEmployeeService();
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
            if (!ModelState.IsValid) return View(model);
            

            var service = CreateEmployeeService();

            service.CreateEmployee(model);

            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Your employee was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your employee could not be saved.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);
            return View(model);
        }

        //Edit
        public ActionResult Edit(int id)
        {
            var service = CreateEmployeeService();
            var detail = service.GetEmployeeById(id);
            var model =
                new EmployeeEdit
                {
                    EmployeeId = detail.EmployeeId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    JobTitle = detail.JobTitle
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EmployeeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEmployeeService();

            if (service.UpdateEmployee(model))
            {
                TempData["SaveResults"] = "Your Cake was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Cake could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmployeeService();
            service.DeleteEmployee(id);
            TempData["SaveResult"] = "Your Employee was deleted.";
            return RedirectToAction("Index");
        }

        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }

    }
}