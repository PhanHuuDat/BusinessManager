using BusinessManager.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Models.DTOs
{
    public class BookBookTagDTO
    {
        public int BookId { get; set; }
        public BookDTO Book { get; set; }

        public int BookTagId { get; set; }
        public BookTagDTO BookTag { get; set; }
    }
}
