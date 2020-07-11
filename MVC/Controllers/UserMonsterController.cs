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
        private UserMonsterService CreateUserMonsterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new UserMonsterService(userId);
        }
        // GET: Monster
        public ActionResult Index()
        {
            var userMonsterService = CreateUserMonsterService();
            var model = userMonsterService.GetAllUserMonsters();
            return View(model);
        }
        // GET: Monster/Create
        public ActionResult Create()
        {
            var model = new MonsterCreate();
            return View(model);
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
            var userMonsterService = CreateUserMonsterService();
            if (userMonsterService.Create(model))
            {
                TempData["SaveResult"] = "Monster Created!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an error creating your monster.");
            return View(model);
        }
        // GET: Monster/Details/{id}
        public ActionResult Details(int id)
        {
            var userMonsterService = CreateUserMonsterService();
            var model = userMonsterService.GetMonsterDetailById(id);

            return View(model);
        }
    }
}