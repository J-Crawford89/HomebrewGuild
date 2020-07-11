using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        [ForeignKey("Character")]
        public int? CharacterId { get; set; }
        public virtual Character Character { get; set; }
        [ForeignKey("Monster")]
        public int? MonsterId { get; set; }
        public virtual Monster Monster { get; set; }
        [ForeignKey("Spell")]
        public int? SpellId { get; set; }
        public virtual Spell Spell { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public bool IsDeleted { get; set; }
    }
}
