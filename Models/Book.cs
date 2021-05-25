using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjektCRUD.Models
{
    public class Book
    {
        public int Id { get; set; }
        [DisplayName("Wypożyczone książki")]
        [Required]      //not null
        public string BookName { get; set; }
        public string Author { get; set; }
        public string BookType { get; set; }
        [Required]
        public DateTime GetBookDate { get; set; }
        public DateTime GiveBookDate { get; set; }

    }
}
