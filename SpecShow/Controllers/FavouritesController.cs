using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpecShow.Data;
using SpecShow.Models;

namespace SpecShow.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly SpecShowContext _context;
        private readonly string _sessionName = "UserID";

        public FavouritesController(SpecShowContext context)
        {
            _context = context;
        }

        // GET: Favourites
        public async Task<IActionResult> Index()
        {
            int? loggedUserId = HttpContext.Session.GetInt32(_sessionName);
            var specShowContext = _context.Favourites.Where(f=> f.UserID == loggedUserId);
            return View(await specShowContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddFavourite(int mobileId)
        {
            var userId = HttpContext.Session.GetInt32(_sessionName);

            if (userId == null)
            {
                return RedirectToAction("Login","Home");
            }

            var favourite = new Favourite
            {
                MobileID = mobileId,
                UserID = userId.Value
            };

            _context.Favourites.Add(favourite);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFavourite(int favouritesId)
        {
            var favourite = await _context.Favourites.FindAsync(favouritesId);
                // Remove the favorite from the database
                if (favourite != null)
                {
                    _context.Favourites.Remove(favourite);
                    await _context.SaveChangesAsync();
                }
            return Json(new { success = true });
        }

    }
}
