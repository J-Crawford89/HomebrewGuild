using Data.Entities;
using Microsoft.AspNet.Identity;
using Models.CommentModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        public CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new CommentService(userId);
        }
        [AllowAnonymous]
        // GET: Comment
        public ActionResult MonsterCommentIndex(int monsterId)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByMonsterId(monsterId);
            return View(model);
        }
        // GET: Comment/Create
        public ActionResult MonsterCommentCreate(int monsterId)
        {
            var commentService = CreateCommentService();
            var model = new CommentCreate
            {
                ParentId = monsterId
            };
            return View(model);
        }
        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MonsterCommentCreate()
        {
            return RedirectToAction("Index");
        }
    }
}