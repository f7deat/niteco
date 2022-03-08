using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Niteco.UnitTest
{
    [TestClass]
    public class UnitTestOrder
    {
        private readonly NitecoDbContext _context;
        private readonly IOrderService _orderService;
        public UnitTestOrder(NitecoDbContext context, IOrderService orderService) {
            _context = context;
            _orderService = orderService;
        }

        // Task 5: Create one unitest for function GetAllOrders
        [TestMethod]
        public async Task TestGetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            Assert.AreEqual(_context.Orders.Count(), orders.Count());
        }
    }
}