using Microsoft.Ajax.Utilities;
using PagedList;
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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CreatorSortParam = sortOrder == "Creator" ? "creatorDescending" : "Creator";
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "nameDescending" : "";
            ViewBag.SpellLevelSortParam = sortOrder == "SpellLevel" ? "spellLevelDescending" : "SpellLevel";
            ViewBag.RitualSortParam = sortOrder == "Ritual" ? "ritualDescending" : "Ritual";
            ViewBag.ConcentrationSortParam = sortOrder == "Concentration" ? "concentrationDescending" : "Concentration";
            
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var model = _spellService.GetAllSpells();
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
        // GET: Spell/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _spellService.GetSpellDetailViewById(id);
            return View(model);
        }
    }
}