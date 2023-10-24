using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace LibraryBooks
{
    public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }
        public string Description { get; set; } 
        public int Rating { get; set; }
        public virtual List<LibraryManager> ListOfReadersHaveTakenBooks { get; set; }=new List<LibraryManager>();

    }
}
