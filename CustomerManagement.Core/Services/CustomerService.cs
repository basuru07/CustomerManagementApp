using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;

namespace CustomerManagement.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository; // save customer data
        }

        // validate the input
        public async Task AddCustomerAsync(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new ArgumentException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(customer.Email))
                throw new ArgumentException("Email is required.");

            // save the DataBase
            await _customerRepository.AddCustomerAsync(customer);
        }
    }
}

