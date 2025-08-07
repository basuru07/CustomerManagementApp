using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }  // Auto-incremented by the DB for the uniquely identified
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
