using Data.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CharacterController : Controller
    {
        private readonly CharacterService _characterService;
        public CharacterController()
        {
            _characterService = new CharacterService();
        }
        // GET: Character
        public ActionResult Index()
        {
            var model = _characterService.GetAllCharacters();
            return View(model);
        }
        // GET: Character/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _characterService.GetCharacterDetailById(id);
            return View(model);
        }
    }
}