using AutoMapper;
using DogWebApp.Data;
using DogWebApp.Dtos;
using DogWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        //the context for the database
        private readonly DogContext _context;
        //the auto mapper context
        private readonly IMapper _mapper;

        /// <summary>
        ///     Constructs this controller for Dogs
        /// </summary>
        /// <param name="context">
        ///     the database context
        /// </param>
        public DogController(DogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Api/Dog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            return await _context.Dog.ToListAsync();
        }

        // GET: Api/Dog/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DogDto>> GetDog(int id)
        {
            var dog = await _context.Dog.FindAsync(id);

            if (dog == null)
            {
                return NotFound();
            }

            return _mapper.Map<Dog, DogDto>(dog);
        }

        // POST: Api/Dog
        [HttpPost]
        public async Task<ActionResult<DogDto>> CreateDog(DogDto dogDto)
        {
            Dog dog = _mapper.Map<DogDto, Dog>(dogDto);
            _context.Dog.Add(dog);
            await _context.SaveChangesAsync();

            dogDto.Id = dog.Id;

            return CreatedAtAction(nameof(GetDog), new { id = dogDto.Id }, dogDto);
        }

        // PUT: Api/Dog/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDog(int id, DogDto dogDto)
        {
            if (id != dogDto.Id)
            {
                return BadRequest();
            }

            var dogInDb = _context.Dog.SingleOrDefault(d => d.Id == id);
            if (dogInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(dogDto, dogInDb);
            _context.Entry(dogInDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: Api/Dog/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dog>> DeleteDog(int id)
        {
            var dogInDb = _context.Dog.SingleOrDefault(d => d.Id == id);

            if (dogInDb == null)
            {
                return NotFound();
            }

            _context.Dog.Remove(dogInDb);
            await _context.SaveChangesAsync();

            return dogInDb;
        }
    }
}
