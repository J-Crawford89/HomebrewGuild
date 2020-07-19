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
    public class Spell
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int SpellLevel { get; set; }
        [Required]
        public School School { get; set; }
        [Required]
        public bool IsRitual { get; set; }
        [Required]
        public string Range { get; set; }
        [Required]
        public bool RequiresConcentration { get; set; }
        [Required]
        public string CastingTime { get; set; }
        [Required]
        internal string _Components { get; set; }
        [NotMapped]
        public List<SpellComponent> Components
        {
            get { return _Components == null ? null : JsonConvert.DeserializeObject<List<SpellComponent>>(_Components); }
            set { _Components = JsonConvert.SerializeObject(value); }
        }
        public string MaterialComponent { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        internal string _ClassIds { get; set; }
        [NotMapped]
        public ICollection<int> ClassIds
        {
            get { return _ClassIds == null ? null : JsonConvert.DeserializeObject<ICollection<int>>(_ClassIds); }
            set { _ClassIds = JsonConvert.SerializeObject(value); }
        }
        public virtual ICollection<Comment> Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
