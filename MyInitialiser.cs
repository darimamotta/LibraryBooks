using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks
{
    public class MyInitialiser:DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            base.Seed(context);
            Reader reader1 = new Reader();
            reader1.Name = "Ivan";
            reader1.Surname = "Tertychny";
            reader1.Address = "Zavodskaya 7";
            reader1.Phone = "79258765532";
            context.Readers.Add(reader1);
            Book book1 = new Book();
            book1.Title = "BestTitleForBook";
            book1.Author = "Klark";
            book1.YearOfPublication = 2016;
            book1.Description = "Description";
            context.Books.Add(book1);
            context.SaveChanges();
        }
    }
}
