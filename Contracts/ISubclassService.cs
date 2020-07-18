using Data.Entities;
using Models.SubclassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubclassService
    {
        bool Create(SubclassCreate model);
        bool Edit(SubclassEdit model);
        bool Delete(int id);
        IEnumerable<SubclassListItem> GetAllSubclasses();
        SubclassDetail GetSubclassDetailById(int id);
    }
}
