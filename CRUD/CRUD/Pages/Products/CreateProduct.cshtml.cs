using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        private readonly RentersContext _db;
        public IEnumerable<Product> Products { get; set; }
        public Product? Product { get; set; }

        public CreateProductModel(RentersContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Product product) 
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
