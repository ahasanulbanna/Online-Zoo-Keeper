using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class FoodsController : Controller
    {
        // GET: Foods
        FoodService Service = new FoodService();
        public ActionResult Index()
        {
            var viewAnimal = Service.getAll();
            return View(viewAnimal);
        }

        // GET: Foods/Details/5
        public ActionResult Details(int id)
        {
            ViewFood food = Service.Get(id);
            return View(food);
        }

        // GET: Foods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        [HttpPost]
        public ActionResult Create(Food food)
        {
            try
            {
                // TODO: Add insert logic here
                bool save = Service.Save(food);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Foods/Edit/5
        public ActionResult Edit(int id)
        {
            Food food = Service.GetDbModel(id);
            return View(food);
        }

        // POST: Foods/Edit/5
        [HttpPost]
        public ActionResult Edit(Food food)
        {
            try
            {
                // TODO: Add update logic here
                bool save = Service.update(food);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Foods/Delete/5
        public ActionResult Delete(int id)
        {
            Food food = Service.GetDbModel(id);
            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost]
        public ActionResult Delete(Food food)
        {
            try
            {
                bool save = Service.Delete(food);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
