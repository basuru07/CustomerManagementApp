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

        // constructor injection of the customer service
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Add the Customer 
        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            // mapping DTO to the customer entity
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
            // call the service method to save the new customer
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

        // Read all Customers
        [HttpGet("all")]
        public async Task <IActionResult> GetAllCustomers()
        {   // call the service to get all customer
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        // Read with Customer ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            // if not found, return 404 error
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            return Ok(customer);
        }

        // Delete Part
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _customerService.DeleteCustomerAsync(id);

            if (!deleted)
                return NotFound($"Customer with ID {id} not found.");

            return Ok($"Customer with ID {id} deleted successfully.");
        }

        // Update Part
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            var result = await _customerService.UpdateCustomerAsync(id, updatedCustomer);

            if (!result)
                return NotFound($"Customer with ID {id} not found.");

            return Ok($"Customer with ID {id} updated successfully.");


        }





    }
}