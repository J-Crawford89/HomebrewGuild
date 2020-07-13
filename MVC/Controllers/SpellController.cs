using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SpellController : Controller
    {
        private readonly SpellService _spellService;
        public SpellController()
        {
            _spellService = new SpellService();
        }
        // GET: Spell
        public ActionResult Index()
        {
            var model = _spellService.GetAllSpells();
            return View(model);
        }
        // GET: Spell/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _spellService.GetSpellDetailById(id);
            return View(model);
        }
    }
}