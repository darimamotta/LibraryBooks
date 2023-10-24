using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual List<LibraryManager> BooksTakenFromLibrary { get; set; } = new List<LibraryManager>();
        
    }
}
