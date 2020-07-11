using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        internal string _SavingThrows { get; set; }
        [NotMapped]
        public List<Ability> SavingThrows
        {
            get { return _SavingThrows == null ? null : JsonConvert.DeserializeObject<List<Ability>>(_SavingThrows); }
            set { _SavingThrows = JsonConvert.SerializeObject(value); }
        }
        public int NumberOfSkillProficiencies { get; set; }
        [Required]
        internal string _SkillChoices { get; set; }
        [NotMapped]
        public List<Skill> SkillChoices
        {
            get { return _SkillChoices == null ? null : JsonConvert.DeserializeObject<List<Skill>>(_SkillChoices); }
            set { _SkillChoices = JsonConvert.SerializeObject(value); }
        }
        internal string _Features { get; set; }
        [NotMapped]
        public Dictionary<string, string> Features
        {
            get { return _Features == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Features); }
            set { _Features = JsonConvert.SerializeObject(value); }
        }
        public virtual ICollection<Subclass> Subclasses { get; set; }
    }
}
