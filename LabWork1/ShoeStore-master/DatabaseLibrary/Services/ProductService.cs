using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Services
{
    public class ProductService
    {
        private readonly ShoeStoreDbContext _context = new();

        public async Task<IEnumerable<Product>> GetProductsAsync()
            => await _context.Products.ToListAsync();

        public async Task<Product?> GetProductByArticleAsync(string article)
           => await _context.Products.FirstOrDefaultAsync(p => p.Article == article);

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(string article)
        {
            var product = await GetProductByArticleAsync(article);

            if (product is null)
                return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var selectedProduct = await GetProductByArticleAsync(product.Article);

            if (selectedProduct is null) 
                return;

            selectedProduct.ManufacturerId = product.ManufacturerId;
            selectedProduct.Description = product.Description;
            selectedProduct.Price = product.Price;
            selectedProduct.SupplierId = product.SupplierId;
            selectedProduct.CategoryId = product.CategoryId;
            selectedProduct.Discount = product.Discount;
            selectedProduct.Quantity = product.Quantity;
            selectedProduct.Photo = product.Photo;
            selectedProduct.Unit = product.Unit;
            selectedProduct.Name = product.Name;

            await _context.SaveChangesAsync();
        }
    }
}
