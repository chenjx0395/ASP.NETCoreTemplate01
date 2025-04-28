using System.Reflection;
using Entity.model;
using Microsoft.EntityFrameworkCore;

namespace Repository.EFCore
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Entity.dll");
            var assembly = Assembly.LoadFrom(fullPath);
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(type.Assembly);
            }

            //  modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
