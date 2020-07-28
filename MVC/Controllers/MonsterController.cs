using Data;
using PagedList;
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
        private readonly MonsterService _monsterService;
        public MonsterController()
        {
            _monsterService = new MonsterService();
        }
        // GET: Monster
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CreatorSortParam = sortOrder == "Creator" ? "creatorDescending" : "Creator";
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "nameDescending" : "";
            ViewBag.TypeSortParam = sortOrder == "Type" ? "typeDescending" : "Type";
            ViewBag.ChallengeRatingSortParam = sortOrder == "ChallengeRating" ? "challengeRatingDescending" : "ChallengeRating";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var model = _monsterService.GetAllMonsters();
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
                case "Type":
                    model = model.OrderBy(m => m.Type);
                    break;
                case "typeDescending":
                    model = model.OrderByDescending(m => m.Type);
                    break;
                case "ChallengeRating":
                    model = model.OrderBy(m => m.ChallengeRating);
                    break;
                case "challengeRatingDescending":
                    model = model.OrderByDescending(m => m.ChallengeRating);
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
        // GET: Monster/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _monsterService.GetMonsterDetailViewById(id);
            return View(model);
        }
    }
}