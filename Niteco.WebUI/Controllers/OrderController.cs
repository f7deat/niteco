using Microsoft.AspNetCore.Mvc;
using Niteco.ApplicationCore.Interfaces.IService;

namespace Niteco.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("all-orders")]
        public async Task<IActionResult> GetAllOrders() => Ok(await _orderService.GetAllOrdersAsync());
    }
}
