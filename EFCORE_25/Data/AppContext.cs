using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace EFCORE_25.Data
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppContext()
        {
            // Удаляет базу данных, если она существует
            Database.EnsureDeleted();
            Database.EnsureCreated(); // Создает базу данных, если ее нет
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=GOSLING\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка отношений между сущностями
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author) // Связь "один к одному" с автором
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre) // Связь "один к одному" с жанром
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);
        }
    }
}