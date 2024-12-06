using Projekt.Db.Models;
using Microsoft.EntityFrameworkCore;
 
public class UpdateData
{
    private static string newName;

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
                    var existingRelation = context.Authorbooks
                    .FirstOrDefault(ba => ba.BookId == book.Id && ba.AuthorId == author.Id);
 
                    if (existingRelation == null)
                    {
                        Console.WriteLine($"No relation found between the book '{title}' and author '{firstName} {lastName}'");
                        return;
                    }
                    Console.WriteLine("Enter the new title of the book:");
                    string newTitle = Console.ReadLine().ToLower();
                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        book.Title = newTitle;
                    }
 
                    Console.WriteLine("Enter the new first name of the author:");
                    string newFirstName = Console.ReadLine().ToLower();
                    if (!string.IsNullOrWhiteSpace(newFirstName))
                    {
                        author.FirstName = newFirstName;
                    }
 
                    Console.WriteLine("Enter the new last name of the author:");
                    string newLastName = Console.ReadLine().ToLower();
                    if (!string.IsNullOrWhiteSpace(newLastName))
                    {
                        author.LastName = newLastName;
                    }
 
                    context.SaveChanges();
                    Console.WriteLine($"The book '{book.Title}'with ID {book.Id} and the author '{author.FirstName} {author.LastName}' with ID {author.Id} have been linked.");
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
                Console.WriteLine("Enter the ID of the loan you want to update:");
                if (!int.TryParse(Console.ReadLine(), out int loanId))
                {
                    throw new ArgumentException("Invalid loan ID");
                }
 
                var loan = context.Loans.Include(l => l.Book).FirstOrDefault(l => l.Id == loanId);
                if (loan == null)
                {
                    Console.WriteLine($"No loan found with ID {loanId}.");
                    return;
                }
                Console.WriteLine("Current loan details:");
                Console.WriteLine($"Loan ID: {loan.Id}, Book: {loan.Book.Title}, Borrower:{loan.BorrowerName}\n Loan Date: {loan.LoanDate.ToShortDateString()}, Return Date: {loan.ReturnDate}");
                string newFirstName = Console.ReadLine()?.ToLower();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    loan.BorrowerName = newName;
                }
                Console.WriteLine("Enter the new borrower's name (or leave blank to keep the current :)");
                string newLastName = Console.ReadLine()?.Trim();
    
 
                Console.WriteLine("Enter the new loan start date (YYYY-MM-DD) (or leave blank to keep the current :)");
                string newLoanDateInput = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newLoanDateInput) && DateTime.TryParse(newLoanDateInput, out DateTime newLoanDate))
                {
                    loan.LoanDate = newLoanDate;
                }
 
                Console.WriteLine("Enter the new return date (YYYY-MM-DD) (or leave blank to keep the current :)");
                string newReturnDateInput = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newReturnDateInput) && DateTime.TryParse(newReturnDateInput, out DateTime newReturnDate))
                {
                    loan.ReturnDate = newReturnDate;
                }
                context.SaveChanges();
                Console.WriteLine("Loan updated succeeded :)");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
