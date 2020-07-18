using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.CharacterModels
{
    public class CharacterCreate
    {
        public string Name { get; set; }
        public int RaceId { get; set; }
        public int? SubraceId { get; set; }
        public int CharacterClassId { get; set; }
        public int? SubclassId { get; set; }
        public int? MulticlassId { get; set; }
        public int? MulticlassSubclassId { get; set; }
        public int? SecondMulticlassId { get; set; }
        public int? SecondMulticlassSubclassId { get; set; }
        public int? BackgroundId { get; set; }
        public int Level { get; set; }
        [Display(Name ="Armor Class")]
        public int ArmorClass { get; set; }
        [Display(Name ="Hit Points")]
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        [Display(Name = "Saving Throws")]
        public List<Ability> SavingThrows { get; set; }
        public List<Skill> Skills { get; set; }
        [Display(Name ="Notable Inventory")]
        public Dictionary<string, string> NotableInventory { get; set; }
        public string Appearance { get; set; }
        public string Backstory { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
