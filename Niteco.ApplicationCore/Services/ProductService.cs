using Niteco.ApplicationCore.Entities;
using Niteco.ApplicationCore.Interfaces.IRepository;
using Niteco.ApplicationCore.Interfaces.IService;
using Niteco.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        
        public CustomerService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<dynamic> GetAllAsync() => _productRepository.GetAllAsync();
    }
}
