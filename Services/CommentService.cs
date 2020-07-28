using Contracts;
using Data;
using Data.Entities;
using Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
            _ctx = new ApplicationDbContext();
        }
        public bool CreateCharacterComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                OwnerId = _userId,
                Content = model.Content,
                DateCreated = DateTime.Now,
                CharacterId = model.ParentId
            };
            _ctx.Comments.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool CreateMonsterComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                OwnerId = _userId,
                Content = model.Content,
                DateCreated = DateTime.Now,
                MonsterId = model.ParentId
            };
            _ctx.Comments.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool CreateSpellComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                OwnerId = _userId,
                Content = model.Content,
                DateCreated = DateTime.Now,
                SpellId = model.ParentId
            };
            _ctx.Comments.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Comments.Single(e => e.Id == id);
            if(entity != null)
            {
                entity.IsDeleted = true;
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(CommentEdit model)
        {
            var entity = _ctx.Comments.Single(e => e.Id == model.Id);
            if(entity != null)
            {
                entity.Content = model.Content;
                entity.LastUpdated = DateTime.Now;
            }
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CommentListItem> GetAllCommentsByCharacterId(int characterId)
        {
            var commentList = _ctx.Comments
                .Where(e => e.CharacterId == characterId && e.IsDeleted == false)
                .Select(e => new CommentListItem
                {
                    Id = e.Id,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated,
                    RepliesCount = e.Replies.Where(reply => reply.IsDeleted == false).Count()
                }).ToList();
            return commentList;
        }

        public IEnumerable<CommentListItem> GetAllCommentsByMonsterId(int monsterId)
        {
            var commentList = _ctx.Comments
                .Where(e => e.MonsterId == monsterId && e.IsDeleted == false)
                .Select(e => new CommentListItem
                {
                    Id = e.Id,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated,
                    RepliesCount = e.Replies.Where(reply => reply.IsDeleted == false).Count()
                }).ToList();
            return commentList;
        }

        public IEnumerable<CommentListItem> GetAllCommentsBySpellId(int spellId)
        {
            var commentList = _ctx.Comments
                .Where(e => e.SpellId == spellId && e.IsDeleted == false)
                .Select(e => new CommentListItem
                {
                    Id = e.Id,
                    Author = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Content = e.Content,
                    DateCreated = e.DateCreated,
                    LastUpdated = e.LastUpdated,
                    RepliesCount = e.Replies.Where(reply => reply.IsDeleted == false).Count()
                }).ToList();
            return commentList;
        }

        public CommentListItem GetCommentById(int id)
        {
            var entity = _ctx.Comments.Single(e => e.Id == id);
            var model = new CommentListItem
            {
                Author = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Content = entity.Content,
                DateCreated = entity.DateCreated,
                LastUpdated = entity.LastUpdated,
                Id = entity.Id,
                RepliesCount = entity.Replies.Where(reply => reply.IsDeleted == false).Count()
            };
            return model;
        }
    }
}
