using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.ActionsFeaturesTraits
{
    public class CharacterFeature : ActionFeatureTrait
    {
        [ForeignKey("CharacterClass")]
        public int? CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
        [ForeignKey("Subclass")]
        public int? SubclassId { get; set; }
        public virtual Subclass Subclass { get; set; }
    }
}
