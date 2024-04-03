using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_BoombaMarket.Models;

namespace API_BoombaMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderShopsController : ControllerBase
    {
        private readonly MarketplaceDBContext _context;

        public OrderShopsController(MarketplaceDBContext context)
        {
            _context = context;
        }

        // GET: api/OrderShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderShop>>> GetOrderShops()
        {
          if (_context.OrderShops == null)
          {
              return NotFound();
          }
            return await _context.OrderShops.ToListAsync();
        }

        // GET: api/OrderShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderShop>> GetOrderShop(int? id)
        {
          if (_context.OrderShops == null)
          {
              return NotFound();
          }
            var orderShop = await _context.OrderShops.FindAsync(id);

            if (orderShop == null)
            {
                return NotFound();
            }

            return orderShop;
        }

        // PUT: api/OrderShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderShop(int? id, OrderShop orderShop)
        {
            if (id != orderShop.IdOrderShop)
            {
                return BadRequest();
            }

            _context.Entry(orderShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderShopExists(id))
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

        // POST: api/OrderShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderShop>> PostOrderShop(OrderShop orderShop)
        {
          if (_context.OrderShops == null)
          {
              return Problem("Entity set 'MarketplaceDBContext.OrderShops'  is null.");
          }
            _context.OrderShops.Add(orderShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderShop", new { id = orderShop.IdOrderShop }, orderShop);
        }

        // DELETE: api/OrderShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderShop(int? id)
        {
            if (_context.OrderShops == null)
            {
                return NotFound();
            }
            var orderShop = await _context.OrderShops.FindAsync(id);
            if (orderShop == null)
            {
                return NotFound();
            }

            _context.OrderShops.Remove(orderShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderShopExists(int? id)
        {
            return (_context.OrderShops?.Any(e => e.IdOrderShop == id)).GetValueOrDefault();
        }
    }
}
