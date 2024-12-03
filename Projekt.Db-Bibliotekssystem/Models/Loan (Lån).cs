namespace Projekt.Db.Models
{
    public class Loan 
    {
        public int Id { get; set; } //PK
        public int BookId { get; set; } //FK
        public Book Book { get; set; } //Property for Book
        public string BorrowerName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; } //Kan även vara NULL-värde --> ej inlämnade böcker
    }
}
