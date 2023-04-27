using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD.Pages.Products
{
    public class DeleteProductModel : PageModel
    {
        private readonly RentersContext _db;
        public IEnumerable<Product> Products { get; set; }
        public Product? Product { get; set; }

        public DeleteProductModel(RentersContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Product = _db.Products.FirstOrDefault(x => x.ProductId == id);

            _db.Products.Remove(Product);
            _db.SaveChanges();
            RedirectToPage("Index");
        }
    }
}
