using Data.Entities;
using Microsoft.AspNet.Identity;
using Models.NotificationModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private NotificationService CreateNotificationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            return new NotificationService(userId);
        }
        // POST: Notification/MarkAsRead
        [HttpPost]
        public ActionResult MarkAsRead(NotificationListItem notif)
        {
            var notificationService = CreateNotificationService();
            notificationService.MarkAsRead(notif.Id);

            if(notif.MonsterId != null)
            {
                return Json(Url.Action("Details", "Monster", new { id = notif.MonsterId }));
            }
            else
            {
                return Json(Url.Action("Details", "Spell", new { id = notif.SpellId }));
            }
        }
        // POST: Notification/Delete/{id}
        [HttpPost]
        public void Delete(int id)
        {
            var notificationService = CreateNotificationService();
            notificationService.Delete(id);
        }
        // POST: Notification/DeleteAll
        [HttpPost]
        public void DeleteAll()
        {
            var notificationService = CreateNotificationService();
            notificationService.DeleteAll();
        }
    }
}