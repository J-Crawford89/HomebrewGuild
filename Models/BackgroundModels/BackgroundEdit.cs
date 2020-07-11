using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.BackgroundModels
{
    public class BackgroundEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Skill Proficiencies")]
        public List<Skill> SkillProficiencies { get; set; }
    }
}
