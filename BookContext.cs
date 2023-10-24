using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks
{
    public class BookContext : DbContext
    {
        static BookContext()
        {
            Database.SetInitializer(new MyInitialiser());
        }
        public BookContext():base("Connection") 
        {

        }
        public DbSet<Book> Books { get; set;}
        public DbSet<Reader> Readers { get; set;}
        public DbSet<LibraryManager> LibraryManagers { get; set;}


    }
}
