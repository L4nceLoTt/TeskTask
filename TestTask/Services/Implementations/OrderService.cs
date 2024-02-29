using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Data;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        ApplicationDbContext context;

        public OrderService(ApplicationDbContext context) => this.context = context;

        public Task<Order> GetOrder()
        {
            return Task.FromResult(context.Orders.OrderByDescending(x => x.Quantity * x.Price).First());
        }

        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(context.Orders.Where(x => x.Quantity > 10).ToList());
        }
    }
}
