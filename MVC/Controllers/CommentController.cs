using Data;
using Data.Entities;
using Microsoft.AspNet.Identity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CommentController : Controller
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new CommentService(userId);
        }
        // GET: Comment/{characterId}
        public ActionResult IndexByCharacterId(int id)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByCharacterId(id);
            return View(id);
        }
        // GET: Comment/{monsterId}
        public ActionResult IndexByMonsterId(int id)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByMonsterId(id);
            return View(model);
        }
        // GET: Comment/{spellId}
        public ActionResult IndexBySpellId(int id)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsBySpellId(id);
            return View(model);
        }
        // GET: Comment/Details/{id}
        public ActionResult Details(int id)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetCommentById(id);
            return View(model);
        }
        [Authorize]
        // GET: Comment/Delete/{id}
        public ActionResult Delete(int id)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetCommentById(id);
            var ctx = new ApplicationDbContext();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userName = ctx.Users.Single(u => u.Id == userId.ToString()).UserName;
            if (model.Author == userName)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        // POST: Comment/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetCommentById(id);
            var ctx = new ApplicationDbContext();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userName = ctx.Users.Single(u => u.Id == userId.ToString()).UserName;
            if (model.Author == userName)
            {
                commentService.Delete(id);
                TempData["SaveResult"] = "Comment Deleted!";
                return RedirectToAction("Deleted");
            }
            return View(model);
        }
        // GET: Comment/Deleted
    }
}