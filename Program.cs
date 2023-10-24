using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConsoleTables;

namespace LibraryBooks
{
    public class Program
    {
        public static BookContext context = new BookContext();
        static void Main(string[] args)
        {
           do 
            {
                Console.WriteLine("1.Knigi");
                Console.WriteLine("2.Chitateli");
                int action = int.Parse(Console.ReadLine());
                if(action == 1)
                {
                    BookMenu();
                }
                if (action == 2)
                {
                    ReaderMenu();
                }

            }
            while (true);

        }

        private static void ReaderMenu()
        {
            do
            {
                Console.WriteLine("1.Vivesti vseh chitatelei");
                Console.WriteLine("2.Dobavit chitatelya");
                Console.WriteLine("3.Izmenit chitatelya");
                Console.WriteLine("4.Udalit chitatelya");
                Console.WriteLine("5.Vivesti knigi chitatelya");
                Console.WriteLine("6.Exit");

                int choiceR = int.Parse(Console.ReadLine());
                if (choiceR == 1)
                {
                    ShowAllReaders();
                }
                if(choiceR == 2)
                {
                    Reader newReader = CreateReader();
                    context.Readers.Add(newReader);
                    context.SaveChanges();
                }
                if(choiceR == 3)
                {
                    Console.WriteLine("Vvedite ID chitatelya dlya izmeneniya");
                    int id = int.Parse(Console.ReadLine());
                    Reader reader = context.Readers.Find(id);
                    if (reader != null)
                    {
                        EditReader(reader);
                        context.SaveChanges();
                    }
                }
                if(choiceR == 4)
                {
                    Console.WriteLine("Vvedite ID chitatekya dlya udalenya");
                    int id = int.Parse(Console.ReadLine());
                    Reader reader = context.Readers.Find(id);
                    if (reader != null)
                    {
                        context.Readers.Remove(reader);
                        context.SaveChanges();
                    }

                }
                if(choiceR == 5)
                {
                    Console.WriteLine("Vvedite ID chitatekya dlya prosmotra");
                    int id = int.Parse(Console.ReadLine());
                    Reader reader = context.Readers.Include("BooksTakenFromLibrary").FirstOrDefault(t=>t.Id==id);
                    ShowBooksTakenFromLibrary(reader.BooksTakenFromLibrary);
                }
                if (choiceR == 6)
                    break;
            }
            while(true);
        }

        private static void ShowBooksTakenFromLibrary(List<LibraryManager> booksTakenFromLibrary)
        {
           
            var table = new ConsoleTable("Id", "Title","Name", "Surname", "StartingDate", "EndingDate","FactEndingDate");
            foreach (LibraryManager book in booksTakenFromLibrary)
            {
                table.AddRow(book.Id, book.Book.Title,book.Reader.Name, book.Reader.Surname, book.StartingDate, book.EndingDate, book.FactEndingDate);
            }
            table.Write();
        }

        private static void EditReader(Reader reader)
        {
            Console.WriteLine("1.Izmenit imya chitatelya");
            Console.WriteLine("2.Izmenit famliyu");
            Console.WriteLine("3.Izmenit address");
            Console.WriteLine("4.Izmenit telephone");
            int change = int.Parse(Console.ReadLine());
            if (change == 1)
            {
                Console.WriteLine("Vvedite imya chiatelya");
                reader.Name = Console.ReadLine();

            }
            if (change == 2)
            {
                Console.WriteLine("Vvedite familiu chitatlya");
                reader.Surname = Console.ReadLine();
            }
            if (change == 3)
            {
                Console.WriteLine("Vvedite address chitatelya");
                reader.Address = Console.ReadLine();
            }
            if (change == 4)
            {
                Console.WriteLine("Vvedite nomer telephona");
                reader.Phone = Console.ReadLine();
            }

        }

        private static Reader CreateReader()
        {
            Reader reader = new Reader();
            Console.WriteLine("Vvedite imya chitatelya");
            reader.Name = Console.ReadLine();
            Console.WriteLine("Vvedite familiyu");
            reader.Surname = Console.ReadLine();
            Console.WriteLine("Vvedite address");
            reader.Address = Console.ReadLine();
            Console.WriteLine("Vvedite telephone");
            reader.Phone = Console.ReadLine();
            return reader;

        }

