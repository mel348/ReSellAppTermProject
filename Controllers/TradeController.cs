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
    public class TradeController : Controller
    {
        private readonly ReSellAppContext _context;

        public TradeController(ReSellAppContext context)
        {
            _context = context;
        }

        // GET: Trade
        public async Task<IActionResult> Index()
        {
            var reSellAppContext = _context.Trades.Include(t => t.Sellers);
            return View(await reSellAppContext.ToListAsync());
        }

        // GET: Trade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trades
                .Include(t => t.Sellers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // GET: Trade/Create
        public IActionResult Create()
        {
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID");
            return View();
        }

        // POST: Trade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TradeItem,City,State,Zipcode,Description,SellersID")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", trade.SellersID);
            return View(trade);
        }

        // GET: Trade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trades.FindAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", trade.SellersID);
            return View(trade);
        }

        // POST: Trade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TradeItem,City,State,Zipcode,Description,SellersID")] Trade trade)
        {
            if (id != trade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeExists(trade.ID))
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
            ViewData["SellersID"] = new SelectList(_context.Sellers, "ID", "ID", trade.SellersID);
            return View(trade);
        }

        // GET: Trade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trades
                .Include(t => t.Sellers)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // POST: Trade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trade = await _context.Trades.FindAsync(id);
            _context.Trades.Remove(trade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradeExists(int id)
        {
            return _context.Trades.Any(e => e.ID == id);
        }
    }
}
