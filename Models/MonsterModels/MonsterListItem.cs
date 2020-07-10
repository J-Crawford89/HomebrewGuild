using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.MonsterModels
{
    public class MonsterListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public MonsterType Type { get; set; }
        [Display(Name="Challenge Rating")]
        public string ChallengeRating { get; set; }
    }
}
