﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.SpellModels
{
    public class SpellCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Spell Level")]
        public int SpellLevel { get; set; }
        public School School { get; set; }
        [Display(Name="Ritual")]
        public bool IsRitual { get; set; }
        [Display(Name ="Concentration")]
        public bool RequiresConcentration { get; set; }
        [Display(Name="Casting Time")]
        [Required]
        public string CastingTime { get; set; }
        [Required]
        public string Range { get; set; }
        [Display(Name="Components")]
        public List<SpellComponent> Components { get; set; } = new List<SpellComponent>();
        [Display(Name="Material Component")]
        public string MaterialComponent { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name ="Class Spell Lists")]
        public ICollection<int> ClassIds { get; set; }
    }
}
