using Data;
using Models.SubclassModels;
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
    public class SubclassController : Controller
    {
        private readonly SubclassService _subclassService;
        private readonly ApplicationDbContext _ctx;
        public SubclassController()
        {
            _subclassService = new SubclassService();
            _ctx = new ApplicationDbContext();
        }
        // GET: Subclass
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

            var model = _subclassService.GetAllSubclasses();
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
        // GET: Subclass/Detail/{id}
        public ActionResult Details(int id)
        {
            var model = _subclassService.GetSubclassDetailById(id);
            return View(model);
        }
        //POST: Subclass/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _subclassService.Delete(id);
            TempData["SaveResult"] = "Subclass deleted";
            return RedirectToAction("Index");
        }
        // GET: Subclass/Create
        public ActionResult Create()
        {
            var classes = _ctx.CharacterClasses.ToList();
            var dropdownList = new SelectList(classes.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList(), "Value", "Text");
            var model = new SubclassCreate
            {
                CharacterClasses = dropdownList
            };
            return View(model);
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
                Name = detail.Name,
                CharacterClassId = _ctx.CharacterClasses.Single(e=>e.Name == detail.CharacterClassName).Id,
                CharacterClasses = new SelectList(_ctx.CharacterClasses, "Id", "Name")
            };
            return View(model);
        }
        // POST: Subclass/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubclassEdit model, int id)
        {
            model.CharacterClasses = new SelectList(_ctx.CharacterClasses, "Id", "Name");
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