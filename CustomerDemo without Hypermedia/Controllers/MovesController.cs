using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDemo.Controllers
{
    [Route("api/Customers/{customerId:int}/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        public IEnumerable<Move> Get([FromRoute] int customerId)
        {
            var moves = CustomerRepository.GetAllMoves(customerId);
            return moves;
        }
        [HttpPost]
        public IActionResult Post([FromRoute] int customerId, [FromBody] Move move)
        {
            var customer = CustomerRepository.Get(customerId);
            customer.Street = move.Street;
            customer.City = move.City;
            customer.ZipCode = move.ZipCode;
            customer.Country = move.Country;
            CustomerRepository.AddMove(customerId, move);
            return new CreatedAtRouteResult("GETCUSTOMER", new { id = customerId }, null);
        }
    }
}
