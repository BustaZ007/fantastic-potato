using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.Models.DBModels
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options){ }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<AuthorModel> AuthorModels { get; set; }
        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<FeedbackModel> FeedbackModels { get; set; }
    }
}