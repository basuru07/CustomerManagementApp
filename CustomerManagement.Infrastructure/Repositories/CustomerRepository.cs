using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context; // add the database
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer); 
            await _context.SaveChangesAsync(); // save the new customer to the database
            Console.WriteLine($"Customer {customer.Name} saved with ID {customer.Id}");
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
