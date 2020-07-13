using Models.SubclassModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class SubclassController : Controller
    {
        private readonly SubclassService _subclassService;
        public SubclassController()
        {
            _subclassService = new SubclassService();
        }
        // GET: Subclass
        public ActionResult Index()
        {
            var model = _subclassService.GetAllSubclasses();
            return View(model);
        }
        // GET: Subclass/Detail/{id}
        public ActionResult Details(int id)
        {
            var model = _subclassService.GetSubclassDetailById(id);
            return View(model);
        }
        //GET: Subclass/Delete/{id}
        public ActionResult Delete(int id)
        {
            var model = _subclassService.GetSubclassDetailById(id);
            return View(model);
        }
        // POST: Subclass/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            _subclassService.Delete(id);
            TempData["SaveResult"] = "Subclass deleted";
            return RedirectToAction("Index");
        }
        // GET: Subclass/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Subclass/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubclassCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (_subclassService.Create(model))
            {
                TempData["SaveResult"] = "Subclass created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create subclass");
            return View(model);
        }
        // GET: Subclass/Edit/{id}
        public ActionResult Edit(int id)
        {
            var detail = _subclassService.GetSubclassDetailById(id);
            var model = new SubclassEdit
            {
                Features = detail.Features,
                Id = detail.Id,
                Name = detail.Name
            };
            return View(model);
        }
        // POST: Subclass/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubclassEdit model, int id)
        {
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_subclassService.Edit(model))
            {
                TempData["SaveResult"] = "Subclass updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to update subclass");
            return View(model);
        }
    }
}