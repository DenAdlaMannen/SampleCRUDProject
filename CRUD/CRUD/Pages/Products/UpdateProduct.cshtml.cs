using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Products
{
    public class UpdateProductModel : PageModel
    {
        private readonly RentersContext _db;
        public Product? Product { get; set; }

        public UpdateProductModel(RentersContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Product = _db.Products.FirstOrDefault(x => x.ProductId == id);
        }
        public IActionResult OnPost(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
