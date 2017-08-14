using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bpt.api.Models
{
    public class Bullet
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public string Status { get; set; }
        public virtual BulletPage BulletPage { get; set; }
        public int BulletPageId { get; set; }
    }

}
