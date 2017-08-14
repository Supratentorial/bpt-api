using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bpt.api.Models
{
  public class BptContext : DbContext
  {
    public BptContext(DbContextOptions<BptContext> options) : base(options)
    {
    }

    public BptContext()
    {
    }

    public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestion { get; set; }
    public DbSet<Flashcard> Flashcards { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<BulletPage> BulletPages { get; set; }
    public DbSet<Bullet> Bullets { get; set; }
  }
}
