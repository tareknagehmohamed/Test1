using Microsoft.EntityFrameworkCore;

namespace Test1.Models
{
    public class NewsConetext:DbContext
    {
        public NewsConetext(DbContextOptions<NewsConetext> options):base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Registerlogin> Registerlogins { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        
    }
}
