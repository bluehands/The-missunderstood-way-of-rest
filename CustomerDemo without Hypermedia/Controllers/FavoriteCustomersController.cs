using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCustomersController : ControllerBase
    {
        // GET: api/customers
        [HttpGet(Name = "GETFAVORITECUSTOMERS")]
        public IEnumerable<Customer> Get()
        {
            return CustomerRepository.GetAllFavorites();
        }
        [HttpPost]
        public IActionResult Post([FromBody] CustomerId value)
        {
            var customer = CustomerRepository.Get(value.Id);
            customer.IsFavorite = true;
            return new CreatedAtRouteResult("GETCUSTOMER", new { id = customer.Id }, null);
        }

    }
}
