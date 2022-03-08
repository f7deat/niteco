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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger _logger;
        
        public OrderService(IOrderRepository orderRepository, ILogger<string> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public Task<IReadOnlyList<ListOrderItem>> GetAllOrdersAsync(string searchTerm) => _orderRepository.GetAllOrdersAsync(searchTerm);

        public async Task<dynamic> AddAsync(Order order) {
            if(order.Amount < 0) {
                _logger.LogInformation($"{nameof(AddAsync)}: Amount incorrect");
                return new { succeeded = false, message = "Amount incorrect!"};
            }
            // Solution Scenario
            var product = await _productRepository.GetById(order.ProductId);
            if(product.Quantity < order.Amount) {
                _logger.LogInformation($"{nameof(AddAsync)}: Unit in stock not available to order!");
                return new { succeeded = false, message = "Unit in stock not available to order!"};
            }
            try {
                _orderRepository.AddAsync(order);
                return new {
                    succeeded = true,
                    message = "Create new order success!"
                };
            } catch(Exception ex) {
                // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0
                _logger.Error($"{nameof(AddAsync)}: {ex}");
                return new {
                    succeeded = false,
                    message = ex.ToString()
                };
            }
        }
    }
}
