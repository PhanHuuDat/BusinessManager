﻿using BusinessManager.DataAccess.DAOs;
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
        public DbSet<Author> Author { get; set; }
        public DbSet<BookCost> BookCost { get; set; }
        public DbSet<BookImage> BookImage { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookSize> BookSize { get; set; }
        public DbSet<BookTag> BookTag { get; set; }
        public DbSet<CoverForm> CoverForm { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

    }
}
