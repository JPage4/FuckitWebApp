using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuckItWebApp.Data;
using FuckItWebApp.Models;

namespace FuckItWebApp.Controllers
{
    public class FuckitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuckitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fuckit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fuckit.ToListAsync());
        }

        // GET: Fuckit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuckit = await _context.Fuckit
                .SingleOrDefaultAsync(m => m.FuckitId == id);
            if (fuckit == null)
            {
                return NotFound();
            }

            return View(fuckit);
        }

        // GET: Fuckit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fuckit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuckitId,Name,Quantity")] Fuckit fuckit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuckit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuckit);
        }

        // GET: Fuckit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuckit = await _context.Fuckit.SingleOrDefaultAsync(m => m.FuckitId == id);
            if (fuckit == null)
            {
                return NotFound();
            }
            return View(fuckit);
        }

        // POST: Fuckit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuckitId,Name,Quantity")] Fuckit fuckit)
        {
            if (id != fuckit.FuckitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuckit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuckitExists(fuckit.FuckitId))
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
            return View(fuckit);
        }

        // GET: Fuckit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuckit = await _context.Fuckit
                .SingleOrDefaultAsync(m => m.FuckitId == id);
            if (fuckit == null)
            {
                return NotFound();
            }

            return View(fuckit);
        }

        // POST: Fuckit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuckit = await _context.Fuckit.SingleOrDefaultAsync(m => m.FuckitId == id);
            _context.Fuckit.Remove(fuckit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuckitExists(int id)
        {
            return _context.Fuckit.Any(e => e.FuckitId == id);
        }
    }
}
