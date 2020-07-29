using Data;
using Microsoft.Ajax.Utilities;
using Models.BackgroundModels;
using PagedList;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BackgroundController : Controller
    {
        private readonly BackgroundService _backgroundService;
        public BackgroundController()
        {
            _backgroundService = new BackgroundService();
        }
        [AllowAnonymous]
        // GET: Background
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Name = String.IsNullOrEmpty(sortOrder) ? "nameDescending" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var model = _backgroundService.GetAllBackgrounds();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.Name.ToLower().Contains(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "nameDescending":
                    model = model.OrderByDescending(m => m.Name);
                    break;
                default: // Name ascending
                    model = model.OrderBy(m => m.Name);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }
        // GET: Background/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Background/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BackgroundCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(_backgroundService.Create(model))
            {
                TempData["SaveResult"] = "Background Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an error creating the background");
            return View(model);
        }
        // GET: Background/Edit/{id}
        public ActionResult Edit(int id)
        {
            var background = _backgroundService.GetBackgroundById(id);
            var model = new BackgroundEdit()
            {
                Id = background.Id,
                Name = background.Name,
                SkillProficiencies = background.SkillProficiencies
            };
            return View(model);
        }
        // POST: Background/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BackgroundEdit model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if (_backgroundService.Edit(model))
            {
                TempData["SaveResult"] = "Background Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an error updating the background");
            return View(model);
        }
        // POST: Background/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _backgroundService.Delete(id);
            TempData["SaveResult"] = "Background Deleted";
            return RedirectToAction("Index");
        }

        // GET: Background/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _backgroundService.GetBackgroundById(id);
            return View(model);
        }
    }
}