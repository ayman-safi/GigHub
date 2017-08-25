using Gighub.Models;
using Gighub.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Gighub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string query=null)
        {
            // notice that include is in using.system.data.entity
            var upcominggigs = _context.Gigs.
                Include(m => m.Artist).
                Include(m => m.Genre).
                Where(g => g.DateTime > DateTime.Now);

            if (!string.IsNullOrWhiteSpace(query))
            {
                upcominggigs = upcominggigs
                    .Where(g =>
                    g.Artist.Name.Contains(query) ||
                    g.Genre.Name.Contains(query)||
                    g.Venue.Contains(query));
            }
            var viewmodel = new Homeviewmodel
            {
                Upcominggigs = upcominggigs,
                ShowActions = User.Identity.IsAuthenticated,
                heading = " Upcoming Gigs",
                SearchTerm = query
                
            };
            return View("gigs",viewmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}