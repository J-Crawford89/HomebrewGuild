using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.SubraceModels
{
    public class SubraceDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Ability Score Increase")]
        public Dictionary<Ability, string> AbilityScoreIncrease { get; set; }
        public Dictionary<string, string> Traits { get; set; }
    }
}
