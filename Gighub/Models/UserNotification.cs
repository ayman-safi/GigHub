using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gighub.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order =1)]
        public string UserId { get; private set; }

        [Key]
        [Column(Order =2)]
        public int NotificationId { get; private set; }

        // make it private not to change it to makesure about the valid state
        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

      
        protected UserNotification()
        {
            // we make an empty construcor for the entityframework in the run time
        }
        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (notification == null)
                throw new ArgumentNullException("notification");
            User = user;
            Notification = notification;
        }
        public void Read()
        {
            IsRead = true;
        }
    }
}