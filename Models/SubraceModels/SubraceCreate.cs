using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static Data.Enums;

namespace Models.SubraceModels
{
    public class SubraceCreate
    {
        public string Name { get; set; }
        [Display(Name="Ability Score Increase")]
        public Dictionary<Ability, string> AbilityScoreIncrease { get; set; }
        public Dictionary<string, string> Traits { get; set; }
        public int RaceId { get; set; }
        public IEnumerable<SelectListItem> Races { get; set; }
    }
}
