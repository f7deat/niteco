using Microsoft.AspNetCore.Mvc;
using Niteco.ApplicationCore.Interfaces.IService;
// doan nay chua using het vi IE quan net khong cho chay powershell nen ko restore package de co suggetion

namespace Niteco.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        
        public OrderController(IOrderService orderService, IProductService productService, ICustomerService customerService)
        {
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
        }

        [HttpGet("all-orders")]
        public async Task<IActionResult> GetAllOrders(string searchTerm, int pageIndex = 1, int pageSize = 10) => Ok(await _orderService.GetAllOrdersAsync(searchTerm, pageIndex, pageSize));

        // anonymous user can not access the action
        // Task 3: Authenticaion and Authoriztion
        // it will be return 401 => handing in client
        [HttpGet("private-orders"), Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllOrders(string searchTerm) => Ok(await _orderService.GetAllOrdersAsync(searchTerm));

        // Task 2: Create the manage orders
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] Order order) => Ok(await _orderService.AddAsync(order));
    }
}
