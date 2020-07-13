using Microsoft.AspNet.Identity;
using Models.SpellModels;
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
        public ActionResult Index()
        {
            var userSpellService = CreateUserSpellService();
            var model = userSpellService.GetAllUserSpells();
            return View(model);
        }
        // GET: UserSpell/Details/{id}
        public ActionResult Details(int id)
        {
            var userSpellService = CreateUserSpellService();
            var model = userSpellService.GetSpellDetailById(id);
            return View(model);
        }
        // GET: UserSpell/Delete/{id}
        public ActionResult Delete(int id)
        {
            var userSpellService = CreateUserSpellService();
            var model = userSpellService.GetSpellDetailById(id);
            return View(model);
        }
        // POST: UserSpell/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var userSpellService = CreateUserSpellService();
            userSpellService.Delete(id);
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