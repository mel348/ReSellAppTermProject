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
    public class SellerController : Controller
    {
        private readonly ReSellAppContext _context;

        public SellerController(ReSellAppContext context)
        {
            _context = context;
        }

        // GET: Seller
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sellers.ToListAsync());
        }

        // GET: Seller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellers = await _context.Sellers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sellers == null)
            {
                return NotFound();
            }

            return View(sellers);
        }

        // GET: Seller/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,City,State,Zipcode,Email")] Sellers sellers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellers);
        }

        // GET: Seller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellers = await _context.Sellers.FindAsync(id);
            if (sellers == null)
            {
                return NotFound();
            }
            return View(sellers);
        }

        // POST: Seller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,City,State,Zipcode,Email")] Sellers sellers)
        {
            if (id != sellers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellersExists(sellers.ID))
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
            return View(sellers);
        }

        // GET: Seller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellers = await _context.Sellers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sellers == null)
            {
                return NotFound();
            }

            return View(sellers);
        }

        // POST: Seller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellers = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(sellers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellersExists(int id)
        {
            return _context.Sellers.Any(e => e.ID == id);
        }
    }
}
