using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDemo.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        // GET: api/customers
        [HttpGet(Name = "GETCUSTOMERS")]
        public IEnumerable<Customer> Get()
        {
            return CustomerRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GETCUSTOMER")]
        public ActionResult Get(int id)
        {
            Customer customer;
            if (CustomerRepository.TryGet(id, out customer))
            {
                return new OkObjectResult(customer);
            }
            return new NotFoundResult();
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody]Customer value)
        {
            var newId = CustomerRepository.Add(value);
            return new CreatedAtRouteResult("GETCUSTOMER",  new { id = newId }, null);
        }

        // PUT api/customers/5
        [HttpPut]
        public void Put(int id, [FromBody]Customer value)
        {
            CustomerRepository.Update(value);
        }

        // DELETE api/customers/5
        [HttpDelete]
        public void Delete(int id)
        {
            CustomerRepository.Delete(id);
        }
    }
}
