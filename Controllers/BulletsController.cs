using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bpt.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using bpt.api.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bpt.api.Controllers
{
  [Route("api/bulletpages/{bulletPageId}/bullets")]
  public class BulletsController : Controller
  {

    private BptContext _context;
    private readonly IMapper _mapper;

    public BulletsController(BptContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    // GET: api/values
    [HttpGet]
    public async Task<IActionResult> GetBulletsForBulletPage(int bulletPageId)
    {
      if (bulletPageId == 0)
      {
        return BadRequest();
      }

      if (!_context.BulletPages.Any(bp => bp.Id == bulletPageId))
      {
        return NotFound();
      }

      var bulletsForBulletPage = await _context.Bullets.Where(b => b.BulletPageId == bulletPageId && b.Status == "Active").ToListAsync();
      var bulletDTOs = Mapper.Map<IEnumerable<Bullet>, IEnumerable<BulletDTO>>(bulletsForBulletPage);
      return Ok(bulletsForBulletPage);
    }

    //// GET api/values/5
    //[HttpGet("{bulletId}")]
    //public async IActionResult Get(int bulletId)
    //{

    //}

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> CreateBulletForBulletPage([FromBody]BulletDTO bulletDTO, [FromRoute]int bulletPageId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (bulletDTO.Id != 0 || bulletPageId == 0)
      {
        return BadRequest();
      }

      if (!_context.BulletPages.Any(bp => bp.Id == bulletPageId))
      {
        return NotFound();
      }

      var bulletPage = _context.BulletPages.FirstOrDefault(bp => bp.Id == bulletPageId);
      var bullet = _mapper.Map<BulletDTO, Bullet>(bulletDTO);
      bulletPage.Bullets.Add(bullet);

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (BulletExists(bulletDTO.Id))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
      }
      return Ok(bulletDTO);
    }

    // PUT api/values/5
    [HttpPut("{bulletId}")]
    public async Task<IActionResult> Put(int bulletId, [FromBody]BulletDTO bulletDTO)
    {
      if (!BulletExists(bulletId)) {
        return NotFound();
      }
      if (bulletId == 0) {
        return BadRequest();
      }
      var bullet = _mapper.Map<BulletDTO, Bullet>(bulletDTO);
      _context.Update(bullet);
      await _context.SaveChangesAsync();
      return Ok(bullet);
    }

    // DELETE api/values/5
    [HttpDelete("{bulletId}")]
    public async Task<IActionResult> Delete(int bulletId)
    {
      if (bulletId == 0)
      {
        return BadRequest();
      }
      if (!BulletExists(bulletId))
      {
        return NotFound();
      }
      var bullet = await _context.Bullets.FirstOrDefaultAsync(b => b.Id == bulletId);
      bullet.Status = "Deleted";

      await _context.SaveChangesAsync();
      return Ok();
    }

    private bool BulletExists(int id)
    {
      return _context.Bullets.Any(b => b.Id == id);
    }
  }
}
