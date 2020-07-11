using Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICommentService
    {
        IEnumerable<CommentListItem> GetAllCommentsByEntityId(int entityId);
        bool Create(CommentCreate model, int entityId);
        bool Edit(CommentEdit model, int id);
        bool Delete(int id);
    }
}
