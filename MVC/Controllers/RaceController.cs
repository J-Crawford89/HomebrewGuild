using Models.RaceModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles="Admin")]
    public class RaceController : Controller
    {
        private readonly RaceService _raceService;
        public RaceController()
        {
            _raceService = new RaceService();
        }
        // GET: Race
        public ActionResult Index()
        {
            var model = _raceService.GetAllRaces();
            return View(model);
        }
        // GET: Race/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Race/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(_raceService.Create(model))
            {
                TempData["SaveResult"] = "Race Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create race");
            return View(model);
        }
        // GET: Race/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _raceService.GetRaceDetailViewById(id);

            return View(model);
        }
        // GET: Race/Delete/{id}
        public ActionResult Delete(int id)
        {
            _raceService.Delete(id);
            TempData["SaveResult"] = "Race deleted";
            return RedirectToAction("Index");
        }
        // GET: Race/Edit/{id}
        public ActionResult Edit(int id)
        {
            var details = _raceService.GetRaceDetailById(id);
            var model = new RaceEdit
            {
                Id = details.Id,
                Name = details.Name,
                Size = details.Size,
                Speed = details.Speed,
                AbilityScoreIncrease = details.AbilityScoreIncrease,
                Traits = details.Traits,
                HasDarkvision = details.HasDarkvision
            };
            return View(model);
        }
        // POST: Race/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RaceEdit model, int id)
        {
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if(_raceService.Edit(model))
            {
                TempData["SaveResult"] = "Race edited";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to edit race");
            return View(model);
        }
    }
}