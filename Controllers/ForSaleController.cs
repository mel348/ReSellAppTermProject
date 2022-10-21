using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReSell.Models;
using ReSellApp.Models;

namespace ReSellApp.Controllers
{
    public class ForSaleController : Controller
    {
        private readonly ReSellAppContext _context;

        public ForSaleController(ReSellAppContext context)
        {
            _context = context;
        }

        // GET: ForSale
        public async Task<IActionResult> Index()
        {
            var reSellAppContext = _context.ForSale.Include(f => f.Sellers);
            return View(await reSellAppContext.ToListAsync());
        }

        // GET: ForSale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forSale = await _context.ForSale
                .Include(f => f.Sellers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (forSale == null)
            {
                return NotFound();
            }

            return View(forSale);
        }

        // GET: ForSale/Create
        public IActionResult Create()
        {
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID");
            return View();
        }

        // POST: ForSale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SaleItem,City,State,Zipcode,Price,Description,Email,SellersID")] ForSale forSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", forSale.SellersID);
            return View(forSale);
        }

        // GET: ForSale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forSale = await _context.ForSale.FindAsync(id);
            if (forSale == null)
            {
                return NotFound();
            }
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", forSale.SellersID);
            return View(forSale);
        }

        // POST: ForSale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SaleItem,City,State,Zipcode,Price,Description,Email,SellersID")] ForSale forSale)
        {
            if (id != forSale.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForSaleExists(forSale.ID))
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
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", forSale.SellersID);
            return View(forSale);
        }

        // GET: ForSale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forSale = await _context.ForSale
                .Include(f => f.Sellers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (forSale == null)
            {
                return NotFound();
            }

            return View(forSale);
        }

        // POST: ForSale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forSale = await _context.ForSale.FindAsync(id);
            _context.ForSale.Remove(forSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForSaleExists(int id)
        {
            return _context.ForSale.Any(e => e.ID == id);
        }
    }
}
