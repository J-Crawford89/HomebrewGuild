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
        private CommentService CreateCommentService()
        {
            var userId = Guid.NewGuid();
            if (User.Identity.IsAuthenticated)
            {
                userId = Guid.Parse(User.Identity.GetUserId());
            }   

            return new CommentService(userId);
        }
        [AllowAnonymous]
        public PartialViewResult GetCommentsByCharacterId(int characterId)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByCharacterId(characterId);

            return PartialView("Index", model);
        }
        [AllowAnonymous]
        public PartialViewResult GetCommentsByMonsterId(int monsterId)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsByMonsterId(monsterId);

            return PartialView("Index", model);
        }
        [AllowAnonymous]
        public PartialViewResult GetCommentsBySpellId(int spellId)
        {
            var commentService = CreateCommentService();
            var model = commentService.GetAllCommentsBySpellId(spellId);

            return PartialView("Index", model);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult CreateMonsterComment(CommentCreate model, int monsterId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var commentService = CreateCommentService();
            if (commentService.CreateMonsterComment(model))
            {
                TempData["SaveResult"] = "Comment Added";
                return RedirectToAction("Details", "Monster", new { id = monsterId });
            }
            ModelState.AddModelError("", "Unable to add comment");
            return View(model);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult CreateCharacterComment(CommentCreate model, int characterId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var commentService = CreateCommentService();
            if (commentService.CreateCharacterComment(model))
            {
                TempData["SaveResult"] = "Comment Added";
                return RedirectToAction("Details", "Character", new { id = characterId });
            }
            ModelState.AddModelError("", "Unable to add comment");
            return View(model);
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult CreateSpellComment(CommentCreate model, int spellId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var commentService = CreateCommentService();
            if (commentService.CreateSpellComment(model))
            {
                TempData["SaveResult"] = "Comment Added";
                return RedirectToAction("Details", "Spell", new { id = spellId });
            }
            ModelState.AddModelError("", "Unable to add comment");
            return View(model);
        }

        // POST: Comment/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int commentId)
        {
            var commentService = CreateCommentService();
            commentService.Delete(commentId);
            TempData["SaveResult"] = "Comment Deleted!";
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Comment/Edit/{id}
        [HttpPost]
        public ActionResult Edit(CommentEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var commentService = CreateCommentService();
            if (commentService.Edit(model))
            {
                TempData["SaveResult"] = "Comment Updated!";
                return Redirect(Request.UrlReferrer.ToString());
            }
            ModelState.AddModelError("", "Comment was not updated");
            return View(model);
        }
    }
}