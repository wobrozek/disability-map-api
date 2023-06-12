using Microsoft.AspNetCore.Mvc;

namespace disability_map.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
