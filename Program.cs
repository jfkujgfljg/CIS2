using System;
using System.Collections.Generic;

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsBorrowed { get; set; }
}

class Library
{
    private List<Book> books = new List<Book>();
    private int bookCounter = 1;

    public void AddBook(string title)
    {
        books.Add(new Book { Id = bookCounter++, Title = title, IsBorrowed = false });
        Console.WriteLine($"Book '{title}' added to the library.");
    }

    public void RemoveBook(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Book '{book.Title}' removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Library Collection:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Status: {(book.IsBorrowed ? "Borrowed" : "Available")}");
        }
    }

    public void BorrowBook(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book != null && !book.IsBorrowed)
        {
            book.IsBorrowed = true;
            Console.WriteLine($"You borrowed '{book.Title}'.");
        }
        else
        {
            Console.WriteLine("Book is either not available or already borrowed.");
        }
    }

    public void ReturnBook(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book != null && book.IsBorrowed)
        {
            book.IsBorrowed = false;
            Console.WriteLine($"You returned '{book.Title}'.");
        }
        else
        {
            Console.WriteLine("Invalid return request.");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();
        Console.WriteLine("Welcome to the Library Management System");

        while (true)
        {
            Console.WriteLine("\n1. Add Book\n2. Remove Book\n3. Display Books\n4. Borrow Book\n5. Return Book\n6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    library.AddBook(title);
                    break;
                case "2":
                    Console.Write("Enter book ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeId))
                        library.RemoveBook(removeId);
                    else
                        Console.WriteLine("Invalid ID");
                    break;
                case "3":
                    library.DisplayBooks();
                    break;
                case "4":
                    Console.Write("Enter book ID to borrow: ");
                    if (int.TryParse(Console.ReadLine(), out int borrowId))
                        library.BorrowBook(borrowId);
                    else
                        Console.WriteLine("Invalid ID");
                    break;
                case "5":
                    Console.Write("Enter book ID to return: ");
                    if (int.TryParse(Console.ReadLine(), out int returnId))
                        library.ReturnBook(returnId);
                    else
                        Console.WriteLine("Invalid ID");
                    break;
                case "6":
                    Console.WriteLine("Exiting Library Management System. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
