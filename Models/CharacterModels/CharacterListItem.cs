using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CharacterModels
{
    public class CharacterListItem
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }
        public int RaceId { get; set; }
        public int CharacterClassId { get; set; }
        public int Level { get; set; }
    }
}
