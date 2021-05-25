
using CakeDistribution.Models.Cake;
using CakeDistribution.Services.Cake;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CakeDistribution.WebMVC.Controllers
{
    public class CakeController : Controller
    {
        // GET: Cake
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CakeService(userId);
            var model = new CakeListItem[0];
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
        public ActionResult Create(CakeCreate model)
        {
            if (ModelState.IsValid)
            {
            return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CakeService(userId);

            service.CreateCake(model);
            return RedirectToAction("Index");
        }

    }
}