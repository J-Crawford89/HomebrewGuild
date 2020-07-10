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
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private UserMonsterService CreateMonsterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new UserMonsterService(userId);
        }
        // GET: Monster
        public ActionResult Index()
        {
            var monsterService = CreateMonsterService();
            var model = monsterService.GetAllUserMonsters();
            return View(model);
        }
        // GET: Monster/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Monster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonsterCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var monsterService = CreateMonsterService();
            if (monsterService.Create(model))
            {
                TempData["SaveResult"] = "Monster Created!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an error creating your monster.");
            return View(model);
        }
    }
}