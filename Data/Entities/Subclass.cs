using Data.Entities.ActionsFeaturesTraits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Subclass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<CharacterFeature> Features { get; set; }
        [Required]
        [ForeignKey("CharacterClass")]
        public int CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
    }
}
