using Contracts;
using Data;
using Data.Entities;
using Models.MonsterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserMonsterService : IUserMonsterService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public UserMonsterService(Guid userId)
        {
            _userId = userId;
            _ctx = new ApplicationDbContext();
        }
        // LIST
        public IEnumerable<MonsterListItem> GetAllUserMonsters()
        {
            string userId = _userId.ToString();
            var userName = _ctx.Users.Single(u => u.Id == userId).UserName;
            var monsterList = _ctx
                .Monsters
                .Where(e => e.OwnerId == _userId && e.IsDeleted == false)
                .Select(e => new MonsterListItem
                {
                    Id = e.Id,
                    Name = e.Name,
                    Creator = userName,
                    Type = e.Type,
                    ChallengeRating = e.ChallengeRating
                }).ToList();
            return monsterList;
        }
        // DETAIL
        public MonsterDetail GetMonsterDetailById(int id)
        {
            var monsterEntity = _ctx.Monsters.Single(e => e.Id == id);
            var model = new MonsterDetail
            {
                Id = monsterEntity.Id,
                Creator = _ctx.Users.Single(u => u.Id == monsterEntity.OwnerId.ToString()).UserName,
                Name = monsterEntity.Name,
                Size = monsterEntity.Size,
                Type = monsterEntity.Type,
                Alignment = monsterEntity.Alignment,
                ArmorClass = monsterEntity.ArmorClass,
                ArmorType = monsterEntity.ArmorType,
                HitPoints = monsterEntity.HitPoints,
                HitPointEquation = monsterEntity.HitPointEquation,
                Speed = monsterEntity.Speed,
                Strength = monsterEntity.Strength,
                Dexterity = monsterEntity.Dexterity,
                Constitution = monsterEntity.Constitution,
                Intelligence = monsterEntity.Intelligence,
                Wisdom = monsterEntity.Wisdom,
                Charisma = monsterEntity.Charisma,
                SavingThrows = monsterEntity.SavingThrows,
                Skills = monsterEntity.Skills,
                Vulnerabilities = monsterEntity.Vulnerabilities,
                Resistances = monsterEntity.Resistances,
                Immunities = monsterEntity.Immunities,
                Senses = monsterEntity.Senses,
                Languages = monsterEntity.Languages,
                ChallengeRating = monsterEntity.ChallengeRating,
                Traits = monsterEntity.Traits,
                Actions = monsterEntity.Actions,
                Reactions = monsterEntity.Reactions,
                NumberOfLegendaryActions = monsterEntity.NumberOfLegendaryActions,
                LegendaryActions = monsterEntity.LegendaryActions,
                LairActions = monsterEntity.LairActions,
                DateCreated = monsterEntity.DateCreated,
                LastUpdated = monsterEntity.LastUpdated
            };
            return model;
        }
        public bool Create(MonsterCreate model)
        {
            var monster = new Monster()
            {
                OwnerId = _userId,
                Name = model.Name,
                Size = model.Size,
                Type = model.Type,
                Alignment = model.Alignment,
                ArmorClass = model.ArmorClass,
                ArmorType = model.ArmorType,
                HitPoints = model.HitPoints,
                HitPointEquation = model.HitPointEquation,
                Speed = model.Speed,
                Strength = model.Strength,
                Dexterity = model.Dexterity,
                Constitution = model.Constitution,
                Intelligence = model.Intelligence,
                Wisdom = model.Wisdom,
                Charisma = model.Charisma,
                SavingThrows = model.SavingThrows,
                Skills = model.Skills,
                Vulnerabilities = model.Vulnerabilities,
                Resistances = model.Resistances,
                Immunities = model.Immunities,
                Senses = model.Senses,
                Languages = model.Languages,
                ChallengeRating = model.ChallengeRating,
                Traits = model.Traits,
                Actions = model.Actions,
                Reactions = model.Reactions,
                NumberOfLegendaryActions = model.NumberOfLegendaryActions,
                LegendaryActions = model.LegendaryActions,
                LairActions = model.LairActions,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now,
                IsDeleted = false
            };
            _ctx.Monsters.Add(monster);
            return _ctx.SaveChanges() == 1;
        }
    }
}
