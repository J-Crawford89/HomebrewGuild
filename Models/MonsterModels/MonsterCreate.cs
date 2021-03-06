﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.MonsterModels
{
    public class MonsterCreate
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public MonsterType Type { get; set; }
        public Alignment Alignment { get; set; }
        [Display(Name="Armor Class")]
        public int ArmorClass { get; set; }
        [Display(Name="Armor Type")]
        public string ArmorType { get; set; }
        [Display(Name ="Hit Points")]
        public int HitPoints { get; set; }
        [Display(Name ="Hit Point Equation")]
        public string HitPointEquation { get; set; }
        public string Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        [Display(Name = "Saving Throws")]
        public Dictionary<Ability, string> SavingThrows { get; set; } = new Dictionary<Ability, string>();
        public Dictionary<Skill, string> Skills { get; set; } = new Dictionary<Skill, string>();
        public string Vulnerabilities { get; set; }
        public string Resistances { get; set; }
        public string Immunities { get; set; }
        public string Senses { get; set; }
        public string Languages { get; set; }
        [Display(Name="Challenge Rating")]
        public string ChallengeRating { get; set; }
        public Dictionary<string, string> Traits { get; set; } = new Dictionary<string, string>();
        public Dictionary<string,string> Actions { get; set; }
        public Dictionary<string,string> Reactions { get; set; }
        [Display(Name="Legendary Actions per Round")]
        public int NumberOfLegendaryActions { get; set; }
        [Display(Name="Legendary Actions")]
        public Dictionary<string,string> LegendaryActions { get; set; }
        [Display(Name ="Lair Actions")]
        public Dictionary<string,string> LairActions { get; set; }
    }
}
