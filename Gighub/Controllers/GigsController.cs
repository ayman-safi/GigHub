using Gighub.Models;
using Gighub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Gighub.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _Context;
        public GigsController()
        {
            _Context = new ApplicationDbContext();
        }
        [Authorize]
        // GET: Gigs
        public ActionResult Create()
        {
            var viewmodel = new GigFormViewModel
            {
                Genres = _Context.Genres.ToList()
            };
            return View(viewmodel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewmodel)
        {
            // makesure of the validation of the form properties 
            if (!ModelState.IsValid)
            {
               viewmodel.Genres = _Context.Genres.ToList();
                return View("Create", viewmodel);
            }
            
            var genre = _Context.Genres.Single(g => g.Id == viewmodel.Genre);
            var gig = new GIg
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewmodel.GetDateTime(),
                GenreId = viewmodel.Genre,
                Venue= viewmodel.Venue
            };
            _Context.Gigs.Add(gig);
            _Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}