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
        {
            // mapping DTO
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            await _customerService.AddCustomerAsync(customer);

            return Ok(new
            {
                message = "Customer added successfully!",
                customerId = customer.Id, // Assuming the service sets the ID
                customerName = customer.Name,
                customerEmail = customer.Email,
                createdAt = DateTime.UtcNow
            });

            
        }
        [HttpGet("all")]
        public async Task <IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            return Ok(customer);
        }


    }
}