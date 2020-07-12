using Contracts;
using Data;
using Data.Entities;
using Models.CharacterClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CharacterClassService : ICharacterClassService
    {
        private readonly ApplicationDbContext _ctx;
        public CharacterClassService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(CharacterClassCreate model)
        {
            var entity = new CharacterClass()
            {
                Name = model.Name,
                HitDie = model.HitDie,
                SavingThrows = model.SavingThrows,
                NumberOfSkillProficiencies = model.NumberOfSkillProficiencies,
                Features = model.Features,
                SkillChoices = model.SkillChoices
            };
            _ctx.CharacterClasses.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var entity = _ctx.CharacterClasses.Single(e => e.Id == id);
            if(entity!= null)
            {
                _ctx.CharacterClasses.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(CharacterClassEdit model)
        {
            var entity = _ctx.CharacterClasses.Single(e => e.Id == model.Id);
            if(entity != null)
            {
                entity.Name = model.Name;
                entity.HitDie = model.HitDie;
                entity.SavingThrows = model.SavingThrows;
                entity.NumberOfSkillProficiencies = model.NumberOfSkillProficiencies;
                entity.SkillChoices = model.SkillChoices;
                entity.Features = model.Features;
            }
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<CharacterClassListItem> GetAllCharacterClasses()
        {
            var characterClassList = _ctx.CharacterClasses
                .Select(e => new CharacterClassListItem
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToList();
            return characterClassList;
        }

        public CharacterClassDetail GetCharacterClassDetailById(int id)
        {
            var entity = _ctx.CharacterClasses.Single(e => e.Id == id);
            var model = new CharacterClassDetail
            {
                Id = entity.Id,
                Name = entity.Name,
                Features = entity.Features,
                HitDie = entity.HitDie,
                NumberOfSkillProficiencies = entity.NumberOfSkillProficiencies,
                SavingThrows = entity.SavingThrows,
                SkillChoices = entity.SkillChoices
            };
            return model;
        }
    }
}
