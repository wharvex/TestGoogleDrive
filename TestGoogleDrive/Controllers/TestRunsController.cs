using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestGoogleDrive.Data;
using TestGoogleDrive.Models;

namespace TestGoogleDrive.Controllers
{
    public class TestRunsController : Controller
    {
        private readonly TestGoogleDriveContext _context;

        public TestRunsController(TestGoogleDriveContext context)
        {
            _context = context;
        }

        // GET: TestRuns
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestRun.ToListAsync());
        }

        // GET: TestRuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testRun = await _context.TestRun.FirstOrDefaultAsync(m => m.Id == id);
            if (testRun == null)
            {
                return NotFound();
            }

            return View(testRun);
        }

        // GET: TestRuns/Create
        public IActionResult Create()
        {
            ViewData["commits"] = new SelectList(
                _context.Commit.ToList(),
                nameof(Commit.Id),
                nameof(Commit.Name)
            );
            ViewData["configs"] = new SelectList(
                _context.Config.ToList(),
                nameof(Config.Id),
                nameof(Config.Name)
            );
            return View();
        }

        // POST: TestRuns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,CommitId,ConfigId,AppearsExactlyOnce,NotUnderPlainDrives,OpensMyDriveDirectly"
            )]
                TestRun testRun
        )
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Invalid model state");
                return View(testRun);
            }
            testRun.CommitName = _context.Find<Commit>(testRun.CommitId)?.Name ?? "??";
            testRun.ConfigName = _context.Find<Config>(testRun.ConfigId)?.Name ?? "??";
            _context.Add(testRun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TestRuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testRun = await _context.TestRun.FindAsync(id);
            if (testRun == null)
            {
                return NotFound();
            }
            return View(testRun);
        }

        // POST: TestRuns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind(
                "Id,IsDriveLetter,IsMirrored,AppearsExactlyOnce,NotUnderPlainDrives,OpensMyDriveDirectly"
            )]
                TestRun testRun
        )
        {
            if (id != testRun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testRun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestRunExists(testRun.Id))
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
            return View(testRun);
        }

        // GET: TestRuns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testRun = await _context.TestRun.FirstOrDefaultAsync(m => m.Id == id);
            if (testRun == null)
            {
                return NotFound();
            }

            return View(testRun);
        }

        // POST: TestRuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testRun = await _context.TestRun.FindAsync(id);
            if (testRun != null)
            {
                _context.TestRun.Remove(testRun);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetConfigPath(int configId)
        {
            var configPath = _context.Find<ConfigPath>(configId)?.Path ?? "??";

            return Json(new { configPath });
        }

        private bool TestRunExists(int id)
        {
            return _context.TestRun.Any(e => e.Id == id);
        }
    }
}
