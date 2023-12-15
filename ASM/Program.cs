using System;

namespace ASM
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryManager bookManager = new LibraryManager();

            while (true)
            {
                Console.Clear();
                DisplayMenu();

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    ExecuteMenuChoice(choice, bookManager);
                }
                else
                {
                    DisplayErrorMessage("Invalid input. Please enter a number.");
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║                Library Management System           ║");
            Console.WriteLine("╠════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Add a book                                      ║");
            Console.WriteLine("║ 2. Show all books                                  ║");
            Console.WriteLine("║ 3. Edit a book                                     ║");
            Console.WriteLine("║ 4. Delete a book                                   ║");
            Console.WriteLine("║ 5. Find a book by ID                               ║");
            Console.WriteLine("║ 6. Find a book by title                            ║");
            Console.WriteLine("║ 7. Find books by author                            ║");
            Console.WriteLine("║ 8. Exit                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.Write("Enter your choice: ");
        }

        static void ExecuteMenuChoice(int choice, LibraryManager bookManager)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nAdding a new book:");
                    Book newBook = new Book("", "", 0, "", DateTime.Now, "", "");
                    newBook.Input();
                    bookManager.AddBook(newBook);
                    break;

                case 2:
                    Console.WriteLine("\nShowing all books:");
                    bookManager.ShowAllBooks();
                    break;

                case 3:
                    Console.WriteLine("\nEditing a book:");
                    EditBook(bookManager);
                    break;

                case 4:
                    Console.WriteLine("\nDeleting a book:");
                    DeleteBook(bookManager);
                    break;

                case 5:
                    Console.WriteLine("\nFinding a book by ID:");
                    FindBookById(bookManager);
                    break;

                case 6:
                    Console.WriteLine("\nFinding a book by title:");
                    FindBookByTitle(bookManager);
                    break;

                case 7:
                    Console.WriteLine("\nFinding books by author:");
                    SearchBooksByAuthor(bookManager);
                    break;

                case 8:
                    Environment.Exit(0);
                    break;

                default:
                    DisplayErrorMessage("Invalid choice. Please try again.");
                    break;
            }
        }

        static void EditBook(LibraryManager bookManager)
        {
            Console.Write("Enter ID to edit: ");
            string idToEdit = Console.ReadLine();
            Book editedBook = new Book("", "", 0, "", DateTime.Now, "", "");
            editedBook.Input();
            bookManager.EditBook(idToEdit, editedBook);
        }

        static void DeleteBook(LibraryManager bookManager)
        {
            Console.Write("Enter ID to delete: ");
            string idToDelete = Console.ReadLine();
            bookManager.DeleteBook(idToDelete);
        }

        static void FindBookById(LibraryManager bookManager)
        {
            Console.Write("Enter ID to find: ");
            string idToFind = Console.ReadLine();
            bookManager.FindBookById(idToFind);
        }

        static void FindBookByTitle(LibraryManager bookManager)
        {
            Console.Write("Enter title to find: ");
            string titleToFind = Console.ReadLine();
            bookManager.FindBookByTitle(titleToFind);
        }

        static void SearchBooksByAuthor(LibraryManager bookManager)
        {
            Console.Write("Enter author to find: ");
            string authorToFind = Console.ReadLine();
            bookManager.SearchBooksByAuthor(authorToFind);
        }

        static void DisplayErrorMessage(string message)
        {
            Console.WriteLine($"\nError: {message}");
        }
    }
}
