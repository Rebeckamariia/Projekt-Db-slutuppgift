using Projekt.Db.Models;
using Microsoft.EntityFrameworkCore;

public class MenuData
{
    public static void HandleData()
    {
        bool DataHandle = true;
        while (DataHandle)
        {
            System.Console.WriteLine("What data do you want to add?");
            System.Console.WriteLine("1. Add an Author");
            System.Console.WriteLine("2. Add a book");
            System.Console.WriteLine("3. Add a bookloan");
            System.Console.WriteLine("4. Go back to main menu");
            var input = Console.ReadLine();
            {
                switch (input)
                {
                    case "1":
                        {
                            AddData.CreateAuthor();
                            break;
                        }
                    case "2":
                        {
                            AddData.CreateBook();
                            break;
                        }
                    case "3":
                        {
                            AddData.CreateBookloan();
                            break;
                        }
                    case "4":
                        {
                            System.Console.WriteLine("Exiting program");
                            return;
                        }
                    default:
                        {
                            System.Console.WriteLine("OOPPPSSS... ERROR");
                            break;
                        }
                }
            }
        }
    }
    public static void HandleUpdateData()
    {
        bool DataHandle = true;
        while (DataHandle)
        {
            System.Console.WriteLine("What data do you want to update?");
            System.Console.WriteLine("1. Update Book & Author relation");
            System.Console.WriteLine("2. Update Bookloan & Borrower");
            System.Console.WriteLine("3. Go back to main menu");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    {
                        Console.Clear();
                        UpdateData.BookAuthorRelation();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        UpdateData.BookLoan();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        System.Console.WriteLine("Exiting program");
                        return;
                    }
                default:
                    Console.Clear();
                    System.Console.WriteLine("OOPPPSSS... ERROR");
                    break;
            }
        }
    }
    public static void HandleDeleteData()
    {
        bool DataHandle = true;
        while (DataHandle)
        System.Console.WriteLine("What data do you want to Delete?");
        System.Console.WriteLine("1. Delete Author");
        System.Console.WriteLine("2. Delete Book");
        System.Console.WriteLine("3. Delete bookloan");
        System.Console.WriteLine("4. Go back to main menu");
        var input = Console.ReadLine();
        {
            switch (input)
            {
                case "1":
                    {
                        Console.Clear();
                        DeleteData.DeleteAuthor();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        DeleteData.DeleteBook();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        DeleteData.DeleteBookloan();
                        break;
                    }
                case "4":
                    {
                        Console.Clear();
                        System.Console.WriteLine("Exiting program");
                        return;
                    }
                default:
                    Console.Clear();
                    System.Console.WriteLine("OOPPPSSS... ERROR");
                    break;
            }
        }
    }
    public static void HandleListData()
    {
        bool DataHandle = true;
        while (DataHandle)
        {
            System.Console.WriteLine("What data do you want to List?");
            System.Console.WriteLine("1. List books and authors");
            System.Console.WriteLine("2. List loaned books");
            System.Console.WriteLine("3. List books by one author");
            System.Console.WriteLine("4. List every author for one book");
            System.Console.WriteLine("5. Go back to main menu");
            var input = Console.ReadLine();
 
            switch (input)
            {
                case "1":
                    {
                        Console.Clear();
                        ReadData.ListBooksAndAuthors();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        ReadData.ListLoanedBooks();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        ReadData.ListBooksByAuthor();
                        break;
                    }
                case "4":
                    {
                        Console.Clear();
                        ReadData.ListAuthorsForBook();
                        break;
                    }
                case "5":
                    {
                        Console.Clear();
                        System.Console.WriteLine("Exiting program");
                        return;
                    }
                default:
                    Console.Clear();
                    System.Console.WriteLine("OOPPPSSS... ERROR");
                    break;
            }
        }
    }
}
