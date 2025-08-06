using CustomerManagement.API.DTOs;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {   // mapping DTO
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            await _customerService.AddCustomerAsync(customer);
            return Ok(new { message = "Customer added successfully!" });
        }
    }
}

