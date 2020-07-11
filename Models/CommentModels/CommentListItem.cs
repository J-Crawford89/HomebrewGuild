using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.CommentModels
{
    public class CommentListItem
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        [Display(Name ="DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime? LastUpdated { get; set; }
    }
}
