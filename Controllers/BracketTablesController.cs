using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourneyBracket.Data;
using TourneyBracket.Models;

namespace TourneyBracket.Controllers
{
    public class BracketTablesController : Controller
    {
        private readonly BracketContext _context;

        public BracketTablesController(BracketContext context)
        {
            _context = context;
        }

        // GET: BracketTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.BracketTable.ToListAsync());
        }

        // GET: BracketTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bracketTable = await _context.BracketTable
                .FirstOrDefaultAsync(m => m.BracketID == id);
            if (bracketTable == null)
            {
                return NotFound();
            }

            return View(bracketTable);
        }

        // GET: BracketTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BracketTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BracketID,Name,RoundFormat,CreatedAt,Active,TeamTotal")] BracketTable bracketTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bracketTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bracketTable);
        }

        // GET: BracketTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bracketTable = await _context.BracketTable.FindAsync(id);
            if (bracketTable == null)
            {
                return NotFound();
            }
            return View(bracketTable);
        }

        // POST: BracketTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BracketID,Name,RoundFormat,CreatedAt,Active,TeamTotal")] BracketTable bracketTable)
        {
            if (id != bracketTable.BracketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bracketTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BracketTableExists(bracketTable.BracketID))
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
            return View(bracketTable);
        }

        // GET: BracketTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bracketTable = await _context.BracketTable
                .FirstOrDefaultAsync(m => m.BracketID == id);
            if (bracketTable == null)
            {
                return NotFound();
            }

            return View(bracketTable);
        }

        // POST: BracketTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bracketTable = await _context.BracketTable.FindAsync(id);
            _context.BracketTable.Remove(bracketTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BracketTableExists(int id)
        {
            return _context.BracketTable.Any(e => e.BracketID == id);
        }
    }
}
