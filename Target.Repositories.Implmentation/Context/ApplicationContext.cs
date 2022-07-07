using Microsoft.EntityFrameworkCore;
using Target.Entities.Entities;
using Target.Repositories.Implementation.Mapping;

namespace Target.Repositories.Implementation.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}
