using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Services
{
    public class EnumService
    {
        public string ConvertSkill(Skill skill)
        {
            switch (skill)
            {
                case Skill.AnimalHandling: return "Animal Handling";
                case Skill.SleightOfHand: return "Sleight of Hand";
                default: return skill.ToString();
            }
        }
    }
}
