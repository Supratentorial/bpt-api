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
  public class BulletPagesController : Controller
  {
    private BptContext _context;

    public BulletPagesController(BptContext context)
    {
      _context = context;
    }

    // GET: api/values
    [HttpGet]
    public IEnumerable<BulletPage> GetBulletPage([FromQuery]Boolean includeBullets = false)
    {
      IQueryable<BulletPage> bulletPages = _context.BulletPages;
      if (includeBullets == true) {
        bulletPages = bulletPages.Include(bp => bp.Bullets);
      }
      return bulletPages;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBulletPage(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var bulletPage = await _context.BulletPages.SingleOrDefaultAsync(bp => bp.Id == id);

      if (bulletPage == null)
      {
        return NotFound();
      }

      return Ok(bulletPage);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> PostBulletPage([FromBody] BulletPage bulletPage)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.BulletPages.Add(bulletPage);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (BulletPageExists(bulletPage.Id))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("GetBulletPage", new { id = bulletPage.Id }, bulletPage);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute]int id, [FromBody]BulletPage bulletPage)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != bulletPage.Id)
      {
        return BadRequest();
      }

      _context.Entry(bulletPage).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BulletPageExists(id))
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

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    private bool BulletPageExists(int id)
    {
      return _context.BulletPages.Any(bp => bp.Id == id);
    }
  }
}
