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
    public class ProductRepository : EfRepository<Order>, IProductRepository
    {
        public ProductRepository(NitecoDbContext context) : base(context)
        {
        }

        public async Task<dynamic> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
