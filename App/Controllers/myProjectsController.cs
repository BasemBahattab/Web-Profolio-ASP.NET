using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Profolio_ASP.NET_MVC.Data;
using Profolio_ASP.NET_MVC.Models;

namespace Profolio_ASP.NET_MVC.Controllers
{
    public class myProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public myProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: myProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.myProject.ToListAsync());
        }

        // GET: myProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProject = await _context.myProject
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myProject == null)
            {
                return NotFound();
            }

            return View(myProject);
        }

        // GET: myProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: myProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Tools,images")] myProject myProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myProject);
        }

        // GET: myProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProject = await _context.myProject.FindAsync(id);
            if (myProject == null)
            {
                return NotFound();
            }
            return View(myProject);
        }

        // POST: myProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Tools,images")] myProject myProject)
        {
            if (id != myProject.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!myProjectExists(myProject.ID))
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
            return View(myProject);
        }

        // GET: myProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProject = await _context.myProject
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myProject == null)
            {
                return NotFound();
            }

            return View(myProject);
        }

        // POST: myProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myProject = await _context.myProject.FindAsync(id);
            if (myProject != null)
            {
                _context.myProject.Remove(myProject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool myProjectExists(int id)
        {
            return _context.myProject.Any(e => e.ID == id);
        }
    }
}
