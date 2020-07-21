using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SubclassModels
{
    public class SubclassEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Features { get; set; }
        public int CharacterClassId { get; set; }
        public IEnumerable<SelectListItem> CharacterClasses { get; set; }
    }
}
