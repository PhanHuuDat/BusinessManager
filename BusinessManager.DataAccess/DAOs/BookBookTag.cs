using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.DataAccess.DAOs
{
    public class BookBookTag
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int BookTagId { get; set; }
        public BookTag BookTag { get; set; }
    }
}
