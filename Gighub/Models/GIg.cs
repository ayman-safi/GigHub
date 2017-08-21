using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gighub.Models
{
    public class GIg
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }


        [Required]
        public string ArtistId { get; set; }

        public ApplicationUser Artist { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
        public ICollection<Attendance> Attendances { get; private set; }
        public GIg()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;
            // create an contructor inside the class to optimize the code
            var notification =  Notification.GigCanceled(this);
            foreach (var attendee in Attendances.Select(s => s.Attendee))
            {
                // now the code more clean by creating notify method in applicationuser class
                attendee.Notify(notification);
            }

        }
        public void modify(DateTime datetime, string venue,byte genre)
        {

            var notification = Notification.GigUpdated(this, DateTime, Venue);
            Venue = venue;
            GenreId = genre;
            DateTime = datetime;

            foreach (var attendee in Attendances.Select(b => b.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }


}