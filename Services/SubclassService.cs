using Contracts;
using Data;
using Data.Entities;
using Models.SubclassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubclassService : ISubclassService
    {
        private readonly ApplicationDbContext _ctx;
        public SubclassService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(SubclassCreate model)
        {
            var entity = new Subclass()
            {
                Name = model.Name,
                Features = model.Features,
                CharacterClassId = model.CharacterClassId
            };
            _ctx.Subclasses.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.Subclasses.Single(e => e.Id == id);
            if (entity != null)
            {
                _ctx.Subclasses.Remove(entity);
            };
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(SubclassEdit model)
        {
            var entity = _ctx.Subclasses.Single(e => e.Id == model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Features = model.Features;
                entity.CharacterClassId = model.CharacterClassId;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<SubclassListItem> GetAllSubclasses()
        {
            var subclassList = _ctx.Subclasses.Select(e => new SubclassListItem
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return subclassList;
        }

        public SubclassDetail GetSubclassDetailById(int id)
        {
            var entity = _ctx.Subclasses.Single(e => e.Id == id);
            var model = new SubclassDetail
            {
                Id = entity.Id,
                Name = entity.Name,
                Features = entity.Features
            };
            return model;
        }
    }
}
