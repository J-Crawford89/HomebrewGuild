using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Data
{
    public class Enums
    {
        public enum MonsterType
        {
            Aberration,
            Beast,
            Celestial,
            Construct,
            Dragon,
            Elemental,
            Fey,
            Fiend,
            Giant,
            Humanoid,
            Monstrosity,
            Ooze,
            Plant,
            Undead
        }
        public enum Size
        {
            Tiny,
            Small,
            Medium,
            Large,
            Huge,
            Gargantuan
        }
        public enum Alignment
        {
            LG,
            NG,
            CG,
            LN,
            N,
            CN,
            LE,
            NE,
            CE,
            Unaligned
        }
        public enum Ability
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        }
        public enum Skill
        {
            Acrobatics,
            [System.ComponentModel.DataAnnotations.Display(Name ="Animal Handling")]
            AnimalHandling,
            Arcana,
            Athletics,
            Deception,
            History,
            Insight,
            Intimidation,
            Investigation,
            Medicine,
            Nature,
            Perception,
            Performance,
            Persuasion,
            Religion,
            [System.ComponentModel.DataAnnotations.Display(Name = "Sleight of Hand")]
            SleightOfHand,
            Stealth,
            Survival,
        }
        public enum School
        {
            Abjuration,
            Conjuration,
            Divination,
            Enchantment,
            Evocation,
            Illusion,
            Necromancy,
            Transmutation
        }
        public enum SpellComponent
        {
            Verbal,
            Somatic,
            Material
        }
    }
}
