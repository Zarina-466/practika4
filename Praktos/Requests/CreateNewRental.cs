using Praktos.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Praktos.Requests
{
    public class CreateNewRental
    {

        [Required]
        public int id_book { get; set; }

        [Required]
        public int id_readers { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}