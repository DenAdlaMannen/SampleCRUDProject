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
        public IActionResult OnGet(int id)
        {
            Product = _db.Products.FirstOrDefault(x => x.ProductId == id);

            bool isUsedInRents = _db.Rents.Any(r => r.ProductsId == id);

            if (isUsedInRents)
            {
                TempData["WarningMessage"] = "This product cannot be deleted at the moment, as it is rentent.";
            }
            else
            {
                _db.Products.Remove(Product);
                _db.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
