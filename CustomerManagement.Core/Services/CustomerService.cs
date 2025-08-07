﻿using System;
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
        // private field for the repository used to save and retrieve customers
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

            // save the customer to the repository asynchronously
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteCustomerAsync(id);
        }

        public async Task<bool> UpdateCustomerAsync(int id, Customer updateCustomer)
        {
            return await _customerRepository.UpdateCustomerAsync(id, updateCustomer);

        }

    }
}

