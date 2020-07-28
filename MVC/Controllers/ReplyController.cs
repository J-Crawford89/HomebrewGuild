using Microsoft.AspNet.Identity;
using Models.ReplyModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ReplyController : Controller
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.NewGuid();
            if(User.Identity.IsAuthenticated)
            {
                userId = Guid.Parse(User.Identity.GetUserId());
            }

            return new ReplyService(userId);
        }
        // GET: Reply
        public PartialViewResult Index(int commentId)
        {
            var replyService = CreateReplyService();
            var model = replyService.GetAllRepliesByCommentId(commentId);

            return PartialView("Index", model);
        }

        // POST: Reply/Create
        [HttpPost]
        public ActionResult Create(ReplyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var replyService = CreateReplyService();
            if (replyService.Create(model))
            {
                TempData["SaveResult"] = "Reply Added";
                return Redirect(Request.UrlReferrer.ToString());
            }
            ModelState.AddModelError("", "Unable to add comment");
            return View(model);
        }

        // POST: Reply/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int replyId)
        {
            var replyService = CreateReplyService();
            replyService.Delete(replyId);
            TempData["SaveResult"] = "Reply Deleted!";
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Reply/Edit/{id}
        [HttpPost]
        public ActionResult Edit(ReplyEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var replyService = CreateReplyService();
            if (replyService.Edit(model))
            {
                TempData["SaveResult"] = "Reply Updated!";
                return Redirect(Request.UrlReferrer.ToString());
            }
            ModelState.AddModelError("", "Reply was not updated");
            return View(model);
        }
    }
}