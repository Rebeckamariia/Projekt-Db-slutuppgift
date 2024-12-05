using Microsoft.EntityFrameworkCore;
using Projekt.Db.Models;

public class DeleteData
{
    public static void DeleteAuthor()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                System.Console.WriteLine("Enter the first name of the author you want to delete");
                string firstName = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    throw new ArgumentException("The first name cannot be empty");
                }
                System.Console.WriteLine("Enter the last name of the author you want to delete");
                string lastName = Console.ReadLine()?.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    throw new ArgumentException("The last name cannot be empty");
            }
            var author = context.Authors
            .FirstOrDefault(a => a.FirstName.ToLower() == firstName && a.LastName.ToLower() == lastName);
           
            if (author == null)
            {
                System.Console.WriteLine($"Invalid format. Try again please!");
            }
            Console.WriteLine($"Author found: {author.FirstName} {author.LastName}. Do you want to delete this author? Y/N");
                string confirmation = Console.ReadLine()?.ToLower();
 
                if (confirmation == "Y")
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                    Console.WriteLine($"Author {author.FirstName} {author.LastName} has been deleted.");
                }
                else if (confirmation == "N")
                {
                    Console.WriteLine("Deletion canceled.");
                }
                else
                {
                    Console.WriteLine("Deletion canceled, answer: Y/N");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    public static void DeleteBook()
        {
        using (var context = new AppDbContext())
        {
            try
            {
                System.Console.WriteLine("Enter the title of the book you want to delete");
                string title = Console.ReadLine()?.Trim().ToLower();
                
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Book title cannot be empty");
            }
            var book = context.Books.FirstOrDefault(b => b.Title.ToLower() == title);
 
                if (book == null)
                {
                    Console.WriteLine($"Invalid format. Try again please");
                    return;
                }
                
                Console.WriteLine($"Book found: {book.Title}. Do you want to delete this author? Y/N");
                string confirmation = Console.ReadLine()?.ToLower();

                if (confirmation == "Y")
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    Console.WriteLine($"Book {book.Title} has been deleted.");
                }
                else if (confirmation == "N")
                {
                    Console.WriteLine("Deletion canceled.");
                }
                else
                {
                    Console.WriteLine("Deletion canceled, answer: Y/N");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
 
 
    public static void DeleteBookloan()
    {
        using (var context = new AppDbContext())
        {
 
        }
    }
}

//Mallen är klar --> lägg till kod 
//1 & 2 klar med kod 
