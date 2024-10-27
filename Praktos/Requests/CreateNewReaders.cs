using System.ComponentModel.DataAnnotations;

namespace Praktos.Requests
{
    public class CreateNewReaders
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Фамилия обязательна")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Дата рождения обязательна")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Номер обязателен")]
        public int ContactDetails { get; set; }
        public DateTime? RegistrationDate { get; set; }

    }
}
