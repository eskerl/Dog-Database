using Microsoft.AspNetCore.Mvc;
using DogWebApp.Models;
using System.Collections.Generic;
using DogWebApp.ViewModels;
using System.Linq;

namespace DogWebApp.Controllers
{
    public class DogController : Controller
    {
        private IEnumerable<Dog> GetDogs()
        {
            return new List<Dog>
            {
                new Dog() { Id = 0, Name = "Alice" },
                new Dog() { Id = 1, Name = "Spark" }
            };
        }

        // GET: /Dog/
        public ViewResult Index()
        {
            var dogs = GetDogs();
            return View(dogs);
        }

        // GET: /Dog/Info/{id}
        public IActionResult Info(int id)
        {
            var dog = GetDogs().SingleOrDefault(d => d.Id == id);

            if(dog == null)
            {
                return StatusCode(404);
            }


            return View(dog);
        }
    }
}