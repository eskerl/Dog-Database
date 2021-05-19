using DogDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDatabase.Controllers
{
    public class OwnerController : Controller
    {
        private IEnumerable<Owner> GetOwners()
        {
            return new List<Owner>
            {
                new Owner { FirstName = "Bob", LastName = "Smith" },
                new Owner { FirstName = "Anna", LastName = "Johnson" }
            };
        }
        public IActionResult Index()
        {
            var owners = GetOwners();
            return View(owners);
        }
    }
}
