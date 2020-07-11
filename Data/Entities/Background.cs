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
    public class Background
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        internal string _SkillProficiencies { get; set; }
        [NotMapped]
        public List<Skill> SkillProficiencies
        {
            get { return _SkillProficiencies == null ? null : JsonConvert.DeserializeObject<List<Skill>>(_SkillProficiencies); }
            set { _SkillProficiencies = JsonConvert.SerializeObject(value); }
        }
    }
}
