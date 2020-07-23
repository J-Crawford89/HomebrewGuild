using Models.MonsterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMonsterService
    {
        IEnumerable<MonsterListItem> GetAllMonsters();
        MonsterDetailView GetMonsterDetailViewById(int id);
    }
}
