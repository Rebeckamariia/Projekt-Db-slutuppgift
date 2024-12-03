using Projekt.Db.Models;
using Microsoft.EntityFrameworkCore;
 
public class AddData
{
    public static void CreateAuthor()
    {
        using (var context = new AppDbContext())
        {
            try
            {
            System.Console.WriteLine("Enter the first name of the Author");
            string firstname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstname))
                {
                    throw new ArgumentException("First name cannot be clear");
                }
            Console.WriteLine("Enter the last name of the Author");
            string lastname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastname))
                {
                    throw new ArgumentException("Last name cannot be clear");
                }
            Console.WriteLine("Enter the date of birth of the Author (YYYY-MM-DD)");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateofbirth))
            {
                Console.WriteLine("Invalid format. Please use YYYY-MM-DD");
                return;
            }
            var Author = new Author
            {
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateofbirth
            };
            context.Authors.Add(Author);
            context.SaveChanges();
            Console.WriteLine($"Author {firstname} {lastname} born {dateofbirth} has been added :)");
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public static void CreateBook()
    {
        using (var context = new AppDbContext())
        {
             try
            {
            System.Console.WriteLine("Enter the Title of the book");
            string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Title cannot be clear");
                }
            Console.WriteLine("Enter the genre of the book");
            string genre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(genre))
                {
                    throw new ArgumentException("Genre cannot be clear");
                }
            Console.WriteLine("Enter the publication year of the book");
            if (!int.TryParse(Console.ReadLine(), out int publicationyear) || publicationyear < 0)
            {
                throw new ArgumentException ("Invalid format. Please use YYYY-MM-DD");
            }
             var book = new Book
            {
                Title = title,
                PublicationYear = publicationyear,
                Genre = genre,
            };
            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine($"Book with the Title {title} published in {publicationyear} with the genre {genre} has been added :)");
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    //NOOOOTTT DOONNNEEE -->
        public static void CreateBookloan()
    {
        using (var context = new AppDbContext())
        {
            
        }
    }
}