using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;

namespace ShoeStoreWebApp.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly DatabaseLibrary.Contexts.ShoeStoreDbContext _context;

        public EditModel(DatabaseLibrary.Contexts.ShoeStoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  await _context.Products.FirstOrDefaultAsync(m => m.Article == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
           ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "CategoryId", "Name");
           ViewData["ManufacturerId"] = new SelectList(_context.ProductManufacturers, "ManufacturerId", "Name");
           ViewData["SupplierId"] = new SelectList(_context.ProductSuppliers, "SupplierId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Article))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.Article == id);
        }
    }
}
