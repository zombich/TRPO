using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStoreWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        
        private readonly DatabaseLibrary.Contexts.ShoeStoreDbContext _context;

        [BindProperty(SupportsGet = true)]
        public string ProductDescription { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Manufacturer { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortColumn { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal ProductPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool IsDiscounted { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool IsExists { get; set; }

        public IndexModel(DatabaseLibrary.Contexts.ShoeStoreDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ViewData["Manufacturer"] = new SelectList(_context.ProductManufacturers, "ManufacturerId", "Name");

            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).AsQueryable();

            if (!string.IsNullOrWhiteSpace(ProductDescription))
                products = products.Where(p => p.Description.Contains(ProductDescription));

            if (Manufacturer > 0)
                products = products.Where(p => p.Manufacturer.ManufacturerId == Manufacturer);

            if (ProductPrice > 0)
                products = products.Where(p => p.Price <= ProductPrice);

            if (IsDiscounted)
                products = products.Where(p => p.Discount > 0);

            if (IsExists)
                products = products.Where(p => p.Quantity > 0);

            products = SortColumn switch
            {
                "price" => products.OrderBy(p => p.Price),
                "price_desc" => products.OrderByDescending(p => p.Price),
                "name" => products.OrderBy(p => p.Name),
                "supplier" => products.OrderBy(p => p.Supplier.Name),
                _ => products,
            };

            Product = await products.ToListAsync();
        }
    }
}
