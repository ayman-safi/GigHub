using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Models
{
    public class Notification
    {

        public int Id { get;private set; }

        public DateTime Datetime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OrginalDateTime { get; private set; }

        public string OrginalVenue { get; private set; }

        [Required]
        public GIg Gig { get; private set; }
        protected  Notification()
        {
                
        }

        private Notification(NotificationType type,GIg gig)
        {
  
            if (gig == null)
                throw new ArgumentNullException("Gig");
            Datetime = DateTime.Now;
            Type = type;
            Gig = gig;
        }

        public static Notification GigCreated(GIg gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        }

        public static Notification GigUpdated(GIg newgig, DateTime orginalDateTime , string orginalVenue)
        {
            var notification = new Notification(NotificationType.GigUpdated, newgig);
            // get the values before updating it
            notification.OrginalDateTime = orginalDateTime;
            notification.OrginalVenue = orginalVenue;
            return notification;
        }

        public static Notification GigCanceled(GIg gig)
        {
            return new Notification(NotificationType.GigCanceled, gig);
        }
    }
}