using System;
using System.Collections.Generic;

namespace Projekt.Db.Models
{
    public class Author 
    {
        public int Id { get; set; } //PK
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public DateTime DateOfBirth { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; } //Koppling --> relation till authorbooks
    }
}