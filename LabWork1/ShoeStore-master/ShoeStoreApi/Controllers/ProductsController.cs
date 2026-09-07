using DatabaseLibrary.Models;
using DatabaseLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service = new();

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _service.GetProductsAsync();
        }

        [HttpGet("{article}")]
        public async Task<Product> GetProductById(string article)
        {
            return await _service.GetProductByArticleAsync(article);
        }

        [HttpPost]
        public async Task AddProduct(Product product)
        {
            await _service.AddProduct(product);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, Product product)
        {
            await _service.UpdateProduct(product);
        }

        [HttpDelete("{article}")]
        public async Task Delete(string article)
        {
            await _service.DeleteProduct(article);
        }
    }
}
