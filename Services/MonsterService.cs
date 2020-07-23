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
    public class MonsterService : IMonsterService
    {
        private readonly ApplicationDbContext _ctx;
        public MonsterService()
        {
            _ctx = new ApplicationDbContext();
        }
        public IEnumerable<MonsterListItem> GetAllMonsters()
        {
            var monsterList = _ctx.Monsters
                    .Where(e => e.IsDeleted == false)
                    .Select(e => new MonsterListItem
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Type = e.Type,
                        ChallengeRating = e.ChallengeRating,
                        Creator = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName
                    }).ToList();
            return monsterList;
        }

        public MonsterDetailView GetMonsterDetailViewById(int id)
        {
            var monsterEntity = _ctx.Monsters.Single(e => e.Id == id);
            var model = new MonsterDetailView
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
                SavingThrows = FormatSavingThrows(monsterEntity),
                Skills = FormatSkills(monsterEntity),
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
        public string FormatSkills(Monster entity)
        {
            string formattedSkills = "";
            string skill = "";
            string bonus = "";
            foreach (var kvp in entity.Skills)
            {
                skill = kvp.Key.ToString() + " ";
                if (kvp.Value.Contains('+') || kvp.Value.Contains('-'))
                {
                    bonus = kvp.Value + " ";
                }
                else
                {
                    bonus = $"+{kvp.Value} ";
                }
                formattedSkills += skill + bonus;
            }
            return formattedSkills;
        }
        public string FormatSavingThrows(Monster entity)
        {
            string formattedSavingThrows = "";
            string ability = "";
            string bonus = "";
            foreach (var kvp in entity.SavingThrows)
            {
                switch (kvp.Key.ToString())
                {
                    case "Strength":
                        ability = "Str ";
                        break;
                    case "Dexterity":
                        ability = "Dex ";
                        break;
                    case "Constitution":
                        ability = "Con ";
                        break;
                    case "Intelligence":
                        ability = "Int ";
                        break;
                    case "Wisdom":
                        ability = "Wis ";
                        break;
                    case "Charisma":
                        ability = "Cha ";
                        break;
                    default:
                        ability = kvp.Key.ToString();
                        break;
                }
                if (kvp.Value.Contains('+') || kvp.Value.Contains('-'))
                {
                    bonus = kvp.Value + " ";
                }
                else
                {
                    bonus = $"+{kvp.Value} ";
                }
                formattedSavingThrows += ability + bonus;
            }
            return formattedSavingThrows;
        }

        private Dictionary<string, string> CheckIfNull(Dictionary<string, string> query)
        {
            if (query != null)
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
                if (query != null)
                {
                    foreach (var value in query.Values.ToList())
                    {
                        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                        {
                            query.Remove(value);
                        }
                    }
                }
                if (query.Count > 0)
                {
                    return query;
                }
            }
            return null;
        }

    }
}
