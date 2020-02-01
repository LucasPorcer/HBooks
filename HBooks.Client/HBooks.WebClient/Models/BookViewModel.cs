using HBooks.Domain.Entities.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HBooks.WebClient.Models
{
    public class BookViewModel
    {
        [DisplayName("Cód")]
        public decimal Id { get; set; }

        [DisplayName("Título")]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        public string ShortDescription { get; set; }

        [DisplayName("Gênero")]
        public string Genre { get; set; }

        [DisplayName("Qtd")]
        public int Qty { get; set; }

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

        public BookViewModel(List<BookObject> items)
        {
            Items = items;
        }

        public List<BookObject> Items { get; set; }
    }
}
