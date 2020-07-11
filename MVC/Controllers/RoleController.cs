using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var roles = context.Roles.ToList();
            return View(roles);
        }
    }
}