using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.CharacterClassModels
{
    public class CharacterClassEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Hit Die")]
        public string HitDie { get; set; }
        [Display(Name = "Saving Throws")]
        public List<Ability> SavingThrows { get; set; }
        [Display(Name = "Number of Skill Proficiencies")]
        public int NumberOfSkillProficiencies { get; set; }
        [Display(Name = "Skill Choices")]
        public List<Skill> SkillChoices { get; set; }
        public Dictionary<string, string> Features { get; set; }
    }
}
