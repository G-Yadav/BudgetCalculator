using com.gaurav.main.infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace com.gaurav.main.infrastructure
{
    public class BloggingContext : DbContext
    {
        public BloggingContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=localhost,1433;Database=ApplicationDB;User=sa;Password=P@ssw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true");

        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<FinancialStatement>? FinancialStatements { get; set; }
    }
}