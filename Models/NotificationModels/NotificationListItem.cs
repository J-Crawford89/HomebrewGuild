using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.NotificationModels
{
    public class NotificationListItem
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int? CommentId { get; set; }
        public int? ReplyId { get; set; }
        public int? MonsterId { get; set; }
        public int? SpellId { get; set; }
        public bool IsRead { get; set; }
    }
}
