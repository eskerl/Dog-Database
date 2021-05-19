using Microsoft.AspNetCore.Mvc;
using DogDatabase.Models;

namespace DogDatabase.Controllers
{
    public class DogController : Controller
    {
        // GET: /Dog/
        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            Dog dog = new Dog() { Name = "Sammy" };
            return View(dog);
        }
    }
}