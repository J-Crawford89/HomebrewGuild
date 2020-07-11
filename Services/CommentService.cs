using Contracts;
using Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : ICommentService
    {
        public bool Create(CommentCreate model, int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(CommentEdit model, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentListItem> GetAllCommentsByEntityId(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
