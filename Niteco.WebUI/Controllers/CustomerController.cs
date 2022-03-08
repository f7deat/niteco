using Microsoft.AspNetCore.Mvc;
using Niteco.ApplicationCore.Interfaces.IService;
// doan nay chua using het vi IE quan net khong cho chay powershell nen ko restore package de co suggetion

namespace Niteco.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await _customerService.GetAllAsync());
    }
}
