using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soim_Adrian_Lab2.Models;

namespace Soim_Adrian_Lab2.Data
{
    public class Soim_Adrian_Lab2Context : DbContext
    {
        public Soim_Adrian_Lab2Context (DbContextOptions<Soim_Adrian_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Soim_Adrian_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Soim_Adrian_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Soim_Adrian_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Soim_Adrian_Lab2.Models.Category>? Category { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
    }
}
