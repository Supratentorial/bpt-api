using System.Collections.Generic;

namespace bpt.api.Models
{
    public class BulletPage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();
    }
}
