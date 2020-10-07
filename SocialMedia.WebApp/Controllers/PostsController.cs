using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Entities.Models;
using SocialMedia.Entities.Models.Context;

namespace SocialMedia.WebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly SocialMediaContext _context;

        public PostsController(SocialMediaContext context)
        {
            _context = context;
        }

        // GET: AspNetPosts
        public async Task<IActionResult> Index()
        {
            var socialMediaContext = _context.AspNetPosts.Include(a => a.FkUser);
            return View(await socialMediaContext.ToListAsync());
        }

        // GET: AspNetPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetPosts = await _context.AspNetPosts
                .Include(a => a.FkUser)
                .FirstOrDefaultAsync(m => m.PkId == id);
            if (aspNetPosts == null)
            {
                return NotFound();
            }

            return View(aspNetPosts);
        }

        // GET: AspNetPosts/Create
        public IActionResult Create()
        {
            ViewData["FkUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: AspNetPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkId,Title,Description,Image,IsEdited,Created,Updated,FkUserId")] AspNetPosts aspNetPosts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetPosts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetPosts.FkUserId);
            return View(aspNetPosts);
        }

        // GET: AspNetPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetPosts = await _context.AspNetPosts.FindAsync(id);
            if (aspNetPosts == null)
            {
                return NotFound();
            }
            ViewData["FkUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetPosts.FkUserId);
            return View(aspNetPosts);
        }

        // POST: AspNetPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkId,Title,Description,Image,IsEdited,Created,Updated,FkUserId")] AspNetPosts aspNetPosts)
        {
            if (id != aspNetPosts.PkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetPosts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetPostsExists(aspNetPosts.PkId))
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
            ViewData["FkUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", aspNetPosts.FkUserId);
            return View(aspNetPosts);
        }

        // GET: AspNetPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetPosts = await _context.AspNetPosts
                .Include(a => a.FkUser)
                .FirstOrDefaultAsync(m => m.PkId == id);
            if (aspNetPosts == null)
            {
                return NotFound();
            }

            return View(aspNetPosts);
        }

        // POST: AspNetPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspNetPosts = await _context.AspNetPosts.FindAsync(id);
            _context.AspNetPosts.Remove(aspNetPosts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetPostsExists(int id)
        {
            return _context.AspNetPosts.Any(e => e.PkId == id);
        }
    }
}
