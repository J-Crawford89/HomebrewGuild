using Models.RaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRaceService
    {
        bool Create(RaceCreate model);
        bool Edit(RaceEdit model);
        bool Delete(int id);
        IEnumerable<RaceListItem> GetAllRaces();
        RaceDetail GetRaceDetailById(int id);
    }
}
