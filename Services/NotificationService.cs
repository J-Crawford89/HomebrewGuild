using Contracts;
using Data;
using Data.Entities;
using Models.NotificationModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public NotificationService(Guid userId)
        {
            _userId = userId;
            _ctx = new ApplicationDbContext();
        }
        public bool CreateCommentNotification(NotificationCreate model)
        {
            var creator = _ctx.Users.Single(e => e.Id == _userId.ToString());
            var comment = _ctx.Comments.Single(e => e.Id == model.CommentId);
            var contentCreatorId = new Guid();
            if(comment.MonsterId != null)
            {
                var content = _ctx.Monsters.Single(e => e.Id == comment.MonsterId);
                contentCreatorId = content.OwnerId;
            }
            if(comment.SpellId != null)
            {
                var content = _ctx.Spells.Single(e => e.Id == comment.SpellId);
                contentCreatorId = content.OwnerId;
            }

            if(_userId == contentCreatorId)
            {
                return true;
            }

            var entity = new Notification()
            {
                CommentId = model.CommentId,
                Content = $"{creator.UserName} has left a comment on one of your creations.",
                DateCreated = DateTime.Now,
                IsRead = false,
                MonsterId = model.MonsterId,
                ReplyId = null,
                SpellId = model.SpellId,
                UserId = contentCreatorId
            };
            _ctx.Notifications.Add(entity);

            return _ctx.SaveChanges() == 1;
        }

        public bool CreateReplyNotificationForCommentCreator(NotificationCreate model)
        {
            var creator = _ctx.Users.Single(e => e.Id == _userId.ToString());
            var reply = _ctx.Replies.Single(e => e.Id == model.ReplyId);
            var comment = _ctx.Comments.Single(e => e.Id == reply.CommentId);

            if (_userId == comment.OwnerId)
            {
                return true;
            }

            var entity = new Notification()
            {
                CommentId = model.CommentId,
                Content = $"{creator.UserName} has replied to one of your comments.",
                DateCreated = DateTime.Now,
                IsRead = false,
                MonsterId = model.MonsterId,
                ReplyId = model.ReplyId,
                SpellId = model.SpellId,
                UserId = comment.OwnerId
            };
            _ctx.Notifications.Add(entity);

            return _ctx.SaveChanges() == 1;
        }

        public bool CreateReplyNotificationForContentCreator(NotificationCreate model)
        {
            var creator = _ctx.Users.Single(e => e.Id == _userId.ToString());
            var reply = _ctx.Replies.Single(e => e.Id == model.ReplyId);
            var comment = _ctx.Comments.Single(e => e.Id == reply.CommentId);
            var contentCreatorId = new Guid();
            if (comment.MonsterId != null)
            {
                var content = _ctx.Monsters.Single(e => e.Id == comment.MonsterId);
                contentCreatorId = content.OwnerId;
            }
            else if (comment.SpellId != null)
            {
                var content = _ctx.Spells.Single(e => e.Id == comment.SpellId);
                contentCreatorId = content.OwnerId;
            }

            if(_userId == contentCreatorId)
            {
                return true;
            }

            var entity = new Notification()
            {
                CommentId = model.CommentId,
                Content = $"{creator.UserName} has replied to a comment on one of your creations.",
                DateCreated = DateTime.Now,
                IsRead = false,
                MonsterId = model.MonsterId,
                ReplyId = model.ReplyId,
                SpellId = model.SpellId,
                UserId = contentCreatorId
            };
            _ctx.Notifications.Add(entity);

            return _ctx.SaveChanges() == 1;
        }

        public bool CreateReplyNotificationForOtherReplyCreators(NotificationCreate model)
        {
            var creator = _ctx.Users.Single(e => e.Id == _userId.ToString());
            var reply = _ctx.Replies.Single(e => e.Id == model.ReplyId);
            var comment = _ctx.Comments.Single(e => e.Id == reply.CommentId);
            var contentCreatorId = new Guid();

            if(comment.MonsterId != null)
            {
                var content = _ctx.Monsters.Single(e => e.Id == comment.MonsterId);
                contentCreatorId = content.OwnerId;
            }
            if (comment.SpellId != null)
            {
                var content = _ctx.Spells.Single(e => e.Id == comment.SpellId);
                contentCreatorId = content.OwnerId;
            }

            var otherReplies = _ctx.Replies.Where(e => e.CommentId == comment.Id 
                && e.OwnerId != _userId 
                && e.OwnerId != comment.OwnerId 
                && e.OwnerId != contentCreatorId 
                && e.IsDeleted == false);
            var notificationsCreated = 0;
            if (otherReplies != null)
            {
                foreach (var otherReply in otherReplies)
                {
                    var entity = new Notification()
                    {
                        CommentId = model.CommentId,
                        Content = $"{creator.UserName} has replied to a comment you also replied to.",
                        DateCreated = DateTime.Now,
                        IsRead = false,
                        MonsterId = model.MonsterId,
                        ReplyId = model.ReplyId,
                        SpellId = model.SpellId,
                        UserId = otherReply.OwnerId
                    };
                    _ctx.Notifications.Add(entity);
                    notificationsCreated++;
                }

                return _ctx.SaveChanges() == notificationsCreated;
            }
            else { return true; }
        }

        public IEnumerable<NotificationListItem> GetAllNotificationsByUserId(Guid userId)
        {
            var notificationList = _ctx.Notifications
                .Where(e => e.UserId == userId)
                .Select(e => new NotificationListItem
                {
                    Id = e.Id,
                    IsRead = e.IsRead,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    CommentId = e.CommentId,
                    MonsterId = e.MonsterId,
                    ReplyId = e.ReplyId,
                    SpellId = e.SpellId
                }).ToList();
            return notificationList;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Notifications.Single(e => e.Id == id);
            if (entity != null)
            {
                _ctx.Notifications.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool MarkAsRead(int id)
        {
            var entity = _ctx.Notifications.Single(e => e.Id == id);
            if (entity != null)
            {
                entity.IsRead = true;
            }
            return _ctx.SaveChanges() == 1;
        }

        public void DeleteAll()
        {
            var notificationList = _ctx.Notifications.Where(e => e.UserId == _userId);
            foreach(var item in notificationList)
            {
                _ctx.Notifications.Remove(item);
            }
            _ctx.SaveChanges();
        }
    }
}
