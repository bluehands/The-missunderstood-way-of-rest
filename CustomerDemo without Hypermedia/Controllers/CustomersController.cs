using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDemo.Controllers
{
    
    public class CustomersController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Customer> Get()
        {
            return CustomerRepository.GetAll();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return new OkObjectResult(CustomerRepository.Get(id));
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
        }

        // POST api/customers
        [HttpPost]
        [Route("api/[controller]")]
        public void Post([FromBody]Customer value)
        {
            CustomerRepository.Add(value);
        }

        // PUT api/customers/5
        public void Put(int id, [FromBody]Customer value)
        {
            CustomerRepository.Update(value);
        }

        // DELETE api/customers/5
        public void Delete(int id)
        {
            CustomerRepository.Delete(id);
        }
    }
}
