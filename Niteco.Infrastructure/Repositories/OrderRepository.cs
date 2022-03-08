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
using Niteco.ApplicationCore.Helpers;

namespace Niteco.Infrastructure.Repositories
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(NitecoDbContext context) : base(context)
        {
        }

        public async Task<dynamic> GetAllOrdersAsync(string searchTerm, int pageIndex, int pageSize)
        {
            try {
                var query = from a in _context.Products
                        join b in _context.Categories on a.CategoryId equals b.Id
                        join c in _context.Orders on a.Id equals c.ProductId
                        join d in _context.Customers on c.CustomerId equals d.Id
                        where string.IsNullOrEmpty(searchTerm) || b.Name.ToLowerCase().Contains(searchTerm.ToLowerCase())
                        select new ListOrderItem
                        {
                            OrderId = c.Id,
                            Amount = c.Amount,
                            CategoryName = b.Name,
                            CustomerName = d.Name,
                            OrderDate = c.OrderDate,
                            ProductName = a.Name
                        };
                var data = await query.OrderByDescesing(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                return new {
                    data,
                    total = await _context.Orders.CountAsync(),
                    pageIndex,
                    pageSize,
                    succeeded = true,
                    message = string.Empty
                };
            } catch(Exception ex) {
                // Task 4: Log error handing
                LogHelper.WriteLog(ex.ToString());
                return new {
                    succeeded = false,
                    message = ex.ToString()
                };
            }
        }
    }
}
