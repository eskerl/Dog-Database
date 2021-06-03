using AutoMapper;
using DogWebApp.Data;
using DogWebApp.Dtos;
using DogWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogWebApp.Controllers
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
        public IEnumerable<DogDto> GetDogs()
        {
            return _context.Dog.ToList().Select(_mapper.Map<Dog, DogDto>);
        }

        // GET: Api/Dog/{id}
        [HttpGet("{id}")]
        public DogDto GetDog(int id)
        {
            var dog = _context.Dog.SingleOrDefault(d => d.Id == id);

            if (dog == null)
            {
                NotFound();
            }

            return _mapper.Map<Dog, DogDto>(dog);
        }

        // POST: Api/Dog
        [HttpPost]
        public DogDto CreateDog(DogDto dogDto)
        {
            Dog dog = _mapper.Map<DogDto, Dog>(dogDto);
            _context.Dog.Add(dog);
            _context.SaveChanges();

            dogDto.Id = dog.Id;

            return dogDto;
        }

        // PUT: Api/Dog/{id}
        [HttpPut("{id}")]
        public void UpdateDog(int id, DogDto dogDto)
        {
            var dogInDb = _context.Dog.SingleOrDefault(d => d.Id == id);

            if (dogInDb == null)
            {
                NotFound();
            }

            _mapper.Map(dogDto, dogInDb);
            _context.SaveChanges();
        }

        // DELETE: Api/Dog/{id}
        [HttpDelete("{id}")]
        public void DeleteDog(int id)
        {
            var dogInDb = _context.Dog.SingleOrDefault(d => d.Id == id);

            if (dogInDb == null)
            {
                NotFound();
            }

            _context.Dog.Remove(dogInDb);
            _context.SaveChanges();
        }
    }
}
