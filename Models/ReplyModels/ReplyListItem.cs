using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ReplyModels
{
    public class ReplyListItem
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        [Display(Name ="Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name ="Last Updated")]
        public DateTime LastUpdated { get; set; }
    }
}
