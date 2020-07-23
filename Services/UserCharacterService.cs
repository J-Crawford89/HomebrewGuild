using Contracts;
using Data;
using Data.Entities;
using Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserCharacterService : IUserCharacterService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public UserCharacterService(Guid userId)
        {
            _ctx = new ApplicationDbContext();
            _userId = userId;
        }
        public bool Create(CharacterCreate model)
        {
            var entity = new Character
            {
                OwnerId = _userId,
                Name = model.Name,
                RaceId = model.RaceId,
                SubraceId = model.SubraceId,
                CharacterClassId = model.CharacterClassId,
                SubclassId = model.SubclassId,
                MulticlassId = model.MulticlassId,
                MulticlassSubclassId = model.MulticlassSubclassId,
                SecondMulticlassId = model.SecondMulticlassId,
                SecondMulticlassSubclassId = model.SecondMulticlassSubclassId,
                BackgroundId = model.BackgroundId,
                Level = model.Level,
                ArmorClass = model.ArmorClass,
                HitPoints = model.HitPoints,
                Strength = model.Strength,
                Dexterity = model.Dexterity,
                Constitution = model.Constitution,
                Intelligence = model.Intelligence,
                Wisdom = model.Wisdom,
                Charisma = model.Charisma,
                SavingThrows = model.SavingThrows,
                Skills = model.Skills,
                NotableInventory = model.NotableInventory,
                Appearance = model.Appearance,
                Backstory = model.Backstory,
                Description = model.Description,
                Notes = model.Notes,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now,
                IsDeleted = false
            };
            _ctx.Characters.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Characters
                .Where(e => e.OwnerId == _userId)
                .Single(e => e.Id == id);
            if(entity!=null)
            {
                entity.IsDeleted = true;
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(CharacterEdit model)
        {
            var entity = _ctx.Characters
                .Where(e => e.OwnerId == _userId)
                .Single(e => e.Id == model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.RaceId = model.RaceId;
                entity.SubraceId = model.SubraceId;
                entity.CharacterClassId = model.CharacterClassId;
                entity.SubclassId = model.SubclassId;
                entity.MulticlassId = model.MulticlassId;
                entity.MulticlassSubclassId = model.MulticlassSubclassId;
                entity.SecondMulticlassId = model.SecondMulticlassId;
                entity.SecondMulticlassSubclassId = model.SecondMulticlassSubclassId;
                entity.BackgroundId = model.BackgroundId;
                entity.Level = model.Level;
                entity.ArmorClass = model.ArmorClass;
                entity.HitPoints = model.HitPoints;
                entity.Strength = model.Strength;
                entity.Dexterity = model.Dexterity;
                entity.Constitution = model.Constitution;
                entity.Intelligence = model.Intelligence;
                entity.Wisdom = model.Wisdom;
                entity.Charisma = model.Charisma;
                entity.SavingThrows = model.SavingThrows;
                entity.Skills = model.Skills;
                entity.NotableInventory = model.NotableInventory;
                entity.Appearance = model.Appearance;
                entity.Backstory = model.Backstory;
                entity.Description = model.Description;
                entity.Notes = model.Notes;
                entity.LastUpdated = DateTime.Now;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CharacterListItem> GetAllUserCharacters()
        {
            string userId = _userId.ToString();
            var userName = _ctx.Users.Single(u => u.Id == userId).UserName;
            var characterList = _ctx.Characters
                .Where(e => e.OwnerId == _userId && e.IsDeleted == false)
                .Select(e => new CharacterListItem
            {
                Id = e.Id,
                Name = e.Name,
                RaceId = e.RaceId,
                CharacterClassId = e.CharacterClassId,
                Level = e.Level,
                Creator = userName
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
