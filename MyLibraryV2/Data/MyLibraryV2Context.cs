using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLibraryV2.Models;

namespace MyLibraryV2.Data
{
    public class MyLibraryV2Context : DbContext
    {
        public MyLibraryV2Context (DbContextOptions<MyLibraryV2Context> options)
            : base(options)
        {
        }

        public DbSet<MyLibraryV2.Models.Book> Book { get; set; } = default!;
        public DbSet<MyLibraryV2.Models.Library> Library { get; set; } = default!;
        public DbSet<MyLibraryV2.Models.Shelf> Shelf { get; set; } = default!;
        public DbSet<MyLibraryV2.Models.BookSet> BookSet { get; set; } = default!;
        

        
    }
}
