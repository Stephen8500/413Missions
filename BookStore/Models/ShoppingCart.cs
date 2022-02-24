using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartLineItem> Items { get; set; } = new List<ShoppingCartLineItem>();

        // method for adding an item to cart: receives book and qty and doesn't return anything
        public void AddItem(Book book, int qty)
        {
            // finds book if it's already in cart
            ShoppingCartLineItem line = Items
                .Where(b => b.Book.BookID == book.BookID)
                .FirstOrDefault();

            // adds item if it's not already in cart
            if (line == null)
            {
                Items.Add(new ShoppingCartLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            // if already in cart, just increases qty in cart
            else
            {
                line.Quantity += qty;
            }
        }

        // method for calculating total amount owed: receives nothing, returns sum owed
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }
    
    public class ShoppingCartLineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}