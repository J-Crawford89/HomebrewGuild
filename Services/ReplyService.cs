using Contracts;
using Data;
using Data.Entities;
using Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _ctx = new ApplicationDbContext();
            _userId = userId;
        }
        public bool Create(ReplyCreate model)
        {
            var entity = new Reply()
            {
                OwnerId = _userId,
                Content = model.Content,
                CommentId = model.CommentId,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now,
                IsDeleted = false
            };
            _ctx.Replies.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Replies
                .Where(e=>e.OwnerId == _userId)
                .Single(e => e.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            };
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(ReplyEdit model)
        {
            var entity = _ctx.Replies
                .Where(e => e.OwnerId == _userId)
                .Single(e => e.Id == model.Id);
            if (entity != null)
            {
                entity.Content = model.Content;
                entity.LastUpdated = DateTime.Now;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<ReplyListItem> GetAllRepliesByCommentId(int commentId)
        {
            var repliesList = _ctx.Replies
                .Where(e => e.CommentId == commentId)
                .Select(e => new ReplyListItem
                {
                    Id = e.Id,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated
                }).ToList();
            return repliesList;
        }

        public ReplyListItem GetReplyById(int id)
        {
            var entity = _ctx.Replies.Single(e => e.Id == id);
            var model = new ReplyListItem
            {
                Id = entity.Id,
                Author = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Content = entity.Content,
                DateCreated = entity.DateCreated,
                LastUpdated = entity.LastUpdated
            };
            return model;
        }
    }
}
