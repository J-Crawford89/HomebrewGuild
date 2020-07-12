using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.SpellModels
{
    public class SpellListItem
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }
        [Display(Name="Spell Level")]
        public int SpellLevel { get; set; }
        [Display(Name = "Ritual")]
        public bool IsRitual { get; set; }
        [Display(Name ="Concentration")]
        public bool RequiresConcentration { get; set; }
        public List<SpellComponent> Components { get; set; }
        [Display(Name ="Class Spell Lists")]
        public ICollection<int> ClassIds { get; set; }
    }
}
