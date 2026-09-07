using DatabaseLibrary.Contexts;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Services
{
    public class OrderService
    {
        private readonly ShoeStoreDbContext _context = new();

        public async Task<IEnumerable<Order>> GetOrdersByLogin(string login)
            => await _context.Orders
                    .Include(o => o.User)
                    .Where(o => o.User.Login == login)
                    .ToListAsync();

        public async Task ChangeOrderStatus(int orderId, int orderStatusId)
        {
            var order = await GetOrderById(orderId);

            if (order is null)
                return;

            order.OrderStatusId = orderStatusId;
            await _context.SaveChangesAsync();
        }

        private async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task ChangeOrderDeliveryDate(int orderId, DateOnly deliveryDate)
        {
            var order = await GetOrderById(orderId);

            if (order is null)
                return;

            order.DeliveryDate = deliveryDate;
            await _context.SaveChangesAsync();
        }
    }
}
