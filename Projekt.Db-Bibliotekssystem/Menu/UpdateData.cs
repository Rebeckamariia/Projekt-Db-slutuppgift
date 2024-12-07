using Projekt.Db.Models;
using Microsoft.EntityFrameworkCore;
 
public class UpdateData
{
public static void BookAuthorRelation()
{
   using (var context = new AppDbContext())
        {
            try
            {
                Console.WriteLine("Enter the title of the current book:");
                string bookTitle = Console.ReadLine()?.ToLower().Trim();
                if (string.IsNullOrWhiteSpace(bookTitle))
                {
                    throw new ArgumentException("Book title cannot be empty.");
                }
 
                Console.WriteLine("Enter the first name of the current author:");
                string authorFirstName = Console.ReadLine()?.ToLower().Trim();
                if (string.IsNullOrWhiteSpace(authorFirstName))
                {
                    throw new ArgumentException("Author's first name cannot be empty.");
                }
 
                Console.WriteLine("Enter the last name of the current author:");
                string authorLastName = Console.ReadLine()?.ToLower().Trim();
                if (string.IsNullOrWhiteSpace(authorLastName))
                {
                    throw new ArgumentException("Author's last name cannot be empty.");
                }
                var book = context.Books.FirstOrDefault(b => b.Title.ToLower() == bookTitle);
                var author = context.Authors.FirstOrDefault(a =>
                    a.FirstName.ToLower() == authorFirstName && a.LastName.ToLower() == authorLastName);
 
                if (book == null)
                {
                    Console.WriteLine($"The book '{bookTitle}' does not exist in the database.");
                    return;
                }
 
                if (author == null)
                {
                    Console.WriteLine($"The author '{authorFirstName} {authorLastName}' does not exist in the database.");
                    return;
                }
 
                var bookAuthorRelation = context.AuthorBooks
                    .FirstOrDefault(ba => ba.BookId == book.Id && ba.AuthorId == author.Id);
 
                if (bookAuthorRelation == null)
                {
                    Console.WriteLine($"No relation found between the book '{book.Title}' and the author '{author.FirstName} {author.LastName}'.");
                    return;
                }
 
                Console.WriteLine("Current Book-Author Relation Details:");
                Console.WriteLine($"Book: {book.Title}, Author: {author.FirstName} {author.LastName}");
 
                Console.WriteLine("Enter the new title for the book (or leave blank to keep the current title)");
                string newBookTitle = Console.ReadLine()?.ToLower().Trim();
                if (!string.IsNullOrWhiteSpace(newBookTitle))
                {
                    book.Title = newBookTitle;
                }
 
                Console.WriteLine("Enter the new first name for the author (or leave blank to keep the current name)");
                string newAuthorFirstName = Console.ReadLine()?.ToLower().Trim();
                if (!string.IsNullOrWhiteSpace(newAuthorFirstName))
                {
                    author.FirstName = newAuthorFirstName;
                }
 
                Console.WriteLine("Enter the new last name for the author (or leave blank to keep the current name)");
                string newAuthorLastName = Console.ReadLine()?.ToLower().Trim();
                if (!string.IsNullOrWhiteSpace(newAuthorLastName))
                {
                    author.LastName = newAuthorLastName;
                }
 
                context.SaveChanges();
                Console.WriteLine($"The relation between the book '{book.Title}' and the author '{author.FirstName} {author.LastName}' has been updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
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

            Console.WriteLine("Current Loan Details:");
            Console.WriteLine($"Loan ID: {loan.Id}, Book: {loan.Book.Title}, Borrower: {loan.BorrowerName}\n Loan Date: {loan.LoanDate.ToShortDateString()}, Return Date: {loan.ReturnDate}");

            Console.WriteLine("Enter the new borrower's full name (or leave blank to keep the current)");
            string newBorrowerName = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(newBorrowerName))
            {
                loan.BorrowerName = newBorrowerName;
            }

            Console.WriteLine("Enter the new loan start date (YYYY-MM-DD) (or leave blank to keep the current)");
            string newLoanDateInput = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(newLoanDateInput) && DateTime.TryParse(newLoanDateInput, out DateTime newLoanDate))
            {
                loan.LoanDate = newLoanDate;
            }

            Console.WriteLine("Enter the new return date (YYYY-MM-DD) (or leave blank to keep the current)");
            string newReturnDateInput = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(newReturnDateInput) && DateTime.TryParse(newReturnDateInput, out DateTime newReturnDate))
            {
                loan.ReturnDate = newReturnDate;
            }

            context.SaveChanges();
            Console.WriteLine("Loan updated successfully :)");
        }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}