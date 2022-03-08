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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<dynamic> GetAllAsync() => _customerRepository.GetAllAsync();
    }
}
