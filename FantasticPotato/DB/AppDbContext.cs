using System.IO;
using FantasticPotato.DB.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FantasticPotato.Models.DBModels
{
    public class AppDbContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Я не знаю почему, но это не рабоатет
                // optionsBuilder.UseSqlite(Path.Combine(env.ContentRootPath, "fantastic_potato.db"));
                optionsBuilder.UseSqlite(
                "Data Source = E:/RiderProjects/fantastic-potato/FantasticPotato/fantastic_potato.db");
            }
        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<AuthorModel> AuthorModels { get; set; }
        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<FeedbackModel> FeedbackModels { get; set; }
    }
}