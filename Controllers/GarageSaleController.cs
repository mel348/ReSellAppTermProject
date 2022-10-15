using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReSell.Models;

namespace ReSellApp.Controllers
{
    public class GarageSaleController : Controller
    {
        private readonly ReSellAppContext _context;

        public GarageSaleController(ReSellAppContext context)
        {
            _context = context;
        }

        // GET: GarageSale
        public async Task<IActionResult> Index()
        {
            var reSellAppContext = _context.GarageSales.Include(g => g.Sellers);
            return View(await reSellAppContext.ToListAsync());
        }

        // GET: GarageSale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garageSales = await _context.GarageSales
                .Include(g => g.Sellers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (garageSales == null)
            {
                return NotFound();
            }

            return View(garageSales);
        }

        // GET: GarageSale/Create
        public IActionResult Create()
        {
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID");
            return View();
        }

        // POST: GarageSale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PostingTitle,Address,City,State,Zipcode,Description,Date,Time,SellersID")] GarageSales garageSales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garageSales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", garageSales.SellersID);
            return View(garageSales);
        }

        // GET: GarageSale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garageSales = await _context.GarageSales.FindAsync(id);
            if (garageSales == null)
            {
                return NotFound();
            }
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", garageSales.SellersID);
            return View(garageSales);
        }

        // POST: GarageSale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PostingTitle,Address,City,State,Zipcode,Description,Date,Time,SellersID")] GarageSales garageSales)
        {
            if (id != garageSales.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garageSales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarageSalesExists(garageSales.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", garageSales.SellersID);
            return View(garageSales);
        }

        // GET: GarageSale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garageSales = await _context.GarageSales
                .Include(g => g.Sellers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (garageSales == null)
            {
                return NotFound();
            }

            return View(garageSales);
        }

        // POST: GarageSale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garageSales = await _context.GarageSales.FindAsync(id);
            _context.GarageSales.Remove(garageSales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarageSalesExists(int id)
        {
            return _context.GarageSales.Any(e => e.ID == id);
        }
    }
}
