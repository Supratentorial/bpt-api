using System;
using System.Collections.Generic;
using System.Text;

namespace bpt.api.DTOs
{
    public class BulletDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public string Status { get; set; }
        public int BulletPageId { get; set; }
    }
}
