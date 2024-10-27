using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Praktos.Model
{
    public class Books
    {
        [Key]
        public int Id_Books { get; set; }
        public string Title { get; set; }

        [Required]
        [ForeignKey("Autors")]
        public int Id_Autors { get; set; }
        public Autors Autors { get; set; }       
        [Required]
        [ForeignKey("Genres")]
        public int Id_Genre { get; set; }
        public Genres Genres { get; set; }
        public int AvailableCopies { get; set; }
        public int YearOfPublication { get; set; }
        public string Description { get; set; }
    }
}
