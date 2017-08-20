using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Models
{
    public class Notification
    {

        public int Id { get; set; }

        public DateTime Datetime { get; set; }

        public NotificationType Type { get; set; }

        public DateTime? OrginalDateTime { get; set; }

        public string OrginalVenue { get; set; }

        [Required]
        public GIg Gig { get; set; }

       
    }
}