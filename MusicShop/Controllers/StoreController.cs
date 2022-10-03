using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Controllers
{
    public class StoreController : Controller
    {
        // GET: /Store/
        public IActionResult Index()
        {
            return View();
        }
    }
}
