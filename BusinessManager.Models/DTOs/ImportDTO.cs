﻿using BusinessManager.DataAccess.DAOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManager.Models.DTOs
{
    public class ImportDTO : BaseDTO
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Quantity should greater than one.")]
        public int Quantity { get; set; }
        [Required]
        public DateTime? ImportDate { get; set; }
    }
}
