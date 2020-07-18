using Models.CharacterClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICharacterClassService
    {
        bool Create(CharacterClassCreate model);
        bool Edit(CharacterClassEdit model);
        bool Delete(int id);
        IEnumerable<CharacterClassListItem> GetAllCharacterClasses();
        CharacterClassDetail GetCharacterClassDetailById(int id);
    }
}
