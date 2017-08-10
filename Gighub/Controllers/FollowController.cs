using Gighub.DTO;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Gighub.Controllers
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
        public IHttpActionResult follow(followDto dto) {
            var userId = User.Identity.GetUserId();
            // var follow= _context.Following

            return Ok();
        }
    }
}
