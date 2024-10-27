using Praktos.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Praktos.Requests
{
    public class CreateNewBooks
    {
        [Required(ErrorMessage = "Название книги обязательно")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Автор книги обязателен")]
        public int Id_Autors { get; set; }
        [Required(ErrorMessage = "Жанр книги обязателен")]
        public int Id_Genre { get; set; }
        [Required(ErrorMessage = "Колмчетво копий обязательно")]
        [Range(0, int.MaxValue, ErrorMessage = "Количество копий не может быть ниже меня")]
        public int AvailableCopies { get; set; }
        public int YearOfPublication { get; set; }
        public string Description { get; set; }
    }
}
