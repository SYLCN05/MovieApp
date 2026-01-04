using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Server.Models
{
    public class ApplicationDBContext:IdentityDbContext<MovieUser, IdentityRole<string>, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>().HasNoKey();
        }
        public DbSet<Movie> Movies => Set<Movie>();
    }
}
