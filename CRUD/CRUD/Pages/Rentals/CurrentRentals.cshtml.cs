using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages.Rentals
{
    public class CurrentRentalsModel : PageModel
    {
        private readonly RentersContext _db;
        public IEnumerable<Rent> Rents { get; set; }
        public Product? Product { get; set; }

        public CurrentRentalsModel(RentersContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Rents = _db.Rents
                .Include(c => c.Customer)
                .Include(p => p.Products)
                .OrderBy(c => c.Customer.Firstname)
                .ToList();
        }
    }
}
