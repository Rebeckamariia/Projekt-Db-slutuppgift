using System.Data;

namespace Projekt.Db.Models
{
    public class Authorbook
    {
        public int BookId { get; set; } //FK
        public Book Book { get; set; } //Property for Book
        public int AuthorId { get; set; } //FK
        public Author Author { get; set; } //Propery for Author
    }
}

