#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KanbanAPI.Models;

namespace KanbanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardItemsController : ControllerBase
    {
        private readonly CardContext _context;

        public CardItemsController(CardContext context)
        {
            _context = context;
        }

        // GET: api/CardItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardItem>>> GetCardItems()
        {
            return await _context.CardItems.ToListAsync();
        }

        // GET: api/CardItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardItem>> GetCardItem(int id)
        {
            var cardItem = await _context.CardItems.FindAsync(id);

            if (cardItem == null)
            {
                return NotFound();
            }

            return cardItem;
        }

        // PUT: api/CardItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardItem(int id, CardItem cardItem)
        {
            if (id != cardItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cardItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardItemExists(id))
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

        // POST: api/CardItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardItem>> PostCardItem(CardItem cardItem)
        {
            _context.CardItems.Add(cardItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardItem", new { id = cardItem.Id }, cardItem);
        }

        // DELETE: api/CardItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardItem(int id)
        {
            var cardItem = await _context.CardItems.FindAsync(id);
            if (cardItem == null)
            {
                return NotFound();
            }

            _context.CardItems.Remove(cardItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardItemExists(int id)
        {
            return _context.CardItems.Any(e => e.Id == id);
        }
    }
}
