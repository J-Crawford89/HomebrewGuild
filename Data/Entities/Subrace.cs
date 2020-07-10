using Data.Entities.ActionsFeaturesTraits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Data.Entities
{
    public class Subrace
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Dictionary<Ability, string> AbilityScoreIncrease { get; set; }
        public virtual ICollection<CharacterTrait> Traits { get; set; }
        [Required]
        [ForeignKey("Race")]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}
