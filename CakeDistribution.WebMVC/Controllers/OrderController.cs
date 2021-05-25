using CakeDistribution.Models.Order;
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
            var model = new OrderlistItem[0];
            return View(model);
        }
        //Get
        public ActionResult Create()
        {
            return View();
        }
    }

}