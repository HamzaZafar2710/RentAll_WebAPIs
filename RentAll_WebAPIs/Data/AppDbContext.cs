using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RentAll_WebAPIs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()!.ToLower());
                foreach (var prop in entity.GetProperties())
                    prop.SetColumnName(prop.GetColumnName().ToLower());
            }


        }
    }
}
