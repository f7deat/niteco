using Microsoft.EntityFrameworkCore;
using Niteco.ApplicationCore.Entities;
using Niteco.ApplicationCore.Interfaces.IRepository;
using Niteco.ApplicationCore.Models;
using Niteco.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.Infrastructure.Repositories
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(NitecoDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ListOrderItem>> GetAllOrdersAsync()
        {
            var query = from a in _context.Products
                        join b in _context.Categories on a.CategoryId equals b.Id
                        join c in _context.Orders on a.Id equals c.ProductId
                        join d in _context.Customers on c.CustomerId equals d.Id
                        select new ListOrderItem
                        {
                            OrderId = c.Id,
                            Amount = c.Amount,
                            CategoryName = b.Name,
                            CustomerName = d.Name,
                            OrderDate = c.OrderDate,
                            ProductName = a.Name
                        };
            return await query.ToListAsync();
        }
    }
}
