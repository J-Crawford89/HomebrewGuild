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
            var spellList = _ctx.Spells
                .Where(e => e.IsDeleted == false)
                .Select(e => new SpellListItem
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

        public SpellDetailView GetSpellDetailViewById(int id)
        {
            var entity = _ctx.Spells.Single(e => e.Id == id);
            var model = new SpellDetailView
            {
                Id = entity.Id,
                Creator = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Name = entity.Name,
                SpellLevel = GetSpellLevelForDetail(entity.SpellLevel),
                IsRitual = entity.IsRitual,
                RequiresConcentration = entity.RequiresConcentration,
                CastingTime = entity.CastingTime,
                Components = entity.Components,
                MaterialComponent = entity.MaterialComponent,
                Duration = entity.Duration,
                Range = entity.Range,
                Description = entity.Description,
                ClassIds = entity.ClassIds,
                DateCreated = entity.DateCreated,
                LastUpdated = entity.LastUpdated,
                School = entity.School
            };
            return model;
        }
        private string GetSpellLevelForDetail(int level)
        {
            switch (level)
            {
                case 0:
                    return "Cantrip";
                case 1:
                    return "1st-level";
                case 2:
                    return "2nd-level";
                case 3:
                    return "3rd-level";
                case 4:
                    return "4th-level";
                case 5:
                    return "5th-level";
                case 6:
                    return "6th-level";
                case 7:
                    return "7th-level";
                case 8:
                    return "8th-level";
                case 9:
                    return "9th-level";
                case 10:
                    return "10th-level";
                case 11:
                    return "11th-level";
                case 12:
                    return "12th-level";
                case 13:
                    return "13th-level";
                default:
                    return "unknown level";
            }
        }
    }
}
