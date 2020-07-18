using Models.BackgroundModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBackgroundService
    {
        bool Create(BackgroundCreate model);
        bool Edit(BackgroundEdit model);
        bool Delete(int id);
        IEnumerable<BackgroundListItem> GetAllBackgrounds();
        BackgroundDetail GetBackgroundById(int id);
    }
}
