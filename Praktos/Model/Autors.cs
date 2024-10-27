using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Praktos.Model
{
    public class Autors
    {
        [Key]
        public int Id_Autors { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
