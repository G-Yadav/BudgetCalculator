
using com.gaurav.domain.models;
using com.gaurav.domain.models.Fluent;
using Microsoft.EntityFrameworkCore;

namespace com.gaurav.main.infrastructure
{
    public class BloggingContext : DbContext
    {
        // public BloggingContext() { }
        // protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=localhost,1433;Database=ApplicationDB;User=sa;Password=P@ssw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true");

        public BloggingContext(DbContextOptions<BloggingContext> options): base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Book> Books {get; set;}
        public DbSet<BookDetail> BookDetails { get; set; }

        // Fluent Classes
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fluent_Book>().HasKey(x=>x.BookId); //.Property(x => x.BookId)
            modelBuilder.Entity<Fluent_Book>().Property(x=>x.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(x=>x.Title).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Book>().Property(x=>x.ISBN).HasMaxLength(50);
            // modelBuilder.Entity<Fluent_Book>().Property(x=>x.Publisher_Id)

            modelBuilder.Entity<Fluent_BookDetail>().HasKey(x=>x.BookDetail_Id);

            modelBuilder.Entity<Fluent_Author>().ToTable("Authors_fluent");
            modelBuilder.Entity<Fluent_Author>().HasKey(x=>x.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(x=>x.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(x=>x.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(x=>x.FullName);

            modelBuilder.Entity<Fluent_Publisher>().ToTable("Publisher_fluent");
            modelBuilder.Entity<Fluent_Publisher>().HasKey(x=>x.Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(x=>x.Id).HasColumnName("Publisher_Id");
            modelBuilder.Entity<Fluent_Publisher>().Property(x=>x.Name).IsRequired();
        }
    }
}