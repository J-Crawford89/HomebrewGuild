using Contracts;
using Data;
using Data.Entities;
using Models.SpellModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserSpellService : IUserSpellService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public UserSpellService(Guid userId)
        {
            _ctx = new ApplicationDbContext();
            _userId = userId;
        }
        public bool Create(SpellCreate model)
        {
            var entity = new Spell()
            {
                OwnerId = _userId,
                Name = model.Name,
                SpellLevel = model.SpellLevel,
                School = model.School,
                IsRitual = model.IsRitual,
                RequiresConcentration = model.RequiresConcentration,
                CastingTime = model.CastingTime,
                Components = model.Components,
                MaterialComponent = model.MaterialComponent,
                Duration = model.Duration,
                Description = model.Description,
                ClassIds = model.ClassIds,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now,
                IsDeleted = false
            };
            _ctx.Spells.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Spells
                .Where(e => e.OwnerId == _userId)
                .Single(e => e.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(SpellEdit model)
        {
            var entity = _ctx.Spells
                .Where(e => e.OwnerId == _userId)
                .Single(e => e.Id == model.Id);
            if(entity != null)
            {
                entity.Name = model.Name;
                entity.SpellLevel = model.SpellLevel;
                entity.School = model.School;
                entity.IsRitual = model.IsRitual;
                entity.RequiresConcentration = model.RequiresConcentration;
                entity.CastingTime = model.CastingTime;
                entity.Components = model.Components;
                entity.MaterialComponent = model.MaterialComponent;
                entity.Duration = model.Duration;
                entity.Description = model.Description;
                entity.ClassIds = model.ClassIds;
                entity.LastUpdated = DateTime.Now;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<SpellListItem> GetAllUserSpells()
        {
            string userId = _userId.ToString();
            var userName = _ctx.Users.Single(u => u.Id == userId).UserName;
            var spellList = _ctx.Spells.Select(e => new SpellListItem
            {
                Id = e.Id,
                Creator = userName,
                Name = e.Name,
                SpellLevel = e.SpellLevel,
                IsRitual = e.IsRitual,
                ClassIds = e.ClassIds,
                Components = e.Components,
                RequiresConcentration = e.RequiresConcentration
            }).ToList();
            return spellList;
        }

        public SpellDetail GetSpellDetailById(int id)
        {
            var entity = _ctx.Spells.Single(e => e.Id == id);
            var model = new SpellDetail
            {
                Id = entity.Id,
                Creator = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Name = entity.Name,
                SpellLevel = entity.SpellLevel,
                IsRitual = entity.IsRitual,
                RequiresConcentration = entity.RequiresConcentration,
                CastingTime = entity.CastingTime,
                Components = entity.Components,
                MaterialComponent = entity.MaterialComponent,
                Duration = entity.Duration,
                Description = entity.Description,
                ClassIds = entity.ClassIds,
                DateCreated = entity.DateCreated,
                LastUpdated = entity.LastUpdated,
                School = entity.School
            };
            return model;
        }
    }
}
