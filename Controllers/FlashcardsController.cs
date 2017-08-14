using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bpt.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bpt.api.Controllers
{
    [Route("api/[controller]")]
    public class FlashcardsController : Controller
    {

        private BptContext _context;

        public FlashcardsController(BptContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Flashcard> Get()
        {
            var flashcard = new Flashcard()
            {
                Id = 2,
                Question = "Fat Mole"
            };
            var flashcards = new List<Flashcard>();
            flashcards.Add(flashcard);
            return flashcards;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostFlashcard([FromBody] Flashcard flashcard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Flashcards.Add(flashcard);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlashcardExists(flashcard.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetFlashcards", new { id = flashcard.Id }, flashcard);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool FlashcardExists(int id)
        {
            return _context.Flashcards.Any(f => f.Id == id);
        }
    }
}
