using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Praktos.Model
{
    public class Genres
    {
        [Key]
        public int Id_Genres { get; set; }
        public string Title { get; set; }
    }
}
