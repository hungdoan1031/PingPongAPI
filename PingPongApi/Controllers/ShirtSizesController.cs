using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PingPongAPI.Entities;
using PingPongAPI.Utils;

namespace PingPongAPI.Controllers
{
    [AddHeader("Access-Control-Allow-Origin", "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtSizesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ShirtSizesController(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all shirt sizes ordered by 'Order'
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShirtSize>>> GetshirtSizes()
        {
            return await _context.ShirtSizes.OrderBy(s => s.Order).ToListAsync();
        }


        /// <summary>
        /// Get a shirt size
        /// </summary>
        /// <param name="id"> id of the shirt size</param>
        /// <returns></returns>        
        [HttpGet("{id}")]
        public async Task<ActionResult<ShirtSize>> GetShirtSize(string id)
        {
            var shirtSize = await _context.ShirtSizes.FindAsync(id);

            if (shirtSize == null)
            {
                return NotFound();
            }

            return shirtSize;
        }

        /// <summary>
        /// Update a shirt size
        /// </summary>
        /// <param name="id">shirt size id</param>
        /// <param name="shirtSize"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShirtSize(string id, ShirtSize shirtSize)
        {
            if (id != shirtSize.Id)
            {
                return BadRequest();
            }

            _context.Entry(shirtSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShirtSizeExists(id))
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

        /// <summary>
        /// Create a shirt size
        /// </summary>
        /// <param name="shirtSize"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ShirtSize>> PostShirtSize(ShirtSize shirtSize)
        {
            _context.ShirtSizes.Add(shirtSize);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShirtSizeExists(shirtSize.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShirtSize", new { id = shirtSize.Id }, shirtSize);
        }

        /// <summary>
        /// Delete a shirt size
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShirtSize>> DeleteShirtSize(string id)
        {
            var shirtSize = await _context.ShirtSizes.FindAsync(id);
            if (shirtSize == null)
            {
                return NotFound();
            }

            _context.ShirtSizes.Remove(shirtSize);
            await _context.SaveChangesAsync();

            return shirtSize;
        }

        private bool ShirtSizeExists(string id)
        {
            return _context.ShirtSizes.Any(e => e.Id == id);
        }
    }
}
