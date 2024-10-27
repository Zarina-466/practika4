using Azure.Core.Pipeline;
using System.ComponentModel.DataAnnotations;

namespace Praktos.Model
{
    public class Readers
    {
        [Key]
        public int Id_Readers { get; set; }
        [Required]
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int ContactDetails {  get; set; }
        public DateTime? RegistrationDate {  get; set; }
    }
}
