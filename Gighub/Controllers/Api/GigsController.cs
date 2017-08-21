using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
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
            // we use attendances.select( s=> s.attendee) because it is an collection type 
            var gig = _context.Gigs.Include(a=> a.Attendances.Select(s =>s.Attendee))
                .Single(a => a.Id ==id && a.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();
            // we replace this few lines by using eager loading which join the atendances table with gig

            //var attendees = _context.Attendances
            //    .Where(a => a.GIgId == gig.Id)
            //    .Select(a => a.Attendee)
            //    .ToList();
            // for optimizing propose make method to implement the cancel function
            gig.Cancel();
            _context.SaveChanges();
            return Ok();
        }
    }
}
