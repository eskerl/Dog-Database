using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogWebApp.Data;
using DogWebApp.Models;

namespace DogWebApp.Controllers
{
    /// <summary>
    ///     Controller for Dog objects
    /// </summary>
    public class DogsController : Controller
    {
        /// <summary>
        ///     the context for the database
        /// </summary>
        private readonly DogContext _context;

        /// <summary>
        ///     Constructs this controller
        /// </summary>
        /// <param name="context">
        ///     the database context
        /// </param>
        public DogsController(DogContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     GET request for all Dogs in database
        /// </summary>
        /// <returns>
        ///     a View with all of the stored dog details
        /// </returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dog.ToListAsync());
        }

        /// <summary>
        ///     GET request for a sepcified dog with the corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the desired dog
        /// </param>
        /// <returns>
        ///     View with the specified dog's details
        ///     or HTTP not found if dog does not exist or ID is not null
        /// </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        /// <summary>
        ///     GET request for the form page to create a new dog
        /// </summary>
        /// <returns>
        ///     a View with a form to create a new dog
        /// </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     POST request with details of new dog
        /// </summary
        /// <param name="dog">
        ///     A Dog object with the new dog's values binded to the fields
        /// </param>
        /// <returns>
        ///     a View - Index if create was successful, same view if fails
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Breed,Birthday,Age,Weight")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dog);
        }

        /// <summary>
        ///     GET request for dog with corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the dog we wish to edit
        /// </param>
        /// <returns>
        ///     A view with a form to edit the dog's details
        ///     or HTTP not found if id is null or dog could not be found
        /// </returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dog.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        /// <summary>
        ///     POST request to update a dog with corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the dog we wish to edit
        /// </param>
        /// <returns>
        ///     A view - Index if successful, same view is not
        ///     or HTTP not found if id is null or dog could not be found
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Breed,Birthday,Age,Weight")] Dog dog)
        {
            if (id != dog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogExists(dog.Id))
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
            return View(dog);
        }

        /// <summary>
        ///     GET request to delete a dog
        /// </summary>
        /// <param name="id">
        ///     ID of the dog we wish to delete
        /// </param>
        /// <returns>
        ///     A view to confirm deletion
        ///     or HTTP not found if id is null or dog could not be found
        /// </returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        /// <summary>
        ///     Deletes a dog with corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the dog we wish to edit
        /// </param>
        /// <returns>
        ///     Index view
        /// </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dog = await _context.Dog.FindAsync(id);
            _context.Dog.Remove(dog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        ///     Checks if the dog exists in the database
        /// </summary>
        /// <param name="id">
        ///     ID of the dog we want
        /// </param>
        /// <returns>
        ///     true if dog is found, else false
        /// </returns>
        private bool DogExists(int id)
        {
            return _context.Dog.Any(e => e.Id == id);
        }

    }
}
