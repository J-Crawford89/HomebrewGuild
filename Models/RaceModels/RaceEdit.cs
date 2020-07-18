using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.RaceModels
{
    public class RaceEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Ability Score Increase")]
        public Dictionary<Ability, string> AbilityScoreIncrease { get; set; }
        public Size Size { get; set; }
        public string Speed { get; set; }
        [Display(Name = "Darkvision")]
        public bool HasDarkvision { get; set; }
        public Dictionary<string, string> Traits { get; set; }
    }
}
