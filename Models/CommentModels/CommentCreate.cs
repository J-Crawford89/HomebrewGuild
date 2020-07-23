using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommentModels
{
    public class CommentCreate
    {
        public string Content { get; set; }
        public int ParentId { get; set; }
    }
}
