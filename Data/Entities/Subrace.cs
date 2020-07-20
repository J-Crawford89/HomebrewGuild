using Newtonsoft.Json;
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
        internal string _AbilityScoreIncrease { get; set; }
        [NotMapped]
        public Dictionary<Ability, string> AbilityScoreIncrease
        {
            get { return _AbilityScoreIncrease == null ? null : JsonConvert.DeserializeObject<Dictionary<Ability, string>>(_AbilityScoreIncrease); }
            set { _AbilityScoreIncrease = JsonConvert.SerializeObject(value); }
        }
        internal string _Traits { get; set; }
        [NotMapped]
        public Dictionary<string, string> Traits
        {
            get { return _Traits == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(_Traits); }
            set { _Traits = JsonConvert.SerializeObject(value); }
        }
        [Required]
        [ForeignKey("Race")]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}
