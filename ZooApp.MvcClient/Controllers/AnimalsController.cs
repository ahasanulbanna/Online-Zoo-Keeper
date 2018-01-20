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
    public class AnimalsController : Controller
    {
        // GET: Animals
        AnimalService service = new AnimalService();
        public ActionResult Index()
        {
           
            var viewAnimal = service.getAll();
            return View(viewAnimal);
        }

        public ActionResult Details(int Id)
        {
            ViewAnimal animal = service.Get(Id);
            return View(animal);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            bool save = service.Save(animal);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Animal animal = service.GetDbModel(id);
            return View(animal);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            bool save = service.update(animal);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Animal aniaml = service.GetDbModel(id);
            return View(aniaml);
        }
        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            bool save = service.Delete(animal);
            return RedirectToAction("Index");
        }
    }
}