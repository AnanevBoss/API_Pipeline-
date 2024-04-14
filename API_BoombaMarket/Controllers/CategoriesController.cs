using API_BoombaMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_BoombaMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MarketplaceDBContext _context;

        public CategoriesController(MarketplaceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if (_context.Categories == null)
                return NotFound();

            return await _context.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int? id)
        {
            if (_context.Categories == null)
                return NotFound();

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            return category;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int? id, Category category)
        {
            if (id != category.IdCategory)
                return BadRequest();

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (_context.Categories == null)
                return Problem("Entity set 'MarketplaceDBContext.Categories'  is null.");

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.IdCategory }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (_context.Categories == null)
                return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetByNameCategories/{categoryName}")]
        public async Task<ActionResult<Category>> GetByNameCategories(string categoryName)
        {
            if (categoryName == null)
                return NotFound();

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.NameCategory == categoryName);

            if (category == null)
                return NotFound();

            return category;
        }

        private bool CategoryExists(int? id)
        {
            return (_context.Categories?.Any(e => e.IdCategory == id)).GetValueOrDefault();
        }
    }
}
