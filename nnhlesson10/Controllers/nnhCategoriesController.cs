using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nnhlesson09v2.Models;

namespace nnhlesson09v2.Controllers
{
    public class nnhCategoriesController : Controller
    {
        private readonly NnhBookStore01Context _context;

        public nnhCategoriesController(NnhBookStore01Context context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> nnhIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> nnhDetails(int? nnhId)
        {
            if (nnhId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == nnhId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult nnhCreate()
        {
           
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nnhCreate([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(nnhIndex));
            }
            return View(category);
        }



        //


        // GET: Categories/Edit/5
        public async Task<IActionResult> nnhEdit(int? nnhId)
        {
            if (nnhId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(nnhId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nnhEdit(int nnhId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (nnhId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(nnhIndex));
            }
            return View(category);
        }
        //




        // GET: Categories/Delete/5
        public async Task<IActionResult> nnhDelete(int? nnhId)
        {
            if (nnhId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == nnhId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("nnhDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nnhDeleteConfirmed(int nnhId)
        {
            var category = await _context.Categories.FindAsync(nnhId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(nnhIndex));
        }

        private bool CategoryExists(int nnhId)
        {
            return _context.Categories.Any(e => e.CategoryId == nnhId);
        }
    }
}
