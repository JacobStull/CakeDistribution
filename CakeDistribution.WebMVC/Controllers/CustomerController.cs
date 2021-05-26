using CakeDistribution.Models.Customer;
using CakeDistribution.Services.Customer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CakeDistribution.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = new CustomerListItem[0];
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
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid)  return View(model);

            var service = CreateCustomerService();

            service.CreateCustomer(model);

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Your customer was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your customer could not be saved.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);
            return View(model);
        }

        //Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Address = detail.Address
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
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
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();
            service.DeleteCustomer(id);
            TempData["SaveResult"] = "Your Customer was deleted.";
            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}
