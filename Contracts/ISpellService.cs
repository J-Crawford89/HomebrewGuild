using Models.SpellModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISpellService
    {
        IEnumerable<SpellListItem> GetAllSpells();
        SpellDetail GetSpellDetailById(int id);
    }
}
