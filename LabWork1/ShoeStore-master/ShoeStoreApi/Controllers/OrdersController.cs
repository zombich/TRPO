using DatabaseLibrary.Models;
using DatabaseLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service = new();

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var claim = User.Claims.FirstOrDefault(u => u.Type == "login");

            return await _service.GetOrdersByLogin(claim.Value);
        }

        [Authorize]
        [HttpPut("/status/{id}")]
        public async Task ChangeOrderStatus(int id, int orderStatusId)
        {
            var claim = User.Claims.FirstOrDefault(u => u.Type == "Role");

            if (claim.Value == "Администратор" || claim.Value == "Менеджер")
                await _service.ChangeOrderStatus(id, orderStatusId);
            else
                Forbid();
        }

        [Authorize]
        [HttpPut("/delivery/{id}")]
        public async Task ChangeDeliveryDate(int id, DateOnly deliveryDate)
        {
            var claim = User.Claims.FirstOrDefault(u => u.Type == "Role");

            if (claim.Value == "Администратор" || claim.Value == "Менеджер")
                await _service.ChangeOrderDeliveryDate(id, deliveryDate);
            else
                Forbid();
        }

    }
}
