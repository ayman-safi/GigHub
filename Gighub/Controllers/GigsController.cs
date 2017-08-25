using Gighub.Models;
using Gighub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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
                Genres = _Context.Genres.ToList(),
                heading = "Add a Gig"
            };
            return View("GigForm",viewmodel);
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
                return View("GigForm", viewmodel);
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
            return RedirectToAction("mine", "Gigs");
        }

        public ActionResult Search(Homeviewmodel viewmodel)
        {
            return RedirectToAction("Index", "Home", new { query = viewmodel.SearchTerm });
        }

        [Authorize]
        // GET: Gigs
        public ActionResult Edit(int Id)
        {
            var userId = User.Identity.GetUserId();
            var gigs = _Context.Gigs.Single(a => a.Id == Id && a.ArtistId == userId);
            var viewmodel = new GigFormViewModel
            {
                
                heading = "Edit a Gig",
                Genres = _Context.Genres.ToList(),
                Date= gigs.DateTime.ToString("d MMM yyyy"),
                Time =gigs.DateTime.ToString("hh:mm"),
                Genre=gigs.GenreId,
                Venue=gigs.Venue,
                Id = gigs.Id
        };
            return View("GigForm",viewmodel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GigFormViewModel viewmodel)
        {
            // makesure of the validation of the form properties 
            if (!ModelState.IsValid)
            {
                viewmodel.Genres = _Context.Genres.ToList();
                return View("GigForm", viewmodel);
            }
            var userId = User.Identity.GetUserId();
            var genre = _Context.Genres.Single(g => g.Id == viewmodel.Genre);
            // eager loading
            var gig = _Context.Gigs
                .Include(a => a.Attendances.Select(b=>b.Attendee))
                .Single(s => s.Id == viewmodel.Id && s.ArtistId == userId);
            gig.modify(viewmodel.GetDateTime(), viewmodel.Venue, viewmodel.Genre);
            _Context.SaveChanges();
            return RedirectToAction("mine", "Gigs");
        }

        [Authorize]
        public ActionResult attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _Context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .ToList();
            var viewmodel = new Homeviewmodel()
            {
                Upcominggigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                heading = " Gigs I'm attending "
            };
            return View("gigs", viewmodel);
        }
        public  ActionResult mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _Context.Gigs
                .Where(a => a.ArtistId == userId && a.DateTime > DateTime.Now && !a.IsCanceled)
                .Include(a=>a.Genre)
                .ToList();
            return View(gigs);
        }
    }
}

