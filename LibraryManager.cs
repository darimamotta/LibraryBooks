using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks
{
    public class LibraryManager
    {
        public int Id { get; set; }
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set;}
        public DateTime? FactEndingDate { get; set; }
    }
}
