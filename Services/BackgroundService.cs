using Contracts;
using Data;
using Data.Entities;
using Models.BackgroundModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BackgroundService : IBackgroundService
    {
        private readonly ApplicationDbContext _ctx;
        public BackgroundService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(BackgroundCreate model)
        {
            var entity = new Background()
            {
                Name = model.Name,
                SkillProficiencies = model.SkillProficiencies
            };
            _ctx.Backgrounds.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Backgrounds.Single(e => e.Id == id);
            if(entity != null)
            {
                _ctx.Backgrounds.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(BackgroundEdit model)
        {
            var entity = _ctx.Backgrounds.Single(e => e.Id == model.Id);
            if(entity != null)
            {
                entity.Name = model.Name;
                entity.SkillProficiencies = model.SkillProficiencies;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<BackgroundListItem> GetAllBackgrounds()
        {
            var backgroundList = _ctx.Backgrounds.Select(e => new BackgroundListItem
            {
                Id = e.Id,
                Name = e.Name,
                SkillProficiencies = e.SkillProficiencies
            }).ToList();
            return backgroundList;
        }
        public BackgroundListItem GetBackgroundById(int id)
        {
            var entity = _ctx.Backgrounds.Single(e => e.Id == id);
            return new BackgroundListItem()
            {
                Id = entity.Id,
                Name = entity.Name,
                SkillProficiencies = entity.SkillProficiencies
            };
        }
    }
}
