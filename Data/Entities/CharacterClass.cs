using Data.Entities.ActionsFeaturesTraits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Data.Entities
{
    public class CharacterClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string HitDie { get; set; }
        [Required]
        public List<Ability> SavingThrows { get; set; }
        [Required]
        public int NumberOfSkillProficiencies { get; set; }
        [Required]
        public List<Skill> SkillChoices { get; set; }
        public virtual ICollection<CharacterFeature> Features { get; set; }
        public virtual ICollection<Subclass> Subclasses { get; set; }
    }
}
