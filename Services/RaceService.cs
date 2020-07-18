using Contracts;
using Data;
using Data.Entities;
using Models.RaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RaceService : IRaceService
    {
        private readonly ApplicationDbContext _ctx;
        public RaceService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(RaceCreate model)
        {
            var entity = new Race()
            {
                Name = model.Name,
                AbilityScoreIncrease = model.AbilityScoreIncrease,
                HasDarkvision = model.HasDarkvision,
                Size = model.Size,
                Speed = model.Speed,
                Traits = model.Traits
            };
            _ctx.Races.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Races.Single(e => e.Id == id);
            if(entity!= null)
            {
                _ctx.Races.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(RaceEdit model)
        {
            var entity = _ctx.Races.Single(e => e.Id == model.Id);
            if(entity!= null)
            {
                entity.Name = model.Name;
                entity.AbilityScoreIncrease = model.AbilityScoreIncrease;
                entity.Size = model.Size;
                entity.Traits = model.Traits;
                entity.Speed = model.Speed;
                entity.HasDarkvision = model.HasDarkvision;
            }
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<RaceListItem> GetAllRaces()
        {
            var raceList = _ctx.Races.Select(e => new RaceListItem
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return raceList;
        }

        public RaceDetail GetRaceDetailById(int id)
        {
            var entity = _ctx.Races.Single(e => e.Id == id);
            var model = new RaceDetail
            {
                Id = entity.Id,
                Name = entity.Name,
                AbilityScoreIncrease = entity.AbilityScoreIncrease,
                Size = entity.Size,
                Speed = entity.Speed,
                HasDarkvision = entity.HasDarkvision,
                Traits = entity.Traits
            };
            return model;
        }
    }
}
