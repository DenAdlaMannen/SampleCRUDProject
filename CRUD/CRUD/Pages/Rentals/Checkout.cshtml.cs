using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CRUD.Pages.Rentals
{
    public class CheckoutModel : PageModel
    {
        private readonly RentersContext _db;
        public IEnumerable<Product> Products { get; set; }
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }

        public List<int> Test { get; set; }

        public CheckoutModel(RentersContext db)
        {
            _db = db;
        }
        public void OnGet(List<int> products)
        {
            Test = products;

            foreach (var id in products)
            {
                Products = _db.Products.Where(x => products.Contains(x.ProductId)).ToList();
            }

        }
        public IActionResult OnPost(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();

            List<int> itemIds = Request.Form["itemIds"]
                .Select(int.Parse)
                .ToList();

            foreach (var productId in itemIds)
            {
                Rent rent = new Rent();
                rent.ProductsId = productId;
                rent.CustomerId = customer.CustomerId;
                _db.Rents.Add(rent);
                _db.SaveChanges();
            }



            return RedirectToPage("CurrentRentals");
        }
    }
}
