﻿using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Data.Entities
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Race")]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
        [ForeignKey("Subrace")]
        public int? SubraceId { get; set; }
        public virtual Subrace Subrace { get; set; }
        [Required]
        [ForeignKey("CharacterClass")]
        public int CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
        [ForeignKey("Subclass")]
        public int? SubclassId { get; set; }
        public virtual Subclass Subclass { get; set; }
        [ForeignKey("Multiclass")]
        public int? MulticlassId { get; set; }
        public virtual CharacterClass Multiclass { get; set; }
        [ForeignKey("MulticlassSubclass")]
        public int? MulticlassSubclassId { get; set; }
        public virtual Subclass MulticlassSubclass { get; set; }
        [ForeignKey("SecondMulticlass")]
        public int? SecondMulticlassId { get; set; }
        public virtual CharacterClass SecondMulticlass { get; set; }
        [ForeignKey("SecondMulticlassSubclass")]
        public int? SecondMulticlassSubclassId { get; set; }
        public virtual Subclass SecondMulticlassSubclass { get; set; }
        [ForeignKey("Background")]
        public int? BackgroundId { get; set; }
        public virtual Background Background { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int ArmorClass { get; set; }
        [Required]
        public int HitPoints { get; set; }
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
        [Required]
        internal string _SavingThrows { get; set; }
        [NotMapped]
        public List<Ability> SavingThrows
        {
            get { return _SavingThrows == null ? null : JsonConvert.DeserializeObject<List<Ability>>(_SavingThrows); }
            set { _SavingThrows = JsonConvert.SerializeObject(value); }
        }
        [Required]
        internal string _Skills { get; set; }
        [NotMapped]
        public List<Skill> Skills
        {
            get { return _Skills == null ? null : JsonConvert.DeserializeObject<List<Skill>>(_Skills); }
            set { _Skills = JsonConvert.SerializeObject(value); }
        }
        internal string _NotableInventory { get; set; }
        [NotMapped]
        public Dictionary<string, string> NotableInventory 
        { 
            get { return _NotableInventory == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_NotableInventory); }
            set { _NotableInventory = JsonConvert.SerializeObject(value); } 
        }
        public string Appearance { get; set; }
        public string Backstory { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }
    }
}
