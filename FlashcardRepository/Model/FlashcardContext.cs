using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlashcardRepositoryImplementation.Model
{
    public class FlashcardContext : DbContext
    {
        public DbSet<Flashcard> Flashcards { get; set; } = null!;

        public FlashcardContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresDB"));
        }
    }
}
