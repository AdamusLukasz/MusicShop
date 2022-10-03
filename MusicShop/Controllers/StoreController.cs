using Microsoft.AspNetCore.Mvc;
using MusicShop.Data;

namespace MusicShop.Controllers
{
    public class StoreController : Controller
    {
        private readonly MusicShopContext _context = new MusicShopContext();
        // GET: /Store/
        public IActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }
    }
}
