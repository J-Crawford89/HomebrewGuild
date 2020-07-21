using Contracts;
using Data;
using Data.Entities;
using Microsoft.SqlServer.Server;
using Models.SubraceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubraceService : ISubraceService
    {
        private readonly ApplicationDbContext _ctx;
        public SubraceService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(SubraceCreate model)
        {
            var entity = new Subrace()
            {
                Name = model.Name,
                AbilityScoreIncrease = model.AbilityScoreIncrease,
                Traits = model.Traits,
                RaceId = model.RaceId
            };
            _ctx.Subraces.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Subraces.Single(e => e.Id == id);
            if (entity != null)
            {
                _ctx.Subraces.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(SubraceEdit model)
        {
            var entity = _ctx.Subraces.Single(e => e.Id == model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.AbilityScoreIncrease = model.AbilityScoreIncrease;
                entity.Traits = model.Traits;
                entity.RaceId = model.RaceId;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<SubraceListItem> GetAllSubraces()
        {
            var subraceList = _ctx.Subraces.Select(e => new SubraceListItem
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return subraceList;
        }

        public SubraceDetail GetSubraceDetailById(int id)
        {
            var entity = _ctx.Subraces.Single(e => e.Id == id);
            var model = new SubraceDetail
            {
                Id = entity.Id,
                Name = entity.Name,
                AbilityScoreIncrease = entity.AbilityScoreIncrease,
                Traits = entity.Traits,
                RaceName = _ctx.Races.Single(e => e.Id == entity.RaceId).Name
            };
            return model;
        }
        
        public SubraceDetailView GetSubraceDetailViewById(int id)
        {
            var entity = _ctx.Subraces.Single(e => e.Id == id);
            var model = new SubraceDetailView
            {
                Id = entity.Id,
                Name = entity.Name,
                AbilityScoreIncrease = FormatAbilityScoreIncrease(entity),
                Traits = entity.Traits,
                RaceName = _ctx.Races.Single(e => e.Id == entity.RaceId).Name
            };
            return model;
        }

        public string FormatAbilityScoreIncrease(Subrace entity)
        {
            string formattedAbilityScoreIncrease = "";
            string ability = "";
            string bonus = "";
            foreach (var kvp in entity.AbilityScoreIncrease)
            {
                ability = kvp.Key.ToString() + " ";
                if (kvp.Value.Contains('+') || kvp.Value.Contains('-'))
                {
                    bonus = kvp.Value + " ";
                }
                else
                {
                    bonus = $"+{kvp.Value} ";
                }
                formattedAbilityScoreIncrease += ability + bonus;
            }
            return formattedAbilityScoreIncrease;
        }

    }
}
