using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bpt.api.Models;

namespace bpt2.Data
{
  interface IBulletRepository
  {
    void AddBulletForPage(int bulletPageId, Bullet bullet);

    BulletPage GetBulletPageById(int bulletPageId);
  }
}
