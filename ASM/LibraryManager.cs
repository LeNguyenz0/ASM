using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM
{
    public class LibraryManager
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            if (book != null)
            {
                if (BookExists(book.ID))
                {
                    Console.WriteLine($"Book with ID '{book.ID}' already exists. Cannot add the book.");
                }
                else
                {
                    books.Add(book);
                    Console.WriteLine("Book added successfully.");
                }
            }
            else
            {
                Console.WriteLine("Invalid book. Cannot add null book.");
            }
        }

        public void ShowAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                Console.WriteLine("All Books:");
                foreach (var book in books)
                {
                    book.Output();
                    Console.WriteLine();
                }
            }
        }

        public void EditBook(string ID, Book newBook)
        {
            var existingBook = GetBookByID(ID);
            if (existingBook != null)
            {
                int index = books.IndexOf(existingBook);
                books[index] = newBook;
                Console.WriteLine("Book edited successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void DeleteBook(string ID)
        {
            var bookToRemove = GetBookByID(ID);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void FindBookById(string id)
        {
            var book = GetBookByID(id);
            if (book != null)
            {
                Console.WriteLine($"Book with ID '{id}':");
                book.Output();
            }
            else
            {
                Console.WriteLine($"No book found with ID '{id}'.");
            }
        }

        public void FindBookByTitle(string title)
        {
            var foundBooks = books
                .Where(b => b.Title != null &&
                            b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0);

            PrintSearchResults(foundBooks, $"Books with title '{title}':");
        }

        public void SearchBooksByAuthor(string author)
        {
            var booksByAuthor = books
                .Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                .ToList();

            PrintSearchResults(booksByAuthor, $"Books by author '{author}':");
        }

        private bool BookExists(string id)
        {
            return books.Any(existingBook => existingBook.ID.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        private Book GetBookByID(string id)
        {
            return books.FirstOrDefault(b => b.ID == id);
        }

        private void PrintSearchResults(IEnumerable<Book> searchResults, string message)
        {
            if (searchResults.Any())
            {
                Console.WriteLine(message);
                searchResults.ToList().ForEach(book => book.Output());
            }
            else
            {
                Console.WriteLine($"No books found. {message}");
            }
        }
    }
}
