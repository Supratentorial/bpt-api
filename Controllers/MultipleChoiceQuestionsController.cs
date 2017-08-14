using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bpt.api.Models;

namespace bpt.api.Controllers
{
    [Produces("application/json")]
    [Route("api/mcqs")]
    public class MultipleChoiceQuestionController : Controller
    {
        private readonly BptContext _context;

        public MultipleChoiceQuestionController(BptContext context)
        {
            _context = context;
        }

        // GET: api/mcqs
        [HttpGet]
        public IEnumerable<MultipleChoiceQuestion> GetMultipleChoiceQuestion()
        {
            var mcqs = this._context.MultipleChoiceQuestion
                .Include(mcq => mcq.Options)
                .Include(mcq => mcq.References)
                .ToList();
            return mcqs;
        }

        // GET: api/mcqs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMultipleChoiceQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var multipleChoiceQuestion = await _context.MultipleChoiceQuestion
                .Include(mcq => mcq.Options)
                .Include(mcq=> mcq.References)
                .SingleOrDefaultAsync(mcq => mcq.Id == id);

            if (multipleChoiceQuestion == null)
            {
                return NotFound();
            }

            return Ok(multipleChoiceQuestion);
        }

        // PUT: api/mcqs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultipleChoiceQuestion([FromRoute] int id, [FromBody] MultipleChoiceQuestion multipleChoiceQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != multipleChoiceQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(multipleChoiceQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultipleChoiceQuestionExists(id))
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

        // POST: api/mcqs
        [HttpPost]
        public async Task<IActionResult> PostMultipleChoiceQuestion([FromBody] MultipleChoiceQuestion multipleChoiceQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MultipleChoiceQuestion.Add(multipleChoiceQuestion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MultipleChoiceQuestionExists(multipleChoiceQuestion.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMultipleChoiceQuestion", new { id = multipleChoiceQuestion.Id }, multipleChoiceQuestion);
        }

        // DELETE: api/mcqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMultipleChoiceQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var multipleChoiceQuestion = await _context.MultipleChoiceQuestion.SingleOrDefaultAsync(m => m.Id == id);
            if (multipleChoiceQuestion == null)
            {
                return NotFound();
            }

            _context.MultipleChoiceQuestion.Remove(multipleChoiceQuestion);
            await _context.SaveChangesAsync();

            return Ok(multipleChoiceQuestion);
        }

        private bool MultipleChoiceQuestionExists(int id)
        {
            return _context.MultipleChoiceQuestion.Any(e => e.Id == id);
        }
    }
}