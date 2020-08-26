using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [ForeignKey("Comment")]
        public int? CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        [ForeignKey("Reply")]
        public int? ReplyId { get; set; }
        public virtual Reply Reply { get; set; }
        [ForeignKey("Monster")]
        public int? MonsterId { get; set; }
        public virtual Monster Monster { get; set; }
        [ForeignKey("Spell")]
        public int? SpellId { get; set; }
        public virtual Spell Spell { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsRead { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
