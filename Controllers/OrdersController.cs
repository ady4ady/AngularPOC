using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarOrderingWebApi.Models;
using Microsoft.AspNet.OData;
using CarOrderingWebApi.ViewModels;
using LinqKit;

namespace CarOrderingWebApi.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CarOrderingDBContext _context;

        public OrdersController(CarOrderingDBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [Route("api/[controller]")]
        [EnableQuery]
        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            return _context.Order;
        }

        // GET: api/Orders/5
        [Route("api/[controller]")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderVM order)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var orderIdCode = randomOrderIdGenerator();
            foreach (var carid in order.CarId)
            {
                Order ordr = new Order()
                {
                    CarId = carid,
                    RegistrationId = order.UserId,
                    OrderIdCode = orderIdCode
                };

                _context.Order.Add(ordr);
            }

            order.OrderIdCode = orderIdCode;

            await _context.SaveChangesAsync();

            return Ok(order);
        }

        // POST: api/UserOrdersList
        [Route("api/UserOrdersList")]
        [HttpGet]
        public async Task<IActionResult> UserOrdersList(int userId, string orderIdCode)
        {
            var predicate = PredicateBuilder.New<Order>();

            if (userId > 0)
            {
                predicate = predicate.And(x => x.RegistrationId == userId);
            }

            if (!string.IsNullOrEmpty(orderIdCode))
            {
                predicate = predicate.And(x => x.OrderIdCode == orderIdCode);
            }

            var orders = await _context.Order.Where(predicate).Include(x => x.Car).GroupBy(
                x => x.OrderIdCode, (k, y) => new OrderVM { OrderIdCode = y.FirstOrDefault().OrderIdCode, CarId = y.Select(z => z.CarId).ToList(), OrderIdList = y.Select(z => z.OrderId).ToList(), UserId = y.FirstOrDefault().RegistrationId, CarsOrdered = y.Select(z => new CarVM() { CarId = z.Car.CarId, CarName = z.Car.CarName, CarPrice = z.Car.CarPrice }).ToList() }).ToListAsync();


            //await _context.SaveChangesAsync();

            return Ok(orders);
        }

        // DELETE: api/Orders/5
        [Route("api/[controller]/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] string id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var order = await _context.Order.Where(x => x.OrderIdCode == id).ToListAsync();
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.RemoveRange(order);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }

        private string randomOrderIdGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
    }
}