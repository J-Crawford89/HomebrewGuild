using Data;
using Data.Entities;
using Models.SubraceModels;
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
    public class SubraceController : Controller
    {
        private readonly SubraceService _subraceService;
        private readonly ApplicationDbContext _ctx;
        public SubraceController()
        {
            _subraceService = new SubraceService();
            _ctx = new ApplicationDbContext();
        }
        // GET: Subrace
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

            var model = _subraceService.GetAllSubraces();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.Name.Contains(searchString));
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
        // GET: Subrace/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _subraceService.GetSubraceDetailViewById(id);
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
            var races = _ctx.Races.ToList();
            var dropdownList = new SelectList(races.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList(), "Value", "Text");
            var model = new SubraceCreate
            {
                Races = dropdownList
            };
            return View(model);
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
                Traits = detail.Traits,
                RaceId = _ctx.Races.Single(e=>e.Name == detail.RaceName).Id,
                Races = new SelectList(_ctx.Races, "Id", "Name")
            };
            return View(model);
        }
        // POST: Subrace/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubraceEdit model, int id)
        {
            model.Races = new SelectList(_ctx.Races, "Id", "Name");
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