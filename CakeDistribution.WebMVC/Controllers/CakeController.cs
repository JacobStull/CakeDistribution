
using CakeDistribution.Models.Cake;
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

            }
            return View(model);
        }

    }
}