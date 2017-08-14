using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bpt.api.Models;

namespace bpt2.Data
{
  public class BulletRepository : IBulletRepository
  {

    private BptContext _context;

    public BulletRepository(BptContext context)
    {
      this._context = context;
    }

    public void AddBulletForPage(int bulletPageId, Bullet bullet)
    {
      var bulletPage = GetBulletPageById(bulletPageId);
    }

    public BulletPage GetBulletPageById(int bulletPageId)
    {
      return this._context.BulletPages.FirstOrDefault(bp => bp.Id == bulletPageId);
    }
  }
}
