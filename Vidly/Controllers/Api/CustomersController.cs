using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;
using Vidly.Database;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        protected readonly VidlyDbContext _context;

        public CustomersController()
        {
            _context=new VidlyDbContext();
        }

        public CustomersController(VidlyDbContext context)
        {
            _context = context;
        }

        // GET/api/Customers
        public IHttpActionResult GetCustomers()
        {

             var customers = _context.Customers.ToList()
                .Select(AutoMapper.Mapper.Map<Customer,CustomerDto>);
            return Ok(customers);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return BadRequest();
                return Ok(AutoMapper.Mapper.Map<Customer,CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = AutoMapper.Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
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
