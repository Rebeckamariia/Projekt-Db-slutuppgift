using Microsoft.EntityFrameworkCore;
using Projekt.Db.Models;
using System;
using System.Linq;

public class ReadAndListData
{
public static void ListAuthors()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                var authors = context.Authors
                    .Select(a => new
                    {
                        AuthorName = $"{a.FirstName} {a.LastName}"
                    })
                    .ToList();
 
                if (authors.Any())
                {
                    Console.WriteLine("Authors:");
                    foreach (var author in authors)
                    {
                        Console.WriteLine($"Author: {author.AuthorName}");
                    }
                }
                else
                {
                    Console.WriteLine("No authors found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
 
    public static void ListBooks()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                var books = context.Books
                    .Select(b => new
                    {
                        BookTitle = b.Title
                    })
                    .ToList();
 
                if (books.Any())
                {
                    Console.WriteLine("Books:");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Book: {book.BookTitle}");
                    }
                }
                else
                {
                    Console.WriteLine("No books found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
public static void ListBooksAndAuthors()
    {
        using (var context = new AppDbContext())
        {
            try
            {

                var booksAndAuthors = context.AuthorBooks
                    .Include(ba => ba.Book)
                    .Include(ba => ba.Author)
                    .Select(ba => new
                    {
                        BookTitle = ba.Book.Title,
                        AuthorName = $"{ba.Author.FirstName} {ba.Author.LastName}"
                    })
                    .ToList();

                if (booksAndAuthors.Any())
                {
                    Console.WriteLine("Books and their authors:");
                    foreach (var item in booksAndAuthors)
                    {
                        Console.WriteLine($"Book: {item.BookTitle}, Author: {item.AuthorName}");
                    }
                }
                else
                {
                    Console.WriteLine("No books and authors found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
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
                Console.WriteLine("Loaned Books:");
                foreach (var loan in loanedBooks)
                {
                    Console.WriteLine($"Book: {loan.BookTitle}, Borrower: {loan.Borrower}, Loan Date: {loan.LoanDate.ToShortDateString()}, Return Date: {loan.ReturnDate}");
                }
            }
            else
            {
                Console.WriteLine("No loaned books found");
            }
        }
    }
public static void ListBooksByAuthor()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter the first name of the author you want to list books from:");
            string firstName = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the last name of the author you want to list books from:");
            string lastName = Console.ReadLine().ToLower();

            var books = context.AuthorBooks
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .Where(ba => ba.Author.FirstName.ToLower() == firstName.ToLower() && ba.Author.LastName.ToLower() == lastName.ToLower())
                .Select(ba => ba.Book.Title)
                .ToList();

            if (books.Any())
            {
                Console.WriteLine($"Books by '{firstName} {lastName}':");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine($"No books found for author: {firstName} {lastName}");
            }
        }
    }

public static void ListAuthorsForBook()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("Enter the title of the book you want to list the authors for:");
            string bookTitle = Console.ReadLine().ToLower();

            var authors = context.AuthorBooks
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


