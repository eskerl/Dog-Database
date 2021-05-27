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
    ///     Controller for Owner objects
    /// </summary>
    public class OwnersController : Controller
    {
        /// <summary>
        ///     Database context for owners
        /// </summary>
        private readonly OwnerContext _context;

        /// <summary>
        ///     Constructs this controller
        /// </summary>
        /// <param name="context">
        ///     the database context
        /// </param>
        public OwnersController(OwnerContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     GET request for all Owners in database
        /// </summary>
        /// <returns>
        ///     a View with all of the stored owner details
        /// </returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Owners.ToListAsync());
        }

        /// <summary>
        ///     GET request for a sepcified owner with the corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the desired owner
        /// </param>
        /// <returns>
        ///     View with the specified owner's details
        ///     or HTTP not found if owner does not exist or ID is not null
        /// </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        /// <summary>
        ///     GET request for the form page to create a new owner
        /// </summary>
        /// <returns>
        ///     a View with a form to create a new owner
        /// </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///     POST request with details of new owner
        /// </summary
        /// <param name="owner">
        ///     A owner object with the new owner's values binded to the fields
        /// </param>
        /// <returns>
        ///     a View - Index if create was successful, same view if fails
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,PhoneNumber")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(owner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        /// <summary>
        ///     GET request for owner with corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the owner we wish to edit
        /// </param>
        /// <returns>
        ///     A view with a form to edit the owner's details
        ///     or HTTP not found if id is null or owner could not be found
        /// </returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        /// <summary>
        ///     POST request to update a owner with corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the owner we wish to edit
        /// </param>
        /// <returns>
        ///     A view - Index if successful, same view is not
        ///     or HTTP not found if id is null or owner could not be found
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,PhoneNumber")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.Id))
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
            return View(owner);
        }

        /// <summary>
        ///     GET request to delete a owner
        /// </summary>
        /// <param name="id">
        ///     ID of the owner we wish to delete
        /// </param>
        /// <returns>
        ///     A view to confirm deletion
        ///     or HTTP not found if id is null or owner could not be found
        /// </returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        /// <summary>
        ///     Deletes a owner with corresponding ID
        /// </summary>
        /// <param name="id">
        ///     ID of the owner we wish to edit
        /// </param>
        /// <returns>
        ///     Index view
        /// </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        ///     Checks if the owner exists in the database
        /// </summary>
        /// <param name="id">
        ///     ID of the owner we want
        /// </param>
        /// <returns>
        ///     true if owner is found, else false
        /// </returns>
        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
