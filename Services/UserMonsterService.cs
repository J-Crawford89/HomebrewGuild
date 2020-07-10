using Contracts;
using Data;
using Data.Entities;
using Data.Entities.ActionsFeaturesTraits;
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
                NumberOfLegendaryActions = model.NumberOfLegendaryActions,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now,
                IsDeleted = false
            };
            _ctx.Monsters.Add(monster);
            bool savedMonster = _ctx.SaveChanges() == 1;
            bool savedTraits = true;
            bool savedActions = true;
            bool savedReactions = true;
            bool savedLegendary = true;
            bool savedLair = true;
            if (savedMonster)
            {
                if (model.Traits != null)
                {
                    savedTraits = AddMonsterTraits(model);
                }
                if (model.Actions != null)
                {
                    savedActions = AddMonsterActions(model);
                }
                if (model.Reactions != null)
                {
                    savedReactions = AddMonsterReactions(model);
                }
                if (model.LegendaryActions != null)
                {
                    savedLegendary = AddLegendaryActions(model);
                }
                if (model.LairActions != null)
                {
                    savedLair = AddLairActions(model);
                }
                if (savedTraits && savedActions && savedReactions && savedLegendary && savedLair)
                {
                    return true;
                }
            }
            return false;
        }
        private bool AddMonsterReactions(MonsterCreate model)
        {
            int monsterId = _ctx
                .Monsters
                .Single(e => e.Name == model.Name && e.OwnerId == _userId).Id;
            foreach (var modelReaction in model.Reactions)
            {
                bool addedReaction = AddMonsterReaction(modelReaction, monsterId);
                if (!addedReaction)
                {
                    return false;
                }
            }
            return true;
        }
        private bool AddMonsterReaction(MonsterReaction modelReaction, int monsterId)
        {
            var monsterReactionEntity = new MonsterReaction()
            {
                Title = modelReaction.Title,
                Description = modelReaction.Description,
                MonsterId = monsterId
            };
            _ctx.MonsterReactions.Add(monsterReactionEntity);
            return _ctx.SaveChanges() == 1;
        }
        private bool AddLegendaryActions(MonsterCreate model)
        {
            int monsterId = _ctx
                .Monsters
                .Single(e => e.Name == model.Name && e.OwnerId == _userId).Id;
            foreach (var modelLegendaryAction in model.LegendaryActions)
            {
                bool addedLegendary = AddLegendaryAction(modelLegendaryAction, monsterId);
                if (!addedLegendary)
                {
                    return false;
                }
            }
            return true;
        }
        private bool AddLegendaryAction(LegendaryAction modelLegendaryAction, int monsterId)
        {
            var legendaryActionEntity = new LegendaryAction()
            {
                Title = modelLegendaryAction.Title,
                Description = modelLegendaryAction.Description,
                MonsterId = monsterId
            };
            _ctx.LegendaryActions.Add(legendaryActionEntity);
            return _ctx.SaveChanges() == 1;
        }
        private bool AddLairActions(MonsterCreate model)
        {
            int monsterId = _ctx
                .Monsters
                .Single(e => e.Name == model.Name && e.OwnerId == _userId).Id;
            foreach (var modelLairAction in model.LairActions)
            {
                bool addedLair = AddLairAction(modelLairAction, monsterId);
                if (!addedLair)
                {
                    return false;
                }
            }
            return true;
        }
        private bool AddLairAction(LairAction modelLairAction, int monsterId)
        {
            var lairActionEntity = new LairAction()
            {
                Title = modelLairAction.Title,
                Description = modelLairAction.Description,
                MonsterId = monsterId
            };
            _ctx.LairActions.Add(lairActionEntity);
            return _ctx.SaveChanges() == 1;
        }
        private bool AddMonsterActions(MonsterCreate model)
        {
            int monsterId = _ctx
                .Monsters
                .Single(e => e.Name == model.Name && e.OwnerId == _userId).Id;
            foreach (var modelAction in model.Actions)
            {
                bool addedAction = AddMonsterAction(modelAction, monsterId);
                if (!addedAction)
                {
                    return false;
                }
            }
            return true;
        }
        private bool AddMonsterAction(MonsterAction modelAction, int monsterId)
        {
            var monsterActionEntity = new MonsterAction()
            {
                Title = modelAction.Title,
                Description = modelAction.Description,
                MonsterId = monsterId
            };
            _ctx.MonsterActions.Add(monsterActionEntity);
            return _ctx.SaveChanges() == 1;
        }
        private bool AddMonsterTraits(MonsterCreate model)
        {
            int monsterId = _ctx
                .Monsters
                .Single(e => e.Name == model.Name && e.OwnerId == _userId).Id;
            foreach (var modelTrait in model.Traits)
            {
                bool addedTrait = AddMonsterTrait(modelTrait, monsterId);
                if (!addedTrait)
                {
                    return false;
                }
            }
            return true;
        }
        private bool AddMonsterTrait(MonsterTrait modelTrait, int monsterId)
        {
            var monsterTraitEntity = new MonsterTrait()
            {
                Title = modelTrait.Title,
                Description = modelTrait.Description,
                MonsterId = monsterId
            };
            _ctx.MonsterTraits.Add(monsterTraitEntity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
