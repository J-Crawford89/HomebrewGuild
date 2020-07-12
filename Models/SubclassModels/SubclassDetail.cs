using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SubclassModels
{
    public class SubclassDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Features { get; set; }
    }
}
