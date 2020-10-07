using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess;
using SocialMedia.Entities.Models;

namespace SocialMedia.WebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostRepository repo;

        public PostsController(PostRepository postRepository)
        {
            repo = postRepository;
        }

        // GET: AspNetPosts
        public async Task<IActionResult> Index()
        {
            IEnumerable<AspNetPosts> socialMediaContext = await repo.GetAllAsync();
            return View(socialMediaContext);
        }

        // GET: AspNetPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            AspNetPosts aspNetPosts = await repo.GetByIdAsync(id);

            if(aspNetPosts == null)
            {
                return NotFound();
            }

            return View(aspNetPosts);
        }

        // GET: AspNetPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkId,Title,Description,Image,IsEdited,Created,Updated,FkUserId")] AspNetPosts aspNetPosts)
        {
            if(ModelState.IsValid)
            {
                aspNetPosts.Created = DateTime.Now;
                aspNetPosts.FkUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await repo.AddAsync(aspNetPosts);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: AspNetPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            AspNetPosts aspNetPosts = await repo.GetByIdAsync(id);

            if(aspNetPosts == null)
            {
                return NotFound();
            }

            return View(aspNetPosts);
        }

        // POST: AspNetPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkId,Title,Description,Image,IsEdited,Created,Updated,FkUserId")] AspNetPosts aspNetPosts)
        {
            if(id != aspNetPosts.PkId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    AspNetPosts originalPost = await repo.GetByIdAsync(id);

                    originalPost.IsEdited = true;
                    originalPost.Updated = DateTime.Now;

                    originalPost.Title = aspNetPosts.Title;
                    originalPost.Description = aspNetPosts.Description;
                    originalPost.Image = aspNetPosts.Image;

                    await repo.UpdateAsync(originalPost);
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!await AspNetPostsExists(aspNetPosts.PkId))
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

            return View();
        }

        // GET: AspNetPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            AspNetPosts aspNetPosts = await repo.GetByIdAsync(id);

            if(aspNetPosts == null)
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
            AspNetPosts aspNetPosts = await repo.GetByIdAsync(id);

            await repo.DeleteAsync(aspNetPosts);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AspNetPostsExists(int id)
        {
            return await repo.Exists(id);
        }
    }
}
