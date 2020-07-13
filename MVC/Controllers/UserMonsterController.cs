using Data;
using Microsoft.AspNet.Identity;
using Models.MonsterModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class UserMonsterController : Controller
    {
        private UserMonsterService CreateUserMonsterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new UserMonsterService(userId);
        }
        // GET: UserMonster
        public ActionResult Index()
        {
            var userMonsterService = CreateUserMonsterService();
            var model = userMonsterService.GetAllUserMonsters();
            return View(model);
        }
        // GET: UserMonster/Create
        public ActionResult Create()
        {
            var model = new MonsterCreate();
            return View(model);
        }
        // POST: UserMonster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonsterCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userMonsterService = CreateUserMonsterService();
            if (userMonsterService.Create(model))
            {
                TempData["SaveResult"] = "Monster Created!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an error creating your monster.");
            return View(model);
        }
        // GET: UserMonster/Details/{id}
        public ActionResult Details(int id)
        {
            var userMonsterService = CreateUserMonsterService();
            var model = userMonsterService.GetMonsterDetailById(id);

            return View(model);
        }
        // GET: UserMonster/Edit/{id}
        public ActionResult Edit(int id)
        {
            var userMonsterService = CreateUserMonsterService();
            var detail = userMonsterService.GetMonsterDetailById(id);
            var model = new MonsterEdit()
            {
                Id = detail.Id,
                Name = detail.Name,
                Size = detail.Size,
                Type = detail.Type,
                Alignment = detail.Alignment,
                ArmorClass = detail.ArmorClass,
                ArmorType = detail.ArmorType,
                HitPoints = detail.HitPoints,
                HitPointEquation = detail.HitPointEquation,
                Speed = detail.Speed,
                Strength = detail.Strength,
                Dexterity = detail.Strength,
                Constitution = detail.Constitution,
                Intelligence = detail.Intelligence,
                Wisdom = detail.Wisdom,
                Charisma = detail.Charisma,
                SavingThrows = detail.SavingThrows,
                Skills = detail.Skills,
                Vulnerabilities = detail.Vulnerabilities,
                Resistances = detail.Resistances,
                Immunities = detail.Immunities,
                Senses = detail.Senses,
                Languages = detail.Languages,
                ChallengeRating = detail.ChallengeRating,
                Traits = detail.Traits,
                Actions = detail.Actions,
                Reactions = detail.Reactions,
                NumberOfLegendaryActions = detail.NumberOfLegendaryActions,
                LegendaryActions = detail.LegendaryActions,
                LairActions = detail.LegendaryActions
            };
            return View(model);
        }
        // POST: UserMonster/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MonsterEdit model, int id)
        {
            if (!ModelState.IsValid)
                return View(model);
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var userMonsterService = CreateUserMonsterService();
            if(userMonsterService.Edit(model))
            {
                TempData["SaveResult"] = "Monster Updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Monster was not updated");
            return View(model);
        }
        // GET: UserMonster/Delete/{id}
        public ActionResult Delete(int id)
        {
            var userMonsterService = CreateUserMonsterService();
            var model = userMonsterService.GetMonsterDetailById(id);
            return View(model);
        }
        // POST: UserMonster/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var userMonsterService = CreateUserMonsterService();
            userMonsterService.Delete(id);
            TempData["SaveResult"] = "Monster Deleted!";
            return RedirectToAction("Index");
        }
    }
}