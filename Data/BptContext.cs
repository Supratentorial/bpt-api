using Microsoft.EntityFrameworkCore;

namespace bpt.api.Models{
    public class BptContext : DbContext{
        public BptContext(DbContextOptions<BptContext>options): base(options)
        {
            
        }

        public DbSet<Bullet> Bullets { get; set; }
        public DbSet<BulletPage> BulletPages { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<MultipleChoiceQuestion>().ToTable("MultipleChoiceQuestions");
        }
    }
}