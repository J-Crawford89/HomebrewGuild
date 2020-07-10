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
        public Dictionary<Ability, string> SavingThrows { get; set; }
        public Dictionary<Skill, string> Skills { get; set; }
        public string Vulnerabilities { get; set; }
        public string Resistances { get; set; }
        public string Immunities { get; set; }
        public string Senses { get; set; }
        public string Languages { get; set; }
        [Required]
        public string ChallengeRating { get; set; }
        public virtual ICollection<MonsterTrait> Traits { get; set; }
        public virtual ICollection<MonsterAction> Actions { get; set; }
        public virtual ICollection<MonsterReaction> Reactions { get; set; }
        [Required]
        public int NumberOfLegendaryActions { get; set; }
        public virtual ICollection<LegendaryAction> LegendaryActions { get; set; }
        public virtual ICollection<LairAction> LairActions { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
