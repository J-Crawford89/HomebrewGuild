using Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReplyService
    {
        bool Create(ReplyCreate model);
        bool Edit(ReplyEdit model);
        bool Delete(int id);
        IEnumerable<ReplyListItem> GetAllRepliesByCommentId(int commentId);
        ReplyListItem GetReplyById(int id);
    }
}
