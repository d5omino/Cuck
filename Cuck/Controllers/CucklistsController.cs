using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cuck.Data;
using Cuck.Models;

namespace Cuck.Controllers
{
    public class CucklistsController : Controller
    {
        private readonly CuckContext _context;

        public CucklistsController(CuckContext context)
        {
            _context = context;
        }

        // GET: Cucklists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cucklist.ToListAsync());
        }

        // GET: Cucklists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cucklist = await _context.Cucklist
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cucklist == null)
            {
                return NotFound();
            }

            return View(cucklist);
        }

        // GET: Cucklists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cucklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListType,Title,Name,Url,Topic,Description,Rating,When,Privacy")] Cucklist cucklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cucklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cucklist);
        }

        // GET: Cucklists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cucklist = await _context.Cucklist.SingleOrDefaultAsync(m => m.Id == id);
            if (cucklist == null)
            {
                return NotFound();
            }
            return View(cucklist);
        }

        // POST: Cucklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListType,Title,Name,Url,Topic,Description,Rating,When,Privacy")] Cucklist cucklist)
        {
            if (id != cucklist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cucklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CucklistExists(cucklist.Id))
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
            return View(cucklist);
        }

        // GET: Cucklists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cucklist = await _context.Cucklist
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cucklist == null)
            {
                return NotFound();
            }

            return View(cucklist);
        }

        // POST: Cucklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cucklist = await _context.Cucklist.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cucklist.Remove(cucklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CucklistExists(int id)
        {
            return _context.Cucklist.Any(e => e.Id == id);
        }
    }
}
