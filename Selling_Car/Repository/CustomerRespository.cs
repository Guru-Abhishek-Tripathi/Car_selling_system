using Microsoft.EntityFrameworkCore;
using Selling_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selling_Car.Repository
{
    public class CustomerRespository : ICustomerRepository
    {
        private readonly Simulation_dbContext _context;

        public CustomerRespository(Simulation_dbContext context)
        {
            _context = context;
        }
        public IQueryable<Customer> DeleteCustomer(string id)
        {
            IQueryable<Customer> customers = _context.Customer.Where(a => a.CusId == id);
            _context.Customer.Remove(customers.FirstOrDefault());
            _context.SaveChangesAsync();
            return customers;
        }

        public List<Customer> GetCustomer()
        {
            return _context.Customer.ToList();
        }

        public IQueryable<Customer> GetCustomer(string id)
        {
            return _context.Customer.Where(a => a.CusId == id);
        }

        public void PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChangesAsync();
        }

        public Customer PutCustomer(string id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return customer;
        }
    }
}
