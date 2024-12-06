using Projekt.Db.Models;
using Microsoft.EntityFrameworkCore;
 
public class UpdateData
{
    public static void BookAuthorRelation()
    {
        try
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    System.Console.WriteLine("Enter the title of the book");
                    string title = Console.ReadLine().ToLower();
                    
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        throw new ArgumentException("Title cannot be empty");
                    }
                    var book = context.Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
                    
                    if (book == null)
                    {
                        Console.WriteLine($"No book found with the title '{title}'");
                        return;
                    }
                    System.Console.WriteLine("Enter the first name for the author");
                    string firstName = Console.ReadLine().ToLower();
                   
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        throw new ArgumentException("First name cannot be empty");
                    }
                    Console.WriteLine("Enter the last name of the author");
                    string lastName = Console.ReadLine().ToLower();
                    
                    if (string.IsNullOrWhiteSpace(lastName))
                    {
                        throw new ArgumentException("Last name cannot be empty");
                    }
                    var author = context.Authors
                    .FirstOrDefault(a => a.FirstName.ToLower() == firstName.ToLower() && a.LastName.ToLower() == lastName.ToLower());
                    
                    if (book == null)
                    {
                        Console.WriteLine($"No author found with the name '{firstName}' '{lastName}'");
                        return;
                    }
                    var bookAuthor = new Authorbook
                    {
                        Book = book,
                        Author = author,
                        BookId = book.Id,
                        AuthorId = author.Id
                    };
 
                    context.Authorbooks.Add(bookAuthor);
                    context.SaveChanges();
 
                    Console.WriteLine($"Book with ID {book.Id} and author with ID {author.Id} have been linked.");
                    transaction.Commit();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
public static void BookLoan()
    {
        try
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter the first and last name of the borrower:");
                string borrowerName = Console.ReadLine().ToLower();
 
 
                if (string.IsNullOrWhiteSpace(borrowerName))
                {
                    throw new ArgumentException("The borrower name cannot be empty");
                }
                Console.WriteLine("Enter the name of the book to borrow:");
                string bookName = Console.ReadLine().ToLower();
 
 
                if (string.IsNullOrWhiteSpace(bookName))
                {
                    throw new ArgumentException("Book title cannot be empty");
                }
                Console.WriteLine("Enter the loan start date (YYYY-MM-DD):");
                
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime loanDate))
                {
                    throw new ArgumentException("Invalid format. Please use YYYY-MM-DD");
                }
                Console.WriteLine("Enter the loan return date (YYYY-MM-DD):");
                
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime returnDate))
                {
                    throw new ArgumentException("Invalid format. Please use YYYY-MM-DD");
                }
                var book = context.Books
                .FirstOrDefault(b => b.Title.ToLower() == bookName.ToLower());
 
                if (book == null)
                {
                    Console.WriteLine($"No book found with the title '{bookName}");
                    return;
                }
 
                var loan = new Loan
                {
                    BorrowerName = borrowerName,
                    BookId = book.Id,
                    LoanDate = loanDate,
                    ReturnDate = returnDate
                };
 
                context.Loans.Add(loan);
                context.SaveChanges();
 
                Console.WriteLine($"Book '{book.Title}' has been loaned to {borrowerName} from {loanDate.ToShortDateString()} to {returnDate.ToShortDateString()}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}