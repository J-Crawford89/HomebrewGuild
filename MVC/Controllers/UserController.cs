using Microsoft.AspNet.Identity;
using PagedList;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            return new UserService(userId);
        }
        // GET: User
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Username = String.IsNullOrEmpty(sortOrder) ? "usernameDescending" : "";
            ViewBag.Email = sortOrder == "Email" ? "emailDescending" : "Email";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var userService = CreateUserService();
            var model = userService.GetAllUsers();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.UserName.Contains(searchString) || e.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Email":
                    model = model.OrderBy(m => m.Email);
                    break;
                case "emailDescending":
                    model = model.OrderByDescending(m => m.Email);
                    break;
                case "usernameDescending":
                    model = model.OrderByDescending(m => m.UserName);
                    break;
                default: // Name ascending
                    model = model.OrderBy(m => m.UserName);
                    break;
            }

            int pageSize = 25;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }
    }
}