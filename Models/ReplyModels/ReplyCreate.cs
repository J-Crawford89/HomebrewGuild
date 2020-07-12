using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ReplyModels
{
    public class ReplyCreate
    {
        public string Content { get; set; }
        public int CommentId { get; set; }
    }
}
