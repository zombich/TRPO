using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;

namespace ShoeStoreWebApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseLibrary.Contexts.ShoeStoreDbContext _context;

        public DetailsModel(DatabaseLibrary.Contexts.ShoeStoreDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Article == id);

            if (product is not null)
            {
                Product = product;

                return Page();
            }

            return NotFound();
        }
    }
}
