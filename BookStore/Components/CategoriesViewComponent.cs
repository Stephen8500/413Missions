using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Components
{
    public class CategoriesViewComponent: ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public CategoriesViewComponent (IBookStoreRepository temp)
        {
            repo = temp;
        }

        // gets a list of categories for category component
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["BookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
