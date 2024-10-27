using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Praktos.Model
{
    public class BookRentalHistory
    {
        [Key]
        public int Id_BookRentalHistory { get; set; }
        [Required]
        [ForeignKey("Books")]
        public int Id_Books { get; set; }
        public Books Books { get; set; }
        [Required]
        [ForeignKey("Readers")]
        public int Id_Readers { get; set; }
        public Readers Readers { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
