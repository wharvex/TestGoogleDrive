using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestGoogleDrive.Data;
using TestGoogleDrive.Models;

namespace TestGoogleDrive.Controllers
{
    public class CommitsController : Controller
    {
        private readonly TestGoogleDriveContext _context;

        public CommitsController(TestGoogleDriveContext context)
        {
            _context = context;
        }

        // GET: Commits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Commit.ToListAsync());
        }

        // GET: Commits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commit = await _context.Commit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commit == null)
            {
                return NotFound();
            }

            return View(commit);
        }

        // GET: Commits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SourceCommit,ForkCommit")] Commit commit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commit);
        }

        // GET: Commits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commit = await _context.Commit.FindAsync(id);
            if (commit == null)
            {
                return NotFound();
            }
            return View(commit);
        }

        // POST: Commits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SourceCommit,ForkCommit")] Commit commit)
        {
            if (id != commit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommitExists(commit.Id))
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
            return View(commit);
        }

        // GET: Commits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commit = await _context.Commit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commit == null)
            {
                return NotFound();
            }

            return View(commit);
        }

        // POST: Commits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commit = await _context.Commit.FindAsync(id);
            if (commit != null)
            {
                _context.Commit.Remove(commit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommitExists(int id)
        {
            return _context.Commit.Any(e => e.Id == id);
        }
    }
}
