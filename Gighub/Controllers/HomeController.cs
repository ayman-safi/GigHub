using Gighub.Models;
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
        public ActionResult Index()
        {
            // notice that include is in using.system.data.entity
            var upcominggigs = _context.Gigs.
                Include(m => m.Artist).
                Include(m => m.Genre).
                Where(g => g.DateTime > DateTime.Now);
            return View(upcominggigs);
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