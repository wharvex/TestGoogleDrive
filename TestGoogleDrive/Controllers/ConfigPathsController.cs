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
    public class ConfigPathsController : Controller
    {
        private readonly TestGoogleDriveContext _context;

        public ConfigPathsController(TestGoogleDriveContext context)
        {
            _context = context;
        }

        // GET: ConfigPaths
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConfigPath.ToListAsync());
        }

        // GET: ConfigPaths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configPath = await _context.ConfigPath.FirstOrDefaultAsync(m => m.Id == id);
            if (configPath == null)
            {
                return NotFound();
            }

            return View(configPath);
        }

        // GET: ConfigPaths/Create
        public IActionResult Create()
        {
            ViewData["configs"] = new SelectList(
                _context.Config.ToList(),
                nameof(Config.Id),
                nameof(Config.Name)
            );
            return View();
        }

        // POST: ConfigPaths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConfigId,Path")] ConfigPath configPath)
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Invalid model state");
                return View(configPath);
            }
            configPath.ConfigName = _context.Find<Config>(configPath.ConfigId)?.Name ?? "??";
            _context.Add(configPath);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ConfigPaths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configPath = await _context.ConfigPath.FindAsync(id);
            if (configPath == null)
            {
                return NotFound();
            }
            return View(configPath);
        }

        // POST: ConfigPaths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Path,StreamLoc,Syncing")] ConfigPath configPath
        )
        {
            if (id != configPath.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configPath);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigPathExists(configPath.Id))
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
            return View(configPath);
        }

        // GET: ConfigPaths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configPath = await _context.ConfigPath.FirstOrDefaultAsync(m => m.Id == id);
            if (configPath == null)
            {
                return NotFound();
            }

            return View(configPath);
        }

        // POST: ConfigPaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configPath = await _context.ConfigPath.FindAsync(id);
            if (configPath != null)
            {
                _context.ConfigPath.Remove(configPath);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigPathExists(int id)
        {
            return _context.ConfigPath.Any(e => e.Id == id);
        }
    }
}
