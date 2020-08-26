using Models.NotificationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface INotificationService
    {
        IEnumerable<NotificationListItem> GetAllNotificationsByUserId(Guid userId);
        bool CreateCommentNotification(NotificationCreate model);
        bool CreateReplyNotificationForContentCreator(NotificationCreate model);
        bool CreateReplyNotificationForCommentCreator(NotificationCreate model);
        bool CreateReplyNotificationForOtherReplyCreators(NotificationCreate model);
        bool MarkAsRead(int id);
        bool Delete(int id);
        void DeleteAll();
    }
}
