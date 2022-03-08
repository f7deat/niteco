using Microsoft.AspNetCore.Mvc;
using Niteco.ApplicationCore.Interfaces.IService;
// doan nay chua using het vi IE quan net khong cho chay powershell nen ko restore package de co suggetion

namespace Niteco.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await _productService.GetAllAsync());
    }
}
