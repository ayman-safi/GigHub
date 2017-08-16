using Gighub.DTO;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendanceController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend ( AttendanceDto dto ) {
            var userId = User.Identity.GetUserId();
            var exist = _context.Attendances
                .Any(a => a.AttendeeId == userId && a.GIgId == dto.gigId);
            if (exist)
                return BadRequest("the attendnce is alreaady exists");
            var attendance = new Attendance
            {
                GIgId = dto.gigId ,
                AttendeeId =  userId 
                
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok(); 
        }
    }
}
