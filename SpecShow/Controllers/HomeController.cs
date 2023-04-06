using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpecShow.Data;
using SpecShow.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SpecShow.Controllers
{
    public class HomeController : Controller
    {
        private readonly SpecShowContext _context;
        public readonly string _sessionName = "UserID";
        public HomeController(SpecShowContext context)
        {
            _context = context;
        }

        // GET: Home/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] User user)
        {
            var loggedUser = await _context.Users.FirstOrDefaultAsync(m => m.UserName == user.UserName && m.Password == user.Password);
            if (loggedUser != null)
            {
                HttpContext.Session.SetInt32(_sessionName, loggedUser.UserID);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
              return _context.Mobiles != null ? 
                          View(await _context.Mobiles.ToListAsync()) :
                          Problem("Entity set 'SpecShowContext.Mobiles'  is null.");
        }

        // GET: Home/Search
        public IActionResult Search()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Search([Bind("MobileName")] Mobile mobile)
		{
			SearchViewModel searchViewModel = new SearchViewModel();
			searchViewModel.Mobiles = await _context.Mobiles.Where(m => m.MobileName.Contains(mobile.MobileName)).ToListAsync();
			return View(searchViewModel);
		}


		// GET: Home/GetSearchSuggestions
		public JsonResult GetSearchResults(string query)
        {
           var results = _context.Mobiles
                .Where(t => t.MobileName.Contains(query))
                .Select(t => t.MobileName)
                .Take(10)
                .ToList();

            return Json(results);
        }



        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.MobileID == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            var id = HttpContext.Session.GetInt32(_sessionName);
            if (id != null)
            {
                if (id == 1)
                {
                    return View();
                }
                else
                {
                    return Problem(
                title: "Unauthorized",
                detail: "You must be an admin to perform this action.",
                statusCode: (int)HttpStatusCode.Unauthorized,
                instance: HttpContext.Request.Path,
                type: "https://tools.ietf.org/html/rfc7235#section-3.1");
                }
            }
            return RedirectToAction(nameof(Login));        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MobileID,MobileName,Model,Price,Brand,ImageUrl,AmazonUrl,FlipkartUrl,ScreenSize,FrontCamera,BackCameras,OS,Sim,Sensors,BatteryCapacity,Colors,Variants,ReleaseDate,Weight,Material,ResistanceCertificate,ScreenType,AspectRatio,Resolution,OtherFeatures,Processor,Nanometer,GPU,AntutuScores,Bluetooth,ChargingCapacity,Rating")] Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobile);
        }
    }
}
