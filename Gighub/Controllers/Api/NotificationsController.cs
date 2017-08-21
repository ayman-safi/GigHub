using AutoMapper;
using Gighub.DTO;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
namespace Gighub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notification = _context.UserNotifications
                .Where(u => u.UserId == userId && !u.IsRead)
                .Select(u => u.Notification)
                .Include(u=>u.Gig.Artist)
                //.ProjectTo<NotificationDto>() and returb the ob
                .ToList();
            return notification.Select(Mapper.Map<Notification,NotificationDto>);

                // the traditionl way to implment mapping

            //return notification.Select(a => new NotificationDto
            //{
            //    Datetime = a.Datetime,
            //    Type = a.Type,
            //    OrginalDateTime = a.OrginalDateTime,
            //    OrginalVenue = a.OrginalVenue,
            //    Gig = new GigDto
            //    {
            //        Artist = new UserDto
            //        {
            //            Id = a.Gig.Artist.Id,
            //            Name=a.Gig.Artist.Name
            //        },
            //        DateTime=a.Gig.DateTime,
            //        Id=a.Gig.Id,
            //        IsCanceled=a.Gig.IsCanceled

            //     }


            //});
        }
    }
}
