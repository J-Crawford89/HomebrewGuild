using Microsoft.AspNet.Identity;
using Models.CharacterModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class UserCharacterController : Controller
    {
        private UserCharacterService CreateUserCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new UserCharacterService(userId);
        }
        // GET: UserCharacter
        public ActionResult Index()
        {
            var userCharacterService = CreateUserCharacterService();
            var model = userCharacterService.GetAllUserCharacters();
            return View(model);
        }
        // GET: UserCharacter/Details/{id}
        public ActionResult Details(int id)
        {
            var userCharacterService = CreateUserCharacterService();
            var model = userCharacterService.GetCharacterDetailById(id);
            return View(model);
        }
        // GET: UserCharacter/Delete/{id}
        public ActionResult Delete(int id)
        {
            var userCharacterService = CreateUserCharacterService();
            var model = userCharacterService.GetCharacterDetailById(id);
            return View(model);
        }
        // POST: UserCharacter/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var userCharacterService = CreateUserCharacterService();
            userCharacterService.Delete(id);
            TempData["SaveResult"] = "Character Deleted!";
            return RedirectToAction("Index");
        }
        // GET: UserCharacter/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: UserCharacter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var userCharacterService = CreateUserCharacterService();
            if (userCharacterService.Create(model))
            {
                TempData["SaveResult"] = "Character Created!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create character");
            return View(model);
        }
        // GET: UserCharacter/Edit/{id}
        public ActionResult Edit(int id)
        {
            var userCharacterService = CreateUserCharacterService();
            var detail = userCharacterService.GetCharacterDetailById(id);
            var model = new CharacterEdit
            {
                Appearance = detail.Appearance,
                ArmorClass = detail.ArmorClass,
                BackgroundId = detail.BackgroundId,
                Backstory = detail.Backstory,
                CharacterClassId = detail.CharacterClassId,
                Charisma = detail.Charisma,
                Constitution = detail.Constitution,
                Description = detail.Description,
                Dexterity = detail.Dexterity,
                HitPoints = detail.HitPoints,
                Id = detail.Id,
                Intelligence = detail.Intelligence,
                MulticlassId = detail.MulticlassId,
                MulticlassSubclassId = detail.MulticlassSubclassId,
                SavingThrows = detail.SavingThrows,
                Level = detail.Level,
                Name = detail.Name,
                NotableInventory = detail.NotableInventory,
                Notes = detail.Notes,
                RaceId = detail.RaceId,
                SecondMulticlassId = detail.SecondMulticlassId,
                SecondMulticlassSubclassId = detail.SecondMulticlassSubclassId,
                Strength = detail.Strength,
                Skills = detail.Skills,
                SubclassId = detail.SubclassId,
                SubraceId = detail.SubraceId,
                Wisdom = detail.Wisdom
            };
            return View(model);
        }
        // POST: UserCharacter/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharacterEdit model, int id)
        {
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var userCharacterService = CreateUserCharacterService();
            if (userCharacterService.Edit(model))
            {
                TempData["SaveResult"] = "Character Updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to update character");
            return View(model);
        }
    }
}