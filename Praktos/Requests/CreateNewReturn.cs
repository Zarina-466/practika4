using System.ComponentModel.DataAnnotations;

namespace Praktos.Requests
{
    public class CreateNewReturn
    {
        [Required]
        public int id_Rental { get; set; }
    }
}