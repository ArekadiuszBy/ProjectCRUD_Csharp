using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


//Model Itemu - pożyczony lub oddany
namespace ProjektCRUD.Models
{
    public class Item
    {
        //DB

        //Primary value - samo się zwiększa po dodaniu następnych rekordów do bd
        [Key]
        public int Id { get; set; }
        [Required]      //not null
        public string Borrower { get; set; }
        public string Lender { get; set; }

        //By na stronie ładnie wyświetlały się nazwy kolumn
        [DisplayName("Item Name")]
        [Required]
        public string ItemName { get; set; }
        [Range(1,999,ErrorMessage = "Ilość musi być większa od 0")]
        public int Quantity { get; set; }
    }
}
