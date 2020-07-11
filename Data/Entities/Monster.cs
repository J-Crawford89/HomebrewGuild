using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Data.Entities
{
    public class Monster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        public MonsterType Type { get; set; }
        [Required]
        public Alignment Alignment { get; set; }
        [Required]
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        [Required]
        public int HitPoints { get; set; }
        public string HitPointEquation { get; set; }
        [Required]
        public string Speed { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Charisma { get; set; }
        internal string _SavingThrows { get; set; }
        [NotMapped]
        public Dictionary<Ability, int> SavingThrows
        {
            get { return _SavingThrows == null ? null : JsonConvert.DeserializeObject<Dictionary<Ability, int>>(_SavingThrows); }
            set { _SavingThrows = JsonConvert.SerializeObject(value); }
        }
        internal string _Skills { get; set; }
        [NotMapped]
        public Dictionary<Skill, int> Skills
        {
            get { return _Skills == null ? null : JsonConvert.DeserializeObject<Dictionary<Skill, int> > (_Skills); }
            set { _Skills = JsonConvert.SerializeObject(value); }
        }
        public string Vulnerabilities { get; set; }
        public string Resistances { get; set; }
        public string Immunities { get; set; }
        public string Senses { get; set; }
        public string Languages { get; set; }
        [Required]
        public string ChallengeRating { get; set; }
        internal string _Traits { get; set; }
        [NotMapped]
        public Dictionary<string, string> Traits
        {
            get { return _Traits == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Traits); }
            set { _Traits = JsonConvert.SerializeObject(value); }
        }
        internal string _Actions { get; set; }
        [NotMapped]
        public Dictionary<string, string> Actions
        {
            get { return _Actions == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Actions); }
            set { _Actions = JsonConvert.SerializeObject(value); }
        }
        internal string _Reactions { get; set; }
        [NotMapped]
        public Dictionary<string, string> Reactions
        {
            get { return _Reactions == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Reactions); }
            set { _Reactions = JsonConvert.SerializeObject(value); }
        }
        [Required]
        public int NumberOfLegendaryActions { get; set; }
        internal string _LegendaryActions { get; set; }
        [NotMapped]
        public Dictionary<string, string> LegendaryActions
        {
            get { return _LegendaryActions == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_LegendaryActions); }
            set { _LegendaryActions = JsonConvert.SerializeObject(value); }
        }
        internal string _LairActions { get; set; }
        [NotMapped]
        public Dictionary<string, string> LairActions
        {
            get { return _LairActions == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_LairActions); }
            set { _LairActions = JsonConvert.SerializeObject(value); }
        }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
