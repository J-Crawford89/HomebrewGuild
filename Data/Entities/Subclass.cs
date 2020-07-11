using Newtonsoft.Json;
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
        internal string _Features { get; set; }
        [NotMapped]
        public Dictionary<string, string> Features
        {
            get { return _Features == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Features); }
            set { _Features = JsonConvert.SerializeObject(value); }
        }
        [Required]
        [ForeignKey("CharacterClass")]
        public int CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
    }
}
