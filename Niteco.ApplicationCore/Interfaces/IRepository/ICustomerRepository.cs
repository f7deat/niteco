using Niteco.ApplicationCore.Entities;
using Niteco.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.ApplicationCore.Interfaces.IRepository
{
    public interface IProductRepository : IAsyncRepository<Customer>
    {
        Task<dynamic> GetAllAsync();
    }
}
