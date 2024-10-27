namespace Praktos.Requests
{
    public class GetAllBooksName
    {
        public int Id_Books { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public string Genre { get; set; }
        public int AvailableCopies { get; set; }
        public int YearOfPublication { get; set; }
        public string Description { get; set; }
    }
    public class GetAllBooksId
    {
        public int Id_Books { get; set; }
        public string Title { get; set; }
        public int Id_Autors { get; set; }
        public int Id_Genre { get; set; }
        public int AvailableCopies { get; set; }
        public int YearOfPublication { get; set; }
        public string Description { get; set; }
    }
    public class BookAvailableCopies
    {
        public int Id_Books { get; set; }
        public string Title { get; set; }
        public int AvailableCopies { get; set; }
    }
}