using Gighub.Models;
using System;

namespace Gighub.DTO
{
    public class NotificationDto
    {

        public DateTime Datetime { get; set; }

        public NotificationType Type { get;  set; }

        public DateTime? OrginalDateTime { get; set; }

        public string OrginalVenue { get;  set; }

        public GigDto Gig { get;  set; }
    }
}