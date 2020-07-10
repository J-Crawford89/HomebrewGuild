using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.ActionsFeaturesTraits
{
    public class MonsterTrait : ActionFeatureTrait
    {
        [Required]
        [ForeignKey("Monster")]
        public int MonsterId { get; set; }
        public virtual Monster Monster { get; set; }
    }
}
