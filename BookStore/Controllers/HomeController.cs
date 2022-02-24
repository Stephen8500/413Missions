using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository repo;

        public HomeController(IBookStoreRepository temp) => repo = temp;

        //index get view
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            // max books per page: 10
            int pageSize = 10;

            // create variable to pass into view with books and page info
            var x = new BooksViewModel
            {
                // books queryable list with only books in this category (if there is one)
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                // page info saved as type page info
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null ?
                    repo.Books.Count()
                    : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            //return view, pass in BooksViewModel with info necessary
            return View(x);
        }
    }
}
