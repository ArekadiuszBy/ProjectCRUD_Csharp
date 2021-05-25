using Microsoft.EntityFrameworkCore;
using ProjektCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektCRUD.Data
{
    public class AppDbContext : DbContext
    {
        //konstruktor do stworzenia DB i przechowywania danych danych
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Models -> Item
        public DbSet<Item> Items { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
