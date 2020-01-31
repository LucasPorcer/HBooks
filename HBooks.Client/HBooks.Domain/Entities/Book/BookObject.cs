using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HBooks.Domain.Entities.Book
{
    public class BookObject
    {
        public decimal Id { get; set; }

        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        [Required]
        public string Name { get; set; }

        [MaxLength(150, ErrorMessage = "Descrição deve conter no máximo 150 caracteres")]
        [Required]
        public string ShortDescription { get; set; }

        [MaxLength(50, ErrorMessage = "Gênero deve conter no máximo 50 caracteres")]
        [Required]
        public string Genre { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int QtyRented { get; set; }
    }
}
