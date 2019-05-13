using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;
using Vidly.Database;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        protected readonly VidlyDbContext _context;

        public CustomerController()
        {
            _context=new VidlyDbContext();
        }

        public CustomerController(VidlyDbContext context)
        {
            _context = context;
        }

        // GET/api/Customers
        public IEnumerable<Customer> GetCustomers()
        {

            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer==null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        [HttpPut]

        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            customerInDb.Name = customer.Name;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipType = customer.MembershipType;
            customerInDb.Birthdate = customer.Birthdate;
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
