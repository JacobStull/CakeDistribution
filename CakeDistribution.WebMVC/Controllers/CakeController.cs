
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
            var service = CreateCakeService();
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
            if (!ModelState.IsValid) return View(model);

            var service = CreateCakeService();

            service.CreateCake(model);

            if (service.CreateCake(model))
            {
                TempData["SaveResult"] = "Your cake was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your cake could not be saved.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCakeService();
            var model = svc.GetCakeById(id);
            return View(model);
        }
        //Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCakeService();
            var detail = service.GetCakeById(id);
            var model =
                new CakeEdit
                {
                    CakeId = detail.CakeId,
                    CakeName = detail.CakeName,
                    CakeIcing = detail.CakeIcing,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CakeEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if(model.CakeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCakeService();

            if (service.UpdateCake(model))
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
            var svc = CreateCakeService();
            var model = svc.GetCakeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCakeService();
            service.DeleteCake(id);
            TempData["SaveResult"] = "Your Cake was deleted.";
            return RedirectToAction("Index");
        }


        private CakeService CreateCakeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CakeService(userId);
            return service;
        }
    }
}