using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.DataAccess.DAOs
{
    public class BookBookTag
    {
        [Key, Column(Order = 0)]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Key, Column(Order = 1)]
        public int BookTagId { get; set; }
        public BookTag BookTag { get; set; }
    }
}
