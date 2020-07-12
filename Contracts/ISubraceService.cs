using Models.SubraceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubraceService
    {
        bool Create(SubraceCreate model);
        bool Edit(SubraceEdit model);
        bool Delete(int id);
        IEnumerable<SubraceListItem> GetAllSubraces();
        SubraceDetail GetSubraceDetailById(int id);
    }
}
