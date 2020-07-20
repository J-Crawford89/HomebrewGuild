﻿using Data;
using Models.CharacterClassModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CharacterClassController : Controller
    {
        private readonly CharacterClassService _characterClassService;
        public CharacterClassController()
        {
            _characterClassService = new CharacterClassService();
        }
        // GET: CharacterClass
        public ActionResult Index()
        {
            var model = _characterClassService.GetAllCharacterClasses();
            return View(model);
        }
        // GET: CharacterClass/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: CharacterClass/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterClassCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(_characterClassService.Create(model))
            {
                TempData["SaveResult"] = "Class Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to create class");
            return View(model);
        }
        // GET: CharacterClass/Delete/{id}
        public ActionResult Delete(int id)
        {
            var model = _characterClassService.GetCharacterClassDetailById(id);
            return View(model);
        }
        // POST: CharacterClass/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            _characterClassService.Delete(id);
            TempData["SaveResult"] = "Class Deleted";
            return RedirectToAction("Index");
        }
        // GET: CharacterClass/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _characterClassService.GetCharacterClassDetailById(id);
            return View(model);
        }
        // GET: CharacterClass/Edit/{id}
        public ActionResult Edit(int id)
        {
            var detail = _characterClassService.GetCharacterClassDetailById(id);
            var model = new CharacterClassEdit
            {
                Id = detail.Id,
                Name = detail.Name,
                HitDie = detail.HitDie,
                Features = detail.Features,
                NumberOfSkillProficiencies = detail.NumberOfSkillProficiencies,
                SavingThrows = detail.SavingThrows,
                SkillChoices = detail.SkillChoices
            };
            return View(model);
        }
        // POST: CharacterClass/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharacterClassEdit model, int id)
        {
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            if(_characterClassService.Edit(model))
            {
                TempData["SaveResult"] = "Class Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Unable to edit class");
            return View(model);
        }
    }
}