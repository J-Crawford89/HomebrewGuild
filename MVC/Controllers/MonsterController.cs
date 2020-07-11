using Data;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MonsterController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly MonsterService _monsterService;
        public MonsterController()
        {
            _ctx = new ApplicationDbContext();
            _monsterService = new MonsterService();
        }
        // GET: Monster
        public ActionResult Index()
        {
            var model = _monsterService.GetAllMonsters();
            return View(model);
        }
        // GET: Monster/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _monsterService.GetMonsterDetailById(id);
            return View(model);
        }
    }
}