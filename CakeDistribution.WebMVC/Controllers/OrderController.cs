using CakeDistribution.Models.Order;
using CakeDistribution.Services.Order;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CakeDistribution.WebMVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateOrderService();
            var model = service.GetOrders();
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
        public ActionResult Create(OrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateOrderService();



            if (service.CreateOrder(model))
            {
                TempData["SaveResult"] = "Your Order was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Order could not be saved.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);
            return View(model);
        }

        //Edit
        public ActionResult Edit(int id)
        {
            var service = CreateOrderService();
            var detail = service.GetOrderById(id);
            var model =
                new OrderEdit
                {
                    OrderId = detail.OrderId,
                    ModifiedUtc = detail.ModifiedUtc,
                    CreatedUtc = detail.CreatedUtc,
                    ItemOrdered = detail.ItemOrdered
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrderId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateOrderService();

            if (service.UpdateOrder(model))
            {
                TempData["SaveResults"] = "Your Order was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Order could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOrderService();
            service.DeleteOrder(id);
            TempData["SaveResult"] = "Your Order was deleted.";
            return RedirectToAction("Index");
        }

        private OrderService CreateOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            return service;
        }

    }
}