        private static void ShowAllReaders()
        {
            List<Reader> readers = context.Readers.ToList();
            var table = new ConsoleTable("Id", "Name", "Surname", "Address","Phone");
            foreach (Reader reader in readers)
            {
                table.AddRow(reader.Id, reader.Name, reader.Surname,reader.Address, reader.Phone);
            }
            table.Write();
        }

        private static void BookMenu()
        {
            do 
            { 
                Console.WriteLine("1.Vidat knigu");
                Console.WriteLine("2.Dobavit knigu");
                Console.WriteLine("3.Sdat knigu");
                Console.WriteLine("4.Vivesti vse knigi");
                Console.WriteLine("5.Redactirovat knigu");
                Console.WriteLine("6.Udalit knigu");
                Console.WriteLine("7.Exit");
                int choice = int.Parse(Console.ReadLine());
                if(choice ==1)
                {
                    ShowAllBooks();
                    Console.WriteLine("Vvedite ID knigi dlya vidachi");
                    int id = int.Parse(Console.ReadLine());
                    Book book = context.Books.Find(id);
                    ShowAllReaders();
                    Console.WriteLine("Vvedite ID chitatelya");
                    int idCh= int.Parse(Console.ReadLine());
                    Reader reader = context.Readers.Find(idCh);
                    LibraryManager libraryM = new LibraryManager();
                    libraryM.Reader = reader;
                    libraryM.Book = book;   
                    libraryM.StartingDate = DateTime.Now;
                    libraryM.EndingDate = DateTime.Now.AddDays(14);
                    context.LibraryManagers.Add(libraryM);
                    context.SaveChanges();
                }
                if (choice==2)
                {
                    Book newBook = CreateBook();
                    context.Books.Add(newBook);
                    context.SaveChanges();
                }
                if (choice == 4)
                {
                    ShowAllBooks();
                }
                if(choice == 5)
                {
                    Console.WriteLine("Vvedite ID knigi dlya izmeneniya");
                    int id = int.Parse(Console.ReadLine());
                    Book book = context.Books.Find(id);
                    if (book != null)
                    {
                        EditBook(book);
                        context.SaveChanges();
                    }
                }
                if(choice ==6)
                {
                    Console.WriteLine("Vvedite ID knigi dlya izmeneniya");
                    int id = int.Parse(Console.ReadLine());
                    Book book = context.Books.Find(id);
                    if(book != null)
                    {
                        context.Books.Remove(book);
                        context.SaveChanges();
                    }

                }
                if (choice == 7)
                {
                    break;
                }
                
            }
            while (true);
        }

        private static void EditBook(Book book)
        {
            Console.WriteLine("1.Izmenit nazvanie knigi");
            Console.WriteLine("2.Izmenit avtora knigi");
            Console.WriteLine("3.Izmenit god publicazii");
            Console.WriteLine("4.Izmenit opisanie knigi");
            
            int change = int.Parse(Console.ReadLine());
            if (change == 1)
            {
                Console.WriteLine("Vvedite nazvanie knigi");
                book.Title = Console.ReadLine();

            }
            if (change == 2)
            {
                Console.WriteLine("Vvedite avtora knigi");
                book.Author = Console.ReadLine();
            }
            if (change == 3)
            {
                Console.WriteLine("Vvedite god publicazii knigi");
                book.YearOfPublication = int.Parse(Console.ReadLine());
            }
            if (change == 4)
            {
                Console.WriteLine("Vvedite opisanie knigi");
                book.Description = Console.ReadLine();
            }
            


                
        
            
            
        }

        private static void ShowAllBooks()
        {
            List<Book> books = context.Books.ToList();
            var table = new ConsoleTable("Id", "Title", "Author", "YearOfPublication");
            foreach (Book book in books)
            {
                table.AddRow(book.Id,book.Title,book.Author, book.YearOfPublication);                
            }
            table.Write();            
        }

        private static Book CreateBook()
        {
            Book book = new Book();
            Console.WriteLine("Vvedite nazvanie knigi");
            book.Title = Console.ReadLine();
            Console.WriteLine("Vvedite avtora");
            book.Author = Console.ReadLine();
            Console.WriteLine("Vvedite god izdania");
            book.YearOfPublication = int.Parse(Console.ReadLine());            
            return book;           
            
        }
    }
}
