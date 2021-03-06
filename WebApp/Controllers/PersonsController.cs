using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain.App;

namespace WebApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PersonRepository _repository;
        public PersonsController(AppDbContext context)
        {
            _context = context;
            _repository = new PersonRepository(_context);
        }

        // GET: Persons
        public async Task<IActionResult> Index() 
        {
           // var pick = await _context.PersonPictures.AsNoTracking().ToListAsync();

           var res = await _repository.GetAllAsync();

            // var res = await _context.Persons
            //     //.Include(p => p.PersonPicture)
            //     .Include(p=> p.Contacts)
            //     .ThenInclude(c=>c.ContactType)
            //    // .AsNoTracking()
            //     .ToListAsync();
            // await _context.Entry(res.First()).Reference(x => x.PersonPicture).LoadAsync();
            return View(res);
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.PersonPicture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            ViewData["PersonPictureId"] = new SelectList(_context.PersonPictures, "Id", "PictureUrl");
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,PersonPictureId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(person);
                
                // person.Id = Guid.NewGuid();
                // _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonPictureId"] = new SelectList(_context.PersonPictures, "Id", "PictureUrl", person.PersonPictureId);
            return View(person);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["PersonPictureId"] = new SelectList(_context.PersonPictures, "Id", "PictureUrl", person.PersonPictureId);
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,FirstName,LastName,PersonPictureId")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["PersonPictureId"] = new SelectList(_context.PersonPictures, "Id", "PictureUrl", person.PersonPictureId);
            return View(person);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.PersonPicture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
