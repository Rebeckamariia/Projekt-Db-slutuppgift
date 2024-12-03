using System;
using System.Collections.Generic;

namespace Projekt.Db.Models
{
    public class Book 
    {
        public int Id { get; set; } //PK
        public string Title { get; set; }
        public int ISBN { get; set; } //Steckkod unik --> book
        public int PublicationYear { get; set; }
        public string Genre { get; set; }
        public ICollection<Authorbook> Authorbooks { get; set; } //Koppling --> relation till authorbooks
        public ICollection<Loan> Loans { get; set; } //Koppling --> relation till loan
    }
}
