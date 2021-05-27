using CakeDistribution.Models.Dessert;
using CakeDistribution.Services.Dessert;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CakeDistribution.WebMVC.Controllers
{
    public class DessertController : Controller
    {
        
        // GET: Dessert
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateDessertService();
            var model = service.GetDesserts();
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
        public ActionResult Create(DessertCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateDessertService();



            if (service.CreateDessert(model))
            {
                TempData["SaveResult"] = "Your Dessert was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Dessert could not be saved.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDessertService();
            var model = svc.GetDessertById(id);
            return View(model);
        }

        //Edit
        public ActionResult Edit(int id)
        {
            var service = CreateDessertService();
            var detail = service.GetDessertById(id);
            var model =
                new DessertEdit
                {
                    DessertId = detail.DessertId,
                    DessertName = detail.DessertName
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DessertEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DessertId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDessertService();

            if (service.UpdateDessert(model))
            {
                TempData["SaveResults"] = "Your Dessert was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Dessert could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDessertService();
            var model = svc.GetDessertById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDessertService();
            service.DeleteDessert(id);
            TempData["SaveResult"] = "Your Dessert was deleted.";
            return RedirectToAction("Index");
        }

        private DessertService CreateDessertService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DessertService(userId);
            return service;
        }

    }
}