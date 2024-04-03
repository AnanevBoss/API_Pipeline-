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
    public class PhotoProductsController : ControllerBase
    {
        private readonly MarketplaceDBContext _context;

        public PhotoProductsController(MarketplaceDBContext context)
        {
            _context = context;
        }

        // GET: api/PhotoProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoProduct>>> GetPhotoProducts()
        {
          if (_context.PhotoProducts == null)
          {
              return NotFound();
          }
            return await _context.PhotoProducts.ToListAsync();
        }

        // GET: api/PhotoProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoProduct>> GetPhotoProduct(int? id)
        {
          if (_context.PhotoProducts == null)
          {
              return NotFound();
          }
            var photoProduct = await _context.PhotoProducts.FindAsync(id);

            if (photoProduct == null)
            {
                return NotFound();
            }

            return photoProduct;
        }

        // PUT: api/PhotoProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoProduct(int? id, PhotoProduct photoProduct)
        {
            if (id != photoProduct.IdPhotoProducts)
            {
                return BadRequest();
            }

            _context.Entry(photoProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoProductExists(id))
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

        // POST: api/PhotoProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoProduct>> PostPhotoProduct(PhotoProduct photoProduct)
        {
          if (_context.PhotoProducts == null)
          {
              return Problem("Entity set 'MarketplaceDBContext.PhotoProducts'  is null.");
          }
            _context.PhotoProducts.Add(photoProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoProduct", new { id = photoProduct.IdPhotoProducts }, photoProduct);
        }

        // DELETE: api/PhotoProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoProduct(int? id)
        {
            if (_context.PhotoProducts == null)
            {
                return NotFound();
            }
            var photoProduct = await _context.PhotoProducts.FindAsync(id);
            if (photoProduct == null)
            {
                return NotFound();
            }

            _context.PhotoProducts.Remove(photoProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetPhotoById/{id}")]
        public async Task<ActionResult<IEnumerable<PhotoProduct>>> GetPhotoById(int id)
        {
            var products = await _context.PhotoProducts.Where(p => p.ProductId == id).ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        private bool PhotoProductExists(int? id)
        {
            return (_context.PhotoProducts?.Any(e => e.IdPhotoProducts == id)).GetValueOrDefault();
        }


        // DELETE: api/PhotoProducts/5
        [HttpDelete("DeletePhotoProductByIdProduct{id}")]
        public async Task<IActionResult> DeletePhotoProductByIdProduct(int? id)
        {
            if (_context.PhotoProducts == null)
            {
                return NotFound();
            }
            var photoProduct = await _context.PhotoProducts.FirstOrDefaultAsync(a => a.ProductId == id);
            if (photoProduct == null)
            {
                return NotFound();
            }

            _context.PhotoProducts.Remove(photoProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
