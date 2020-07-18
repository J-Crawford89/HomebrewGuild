using Contracts;
using Data;
using Models.SpellModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SpellService : ISpellService
    {
        private readonly ApplicationDbContext _ctx;
        public SpellService()
        {
            _ctx = new ApplicationDbContext();
        }
        public IEnumerable<SpellListItem> GetAllSpells()
        {
            var spellList = _ctx.Spells.Select(e => new SpellListItem
            {
                Id = e.Id,
                Creator = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                Name = e.Name,
                SpellLevel = e.SpellLevel,
                IsRitual = e.IsRitual,
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
