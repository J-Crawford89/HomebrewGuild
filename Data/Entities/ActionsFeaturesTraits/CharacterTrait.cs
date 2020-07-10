using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.ActionsFeaturesTraits
{
    public class CharacterTrait : ActionFeatureTrait
    {
        [ForeignKey("Race")]
        public int? RaceId { get; set; }
        public virtual Race Race { get; set; }
        [ForeignKey("Subrace")]
        public int? SubraceId { get; set; }
        public virtual Subrace Subrace { get; set; }
    }
}
