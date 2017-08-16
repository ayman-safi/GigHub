using Gighub.DTO;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class FollowController : ApiController
    {
        private ApplicationDbContext _context;
        public FollowController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult following(followDto dto) {
            var userId = User.Identity.GetUserId();
            var exist = _context.Following
                .Any(a => a.FolloweeId == userId && a.FollowerId == dto.follow);
            if (exist)
                return BadRequest(" bad request ");
            var follow = new Following
            {
                FollowerId = userId ,
                FolloweeId = dto.follow

            };
            _context.Following.Add(follow);
            _context.SaveChanges();
            return Ok();
        }
    }
}
