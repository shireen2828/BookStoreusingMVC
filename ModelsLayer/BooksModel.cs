﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class BooksModel
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
