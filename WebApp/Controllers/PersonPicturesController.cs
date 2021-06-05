using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class PersonPicturesController : Controller
    {
        private readonly AppDbContext _context;

        public PersonPicturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PersonPictures
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonPictures.ToListAsync());
        }

        // GET: PersonPictures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPicture = await _context.PersonPictures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personPicture == null)
            {
                return NotFound();
            }

            return View(personPicture);
        }

       
        // GET: PersonPictures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PictureUrl")] PersonPicture personPicture)
        {
            if (ModelState.IsValid)
            {
                personPicture.Id = Guid.NewGuid();
                _context.Add(personPicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personPicture);
        }

        // GET: PersonPictures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPicture = await _context.PersonPictures.FindAsync(id);
            if (personPicture == null)
            {
                return NotFound();
            }
            return View(personPicture);
        }

        // POST: PersonPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PictureUrl")] PersonPicture personPicture)
        {
            if (id != personPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonPictureExists(personPicture.Id))
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
            return View(personPicture);
        }

        // GET: PersonPictures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPicture = await _context.PersonPictures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personPicture == null)
            {
                return NotFound();
            }

            return View(personPicture);
        }

        // POST: PersonPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var personPicture = await _context.PersonPictures.FindAsync(id);
            _context.PersonPictures.Remove(personPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonPictureExists(Guid id)
        {
            return _context.PersonPictures.Any(e => e.Id == id);
        }
    }
}
