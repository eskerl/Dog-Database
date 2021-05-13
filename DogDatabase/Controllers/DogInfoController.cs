using Microsoft.AspNetCore.Mvc;

namespace DogDatabase.Controllers
{
    public class DogInfoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}