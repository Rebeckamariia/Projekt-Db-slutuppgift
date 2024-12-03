using Microsoft.EntityFrameworkCore;
using Projekt.Db.Models;
 
public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Authorbook> Authorbooks { get; set; }
    public DbSet<Loan> Loans { get; set; }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Projekt.Db-Bibliotekssystem;User Id=sa;Password=Snödroppe2023;Encrypt=False");
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfigurera relationen mellan Book och BookAuthor
        modelBuilder.Entity<Authorbook>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });
 
        modelBuilder.Entity<Authorbook>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.Authorbooks)
            .HasForeignKey(ba => ba.BookId);
 
        modelBuilder.Entity<Authorbook>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.AuthorBooks)
            .HasForeignKey(ba => ba.AuthorId);
 
        // Konfigurera relationen mellan Book och Loan
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookId);
    }
}