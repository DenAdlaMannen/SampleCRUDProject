using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Rentals
{
    public class IndexModel : PageModel
    {
        private readonly RentersContext _db;
        public IEnumerable<Product> Products { get; set; }
        public Product? Product { get; set; }

        public IndexModel(RentersContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Products = _db.Products.ToList();
        }
        public IActionResult OnPost()
        {
            List<int> itemIds = Request.Form["itemIds"]
                .Select(int.Parse)
                .ToList();

            return RedirectToPage("Checkout", new { products = itemIds });
        }
    }
}
