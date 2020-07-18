using Contracts;
using Data;
using Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _ctx;
        public CharacterService()
        {
            _ctx = new ApplicationDbContext();
        }
        public IEnumerable<CharacterListItem> GetAllCharacters()
        {
            var characterList = _ctx.Characters.Select(e => new CharacterListItem
            {
                Id = e.Id,
                Name = e.Name,
                RaceId = e.RaceId,
                CharacterClassId = e.CharacterClassId,
                Level = e.Level,
                Creator = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName
            }).ToList();
            return characterList;
        }

        public CharacterDetail GetCharacterDetailById(int id)
        {
            var entity = _ctx.Characters.Single(e => e.Id == id);
            var model = new CharacterDetail
            {
                Id = entity.Id,
                Creator = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Name = entity.Name,
                RaceId = entity.RaceId,
                SubraceId = entity.SubraceId,
                CharacterClassId = entity.CharacterClassId,
                SubclassId = entity.SubclassId,
                MulticlassId = entity.MulticlassId,
                MulticlassSubclassId = entity.MulticlassSubclassId,
                SecondMulticlassId = entity.SecondMulticlassId,
                SecondMulticlassSubclassId = entity.SecondMulticlassSubclassId,
                BackgroundId = entity.BackgroundId,
                Level = entity.Level,
                ArmorClass = entity.ArmorClass,
                HitPoints = entity.HitPoints,
                Strength = entity.Strength,
                Dexterity = entity.Dexterity,
                Constitution = entity.Constitution,
                Intelligence = entity.Intelligence,
                Wisdom = entity.Wisdom,
                Charisma = entity.Charisma,
                SavingThrows = entity.SavingThrows,
                Skills = entity.Skills,
                NotableInventory = entity.NotableInventory,
                Appearance = entity.Appearance,
                Backstory = entity.Backstory,
                Description = entity.Description,
                Notes = entity.Notes,
                DateCreated = entity.DateCreated,
                LastUpdated = entity.LastUpdated
            };
            return model;
        }
    }
}
