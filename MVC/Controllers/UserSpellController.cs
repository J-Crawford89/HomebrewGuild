using Microsoft.AspNet.Identity;
using Models.SpellModels;
using PagedList;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class UserSpellController : Controller
    {
        private UserSpellService CreateUserSpellService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return  new UserSpellService(userId);
        }
        // GET: UserSpell
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CreatorSortParam = sortOrder == "Creator" ? "creatorDescending" : "Creator";
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "nameDescending" : "";
            ViewBag.SpellLevelSortParam = sortOrder == "SpellLevel" ? "spellLevelDescending" : "SpellLevel";
            ViewBag.RitualSortParam = sortOrder == "Ritual" ? "ritualDescending" : "Ritual";
            ViewBag.ConcentrationSortParam = sortOrder == "Concentration" ? "concentrationDescending" : "Concentration";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var userSpellService = CreateUserSpellService();
            var model = userSpellService.GetAllUserSpells();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.Name.ToLower().Contains(searchString.ToLower()) || e.Creator.ToLower().Contains(searchString.ToLower()));
            }
            switch (sortOrder)
            {
                case "Creator":
                    model = model.OrderBy(m => m.Creator);
                    break;
                case "creatorDescending":
                    model = model.OrderByDescending(m => m.Creator);
                    break;
                case "SpellLevel":
                    model = model.OrderBy(m => m.SpellLevel);
                    break;
                case "spellLevelDescending":
                    model = model.OrderByDescending(m => m.SpellLevel);
                    break;
                case "ritualDescending":
                    model = model.OrderBy(m => m.IsRitual);
                    break;
                case "Ritual":
                    model = model.OrderByDescending(m => m.IsRitual);
                    break;
                case "concentrationDescending":
                    model = model.OrderBy(m => m.RequiresConcentration);
                    break;
                case "Concentration":
                    model = model.OrderByDescending(m => m.RequiresConcentration);
                    break;
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

        // POST: UserSpell/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int itemId)
        {
            var userSpellService = CreateUserSpellService();
            userSpellService.Delete(itemId);
            TempData["SaveResult"] = "Spell Deleted!";
            return RedirectToAction("Index");
        }
        // GET: UserSpell/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: UserSpell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var userSpellService = CreateUserSpellService();
            if (userSpellService.Create(model))
            {
                TempData["SaveResult"] = "Spell Created!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create spell");
            return View(model);
        }
        // GET: UserSpell/Edit/{id}
        public ActionResult Edit(int id)
        {
            var userSpellService = CreateUserSpellService();
            var detail = userSpellService.GetSpellDetailById(id);
            var model = new SpellEdit
            {
                Id = detail.Id,
                CastingTime = detail.CastingTime,
                ClassIds = detail.ClassIds,
                Components = detail.Components,
                Creator = detail.Creator,
                Description = detail.Description,
                Duration = detail.Duration,
                IsRitual = detail.IsRitual,
                Range = detail.Range,
                MaterialComponent = detail.MaterialComponent,
                Name = detail.Name,
                RequiresConcentration = detail.RequiresConcentration,
                School = detail.School,
                SpellLevel = detail.SpellLevel
            };
            return View(model);
        }
        // POST: UserSpell/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SpellEdit model, int id)
        {
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var userSpellService = CreateUserSpellService();
            if(userSpellService.Edit(model))
            {
                TempData["SaveResult"] = "Spell Updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to update spell");
            return View(model);
        }
    }
}