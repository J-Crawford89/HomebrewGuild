using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.SpellModels
{
    public class SpellDetail
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }
        [Display(Name ="Spell Level")]
        public int SpellLevel { get; set; }
        public School School { get; set; }
        [Display(Name ="Ritual")]
        public bool IsRitual { get; set; }
        [Display(Name ="Concentration")]
        public bool RequiresConcentration { get; set; }
        [Display(Name = "Casting Time")]
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public List<SpellComponent> Components { get; set; }
        [Display(Name ="Material Component")]
        public string MaterialComponent { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        [Display(Name ="Class Spell Lists")]
        public ICollection<int> ClassIds { get; set; }
        [Display(Name ="Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name ="Last Updated")]
        public DateTime? LastUpdated { get; set; }
    }
}
