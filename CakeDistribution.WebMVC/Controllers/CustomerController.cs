using CakeDistribution.Models.Customer;
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}
