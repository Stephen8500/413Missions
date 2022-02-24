using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }

        public PurchaseModel (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public ShoppingCart shoppingCart { get; set; }
        public string ReturnUrl { get; set; }


        //gets session storage values for cart along with url for returning to shopping
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            shoppingCart = HttpContext.Session.GetJson<ShoppingCart>("shoppingCart") ?? new ShoppingCart();
        }


        //saves values to session storage
        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == bookid);

            shoppingCart = HttpContext.Session.GetJson<ShoppingCart>("shoppingCart") ?? new ShoppingCart();

            shoppingCart.AddItem(b, 1);

            HttpContext.Session.SetJson("shoppingCart", shoppingCart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
