using Data.Entities;
using Models.SubraceModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class SubraceController : Controller
    {
        private readonly SubraceService _subraceService;
        public SubraceController()
        {
            _subraceService = new SubraceService();
        }
        // GET: Subrace
        public ActionResult Index()
        {
            var model = _subraceService.GetAllSubraces();
            return View(model);
        }
        // GET: Subrace/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _subraceService.GetSubraceDetailById(id);
            return View(model);
        }
        // GET: Subrace/Delete/{id}
        public ActionResult Delete(int id)
        {
            _subraceService.Delete(id);
            TempData["SaveResult"] = "Subrace deleted";
            return RedirectToAction("Index");
        }
        // GET: Subrace/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Subrace/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubraceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(_subraceService.Create(model))
            {
                TempData["SaveResult"] = "Subrace created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create subrace");
            return View(model);
        }
        // GET: Subrace/Edit/{id}
        public ActionResult Edit(int id)
        {
            var detail = _subraceService.GetSubraceDetailById(id);
            var model = new SubraceEdit
            {
                Id = detail.Id,
                AbilityScoreIncrease = detail.AbilityScoreIncrease,
                Name = detail.Name,
                Traits = detail.Traits
            };
            return View(model);
        }
        // POST: Subrace/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubraceEdit model, int id)
        {
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_subraceService.Edit(model))
            {
                TempData["SaveResult"] = "Subrace updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to update subrace");
            return View(model);
        }
    }
}