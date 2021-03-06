﻿using Models.MonsterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserMonsterService
    {
        bool Create(MonsterCreate model);
        IEnumerable<MonsterListItem> GetAllUserMonsters();
        MonsterDetail GetMonsterDetailById(int id);
        bool Edit(MonsterEdit model);
        bool Delete(int id);
        MonsterDetailView GetMonsterDetailViewById(int id);
    }
}
