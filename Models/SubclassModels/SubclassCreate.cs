using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SubclassModels
{
    public class SubclassCreate
    {
        public string Name { get; set; }
        public Dictionary<string, string> Features { get; set; }
        public int CharacterClassId { get; set; }
    }
}
