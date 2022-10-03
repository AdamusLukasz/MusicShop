using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // Get: /Store/Browse
        public ActionResult Browse(string genre)
        {
            var genreModel = _context.Genres
                .Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var album = _context.Albums.Find(id);

            return View(album);
        }
    }
}
