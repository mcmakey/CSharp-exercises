#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardService.Models;

namespace CardService.Controllers
{
    [Route("api/Cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardServiceContext _context;

        public CardsController(CardServiceContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDTO>>> GetCards()
        {
            return await _context.Cards
                .Select(x => CardToDTO(x))
                .ToListAsync();
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDTO>> GetCard(long id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return CardToDTO(card);
        }

        // PUT: api/Cards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(long id, CardDTO cardDTO)
        {
            if (id != cardDTO.Id)
            {
                return BadRequest();
            }

            // _context.Entry(cardDTO).State = EntityState.Modified;

            var card = await _context.Cards.FindAsync(id);

            card.Number = cardDTO.Number;
            card.PaymentSystem = cardDTO.PaymentSystem;
            card.Bank = cardDTO.Bank;
            card.ValidThru = cardDTO.ValidThru;
            card.CardOwnerFirstName = cardDTO.CardOwnerFirstName;
            card.CardOwnerLastName = cardDTO.CardOwnerLastName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardDTO>> PostCard(CardDTO cardDTO)
        {
            var card = new Card
            {
                Number = cardDTO.Number,
                PaymentSystem = cardDTO.PaymentSystem,
                Bank = cardDTO.Bank,
                ValidThru = cardDTO.ValidThru,
                CardOwnerFirstName = cardDTO.CardOwnerFirstName,
                CardOwnerLastName = cardDTO.CardOwnerLastName,
            };

            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    nameof(GetCard),
                    new { id = card.Id },
                    CardToDTO(card));
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(long id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(long id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }

        private static CardDTO CardToDTO(Card card) =>
            new CardDTO
            {
                Id = card.Id,
                Number = card.Number,
                PaymentSystem = card.PaymentSystem,
                Bank = card.Bank,
                ValidThru = card.ValidThru,
                CardOwnerFirstName = card.CardOwnerFirstName,
                CardOwnerLastName = card.CardOwnerLastName,
            };
    }
}
