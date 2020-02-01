using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HBooks.Domain.Entities.Book
{
    public class BookObject
    {
        public decimal Id { get; set; }

        [MaxLength(30, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        [Required]
        [DisplayName("Título")]
        
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Descrição deve conter no máximo 150 caracteres")]
        [Required]
        [DisplayName("Pequena Descrição")]
        public string ShortDescription { get; set; }

        [MaxLength(10, ErrorMessage = "Gênero deve conter no máximo 50 caracteres")]
        [Required]
        [DisplayName("Gênero")]
        public string Genre { get; set; }

        [Required]
        [DisplayName("Qtd. Estoque")]
        public int Qty { get; set; }

        [Required]
        [DisplayName("Qtd. Alugada")]
        public int QtyRented { get; set; }

        [DisplayName("Qtd. Disponível")]
        public int QtyAvaliable => GetQtyAvaliable();

        private int GetQtyAvaliable()
        {
            if (Qty != 0 && (Qty > QtyRented))
                return (Qty - QtyRented);

            return 0;
        }
    }
}
