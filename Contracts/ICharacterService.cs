using Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICharacterService
    {
        IEnumerable<CharacterListItem> GetAllCharacters();
        CharacterDetail GetCharacterDetailById(int id);
    }
}
