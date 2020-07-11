using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommentModels
{
    public class CommentCreate
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Content { get; set; }
        public int? CharacterId { get; set; }
        public int? MonsterId { get; set; }
        public int? SpellId { get; set; }
    }
}
