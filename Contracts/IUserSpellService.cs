using Models.SpellModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserSpellService
    {
        bool Create(SpellCreate model);
        bool Edit(SpellEdit model);
        bool Delete(int id);
        IEnumerable<SpellListItem> GetAllUserSpells();
        SpellDetail GetSpellDetailById(int id);
    }
}
