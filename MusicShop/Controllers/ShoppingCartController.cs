using MusicShop.Data;
using MusicShop.Models;
using MusicShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicShopContext storeDB = new MusicShopContext();

        public HttpContext HttpContext { get; private set; }

        //
        // GET: /ShoppingCart/
        public IActionResult Index()
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return (IActionResult)View();
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedAlbum = storeDB.Albums
                .Single(album => album.Id == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum);

            // Go back to the main store page for more shopping
            return RedirectToAction();
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string albumName = storeDB.Carts
                .Single(item => item.RecordId == id).Album.Title;

            //    // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            //    // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = albumName +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        public IActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return (IActionResult)View();
        }
    }
}
