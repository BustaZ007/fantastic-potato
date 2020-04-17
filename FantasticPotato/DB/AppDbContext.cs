﻿using FantasticPotato.DB.Repository;
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
                optionsBuilder.UseSqlite(
                    "Data Source = C:/Users/Вувка/RiderProjects/fantastic-potato/FantasticPotato/fantastic_potato.db");
            }
        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<AuthorModel> AuthorModels { get; set; }
        public DbSet<BookModel> BookModels { get; set; }
        public DbSet<FeedbackModel> FeedbackModels { get; set; }
    }
}
