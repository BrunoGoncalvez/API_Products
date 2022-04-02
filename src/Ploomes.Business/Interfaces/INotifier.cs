using Ploomes.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ploomes.Business.Interfaces
{
    public interface INotifier 
    {

        bool ExistNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);

    }
}
