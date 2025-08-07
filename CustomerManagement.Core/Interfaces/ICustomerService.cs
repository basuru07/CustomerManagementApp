using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Interfaces
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
        Task <List<Customer>> GetAllCustomersAsync(); // list the all customer
        Task <Customer> GetCustomerByIdAsync(int id);

       
    }
}
