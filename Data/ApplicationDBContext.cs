using System;
using Microsoft.EntityFrameworkCore;
using api.Models;
using ContactListAPI.Models;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<UserCadastrados> UserCadastrados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("YourConnectionString", sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5, 
                        maxRetryDelay: TimeSpan.FromSeconds(10), 
                        errorNumbersToAdd: null 
                    );
                });
            }
        }
    }
}
