using System.ComponentModel.DataAnnotations;

namespace Praktos.Requests
{
    public class CreateNewAutors
    {
        [Required(ErrorMessage ="Имя обязательно")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия обязательна")]
        public string LastName { get; set; }
    }
}
