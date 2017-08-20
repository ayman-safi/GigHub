using Gighub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
           var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(a => a.Id ==id && a.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.IsCanceled = true;

            var notification = new Notification
            {
                Datetime= DateTime.Now,
                Type= NotificationType.GigCanceled,
                Gig=gig,
            };
            var attendees = _context.Attendances
                .Where(a => a.GIgId == gig.Id)
                .Select(a => a.Attendee)
                .ToList();

            foreach( var attendee in attendees)
            {
                var userNotification = new UserNotification
                {
                    User = attendee,
                    Notification= notification
                };
                _context.UserNotifications.Add(userNotification);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
