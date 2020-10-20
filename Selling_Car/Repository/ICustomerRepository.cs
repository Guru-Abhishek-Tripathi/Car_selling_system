using Selling_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selling_Car.Repository
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomer();
        public IQueryable<Customer> GetCustomer(string id);
        public Customer PutCustomer(string id, Customer customer);
        public void PostCustomer(Customer customer);
        public IQueryable<Customer> DeleteCustomer(string id);
    }
}
