using Contracts;
using Data;
using Data.Entities;
using Models.MonsterModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
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
        // DELETE
        public bool Delete(int id)
        {
            var entity = _ctx.Monsters.Where(e => e.OwnerId == _userId)
                .Single(e => e.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
            return _ctx.SaveChanges() == 1;
        }
        // EDIT
        public bool Edit(MonsterEdit model)
        {
            var entity = _ctx.Monsters.Single(e => e.OwnerId == _userId && e.Id == model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Size = model.Size;
                entity.Type = model.Type;
                entity.Alignment = model.Alignment;
                entity.ArmorClass = model.ArmorClass;
                entity.ArmorType = model.ArmorType;
                entity.HitPoints = model.HitPoints;
                entity.HitPointEquation = model.HitPointEquation;
                entity.Speed = model.Speed;
                entity.Strength = model.Strength;
                entity.Dexterity = model.Dexterity;
                entity.Constitution = model.Constitution;
                entity.Intelligence = model.Intelligence;
                entity.Wisdom = model.Wisdom;
                entity.Charisma = model.Charisma;
                entity.SavingThrows = model.SavingThrows;
                entity.Skills = model.Skills;
                entity.Vulnerabilities = model.Vulnerabilities;
                entity.Resistances = model.Resistances;
                entity.Immunities = model.Immunities;
                entity.Senses = model.Senses;
                entity.Languages = model.Languages;
                entity.ChallengeRating = model.ChallengeRating;
                entity.Traits = model.Traits;
                entity.Actions = model.Actions;
                entity.Reactions = model.Reactions;
                entity.NumberOfLegendaryActions = model.NumberOfLegendaryActions;
                entity.LegendaryActions = model.LegendaryActions;
                entity.LairActions = model.LairActions;
                entity.LastUpdated = DateTime.Now;
            }
            return _ctx.SaveChanges() == 1;
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
                Traits = CheckIfNull(monsterEntity.Traits),
                Actions = CheckIfNull(monsterEntity.Actions),
                Reactions = CheckIfNull(monsterEntity.Reactions),
                NumberOfLegendaryActions = monsterEntity.NumberOfLegendaryActions,
                LegendaryActions = CheckIfNull(monsterEntity.LegendaryActions),
                LairActions = CheckIfNull(monsterEntity.LairActions),
                DateCreated = monsterEntity.DateCreated,
                LastUpdated = monsterEntity.LastUpdated
            };
            return model;
        }
        // CREATE
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
                Traits = CheckIfNull(model.Traits),
                Actions = CheckIfNull(model.Actions),
                Reactions = CheckIfNull(model.Reactions),
                NumberOfLegendaryActions = model.NumberOfLegendaryActions,
                LegendaryActions = CheckIfNull(model.LegendaryActions),
                LairActions = CheckIfNull(model.LairActions),
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now,
                IsDeleted = false
            };
            _ctx.Monsters.Add(monster);
            return _ctx.SaveChanges() == 1;
        }
        private Dictionary<string, string> CheckIfNull(Dictionary<string, string> query)
        {
            if (query != null)
            {
                foreach (var key in query.Keys.ToList())
                {
                    if (string.IsNullOrWhiteSpace(key) || string.IsNullOrEmpty(key))
                    {
                        query.Remove(key);
                    }
                }
            }
            if(query != null)
            {
                foreach(var value in query.Values.ToList())
                {
                    if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                    {
                        query.Remove(value);
                    }
                }
            }
            if(query.Count == 0)
            {
                return null;
            }    
            return query;
        }
    }
}
