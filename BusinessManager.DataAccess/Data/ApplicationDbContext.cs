using BusinessManager.DataAccess.DAOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBookTag>().HasKey(sc => new { sc.BookId, sc.BookTagId });
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookCost> BookCost { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookSize> BookSize { get; set; }
        public DbSet<BookTag> BookTag { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<BookBookTag> BookBookTags { get; set; }

    }
}
