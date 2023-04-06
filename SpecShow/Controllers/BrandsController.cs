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
    public class BrandsController : Controller
    {
        private readonly SpecShowContext _context;

        public BrandsController(SpecShowContext context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
              return _context.Brands != null ? 
                          View(await _context.Brands.ToListAsync()) :
                          Problem("Entity set 'SpecShowContext.Brands'  is null.");
        }

		// GET: Brands/Samsung
		public async Task<IActionResult> Samsung()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "Samsung").ToListAsync());
		}
		// GET: Brands/Samsung
		public async Task<IActionResult> Apple()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "Apple").ToListAsync());
		}
		// GET: Brands/Samsung
		public async Task<IActionResult> Nokia()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "Nokia").ToListAsync());
		}
		// GET: Brands/Samsung
		public async Task<IActionResult> Redmi()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "Redmi").ToListAsync());
		}
		// GET: Brands/Samsung
		public async Task<IActionResult> OnePlus()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "OnePlus").ToListAsync());
		}
		// GET: Brands/Samsung
		public async Task<IActionResult> Vivo()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "Vivo").ToListAsync());
		}
		// GET: Brands/Samsung
		public async Task<IActionResult> Oppo()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "Oppo").ToListAsync());
		}
		// GET: Brands/Samsung
		public async Task<IActionResult> Realme()
		{
			return View(_context.Mobiles.Where(m => m.Brand == "Realme").ToListAsync());
		}


	}
}
