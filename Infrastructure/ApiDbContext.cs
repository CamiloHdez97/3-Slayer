using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class E2AppContext : DbContext
{
        public E2AppContext(DbContextOptions options) : base(options)
        {
        }

             public DbSet<User> Users { get; set; }
             public DbSet<Rol>  Rols { get; set; }
             public DbSet<UserRol> UsersRols { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

}