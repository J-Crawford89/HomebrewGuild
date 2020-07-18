using Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserCharacterService
    {
        bool Create(CharacterCreate model);
        bool Edit(CharacterEdit model);
        bool Delete(int id);
        IEnumerable<CharacterListItem> GetAllUserCharacters();
        CharacterDetail GetCharacterDetailById(int id);
    }
}
