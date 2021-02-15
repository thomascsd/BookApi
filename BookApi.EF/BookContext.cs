using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApi.EF
{
   public class BookContext: DbContext
    {
        public BookContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Writer> Writers { get; set; }
    }

}
