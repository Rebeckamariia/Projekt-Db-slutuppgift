using Microsoft.EntityFrameworkCore;
using Projekt.Db.Models;

public class ReadAndListData
{

public static void ListAuthorsAndBooks()
    {
        using (var context = new AppDbContext())
        {
            var authorsAndBook = context.Authorbooks
            .Include(ba => ba.Book)
            .Include(ba => ba.Author)
            .Select(ba => new
            {
                BookTitle = ba.Book.Title,
                AuthorName = $"{ba.Author.FirstName} {ba.Author.LastName}" 
            })
            .ToList();

            if (authorsAndBook.Any())
            {
                System.Console.WriteLine("Books and their authors:");
                foreach (var item in authorsAndBook)
                {
                    System.Console.WriteLine($"Book: {item.BookTitle}, Author: {item.AuthorName}");
                }
            }
                else 
                {
                    System.Console.WriteLine("No authors and books found");
                }
        }
    }


public static void ListLoanedBooks()
    {
        using (var context = new AppDbContext())
        {
            var loanedBooks = context.Loans
            .Include(l => l.Book)
            .Select(l => new
            {
                BookTitle = l.Book.Title,
                Borrower = $"{l.BorrowerName}",
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate
            })
            .ToList();

            if (loanedBooks.Any())
            {
                System.Console.WriteLine("Loaned Books:");
                foreach (var loan in loanedBooks)
                {
                    System.Console.WriteLine($"Book: {loan.BookTitle}, Borrower: {loan.Borrower}, Loan Date: {loan.LoanDate.ToShortDateString()}, Return Date: {loan.ReturnDate}");
                }
            }
            else
            {
                System.Console.WriteLine("No loaned books found");
            }
        }
    }


public static void ListBooksByAuthor()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter the first name of the author:");
            string firstName = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the last name of the author:");
            string lastName = Console.ReadLine().ToLower();
 
            var books = context.Authorbooks
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .Where(ba => ba.Author.FirstName.ToLower() == firstName.ToLower() && ba.Author.LastName.ToLower() == lastName.ToLower())
                .Select(ba => ba.Book.Title)
                .ToList();

            if (books.Any())
            {
                Console.WriteLine($"Books by {firstName} {lastName}:");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine($"No books found for author {firstName} {lastName}");
            }
        }
    }


public static void ListAuthorsForBook()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter the title of the book:");
            string bookTitle = Console.ReadLine().ToLower();
 
            var authors = context.Authorbooks
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .Where(ba => ba.Book.Title.ToLower() == bookTitle.ToLower())
                .Select(ba => new { ba.Author.FirstName, ba.Author.LastName })
                .ToList();
 
            if (authors.Any())
            {
                Console.WriteLine($"Authors for the book '{bookTitle}':");
                foreach (var author in authors)
                {
                    Console.WriteLine($"{author.FirstName} {author.LastName}");
                }
            }
            else
            {
                Console.WriteLine($"No authors found for the book '{bookTitle}'");
            }
        }
    }
}
