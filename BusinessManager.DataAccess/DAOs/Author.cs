﻿using System.ComponentModel.DataAnnotations;

namespace BusinessManager.DataAccess.DAOs
{
    public class Author : BaseDAO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }

    }
}
