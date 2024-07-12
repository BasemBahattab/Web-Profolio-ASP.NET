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
    public class AboutMesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AboutMesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AboutMes
        public async Task<IActionResult> Index()
        {

            return View(await _context.AboutMe.ToListAsync());
        }

        // GET: AboutMes/ContactMe
        public async Task<IActionResult> ContactMe()
        {
            return View();
        }

        // GET: AboutMes/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // GET: AboutMes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutMes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /* */
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public async Task<IActionResult> Create([Bind("ID,AboutMeParagraph,PersonalImage,CV")] AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutMe);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Create));
            }
            return View(aboutMe);
        }

        //// GET: AboutMes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe.FindAsync(id);
            if (aboutMe == null)
            {
                return NotFound();
            }
            return View(aboutMe);
        }

        //// POST: AboutMes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AboutMeParagraph,PersonalImage,CV")] AboutMe aboutMe)
        {
            if (id != aboutMe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutMe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeExists(aboutMe.ID))
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
            return View(aboutMe);
        }

        // GET: AboutMes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // POST: AboutMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutMe = await _context.AboutMe.FindAsync(id);
            if (aboutMe != null)
            {
                _context.AboutMe.Remove(aboutMe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool AboutMeExists(int id)
        {
            return _context.AboutMe.Any(e => e.ID == id);
        }
    }
}
