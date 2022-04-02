using Ploomes.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploomes.Business.Notifications
{
    public class Notifier : INotifier
    {

        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }


        public bool ExistNotification()
        {
            return _notifications.Any();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
