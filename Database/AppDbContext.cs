using Microsoft.EntityFrameworkCore;
using GetQuestions.Models;


namespace GetQuestions.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Quest> Quests { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quest>().HasNoKey();
        }
}

}
