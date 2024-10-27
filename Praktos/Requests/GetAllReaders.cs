using System.ComponentModel.DataAnnotations;

namespace Praktos.Requests
{
    public class GetAllReaders
    {
        public int Id_Readers { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int ContactDetails { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
