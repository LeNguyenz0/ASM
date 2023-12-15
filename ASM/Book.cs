using System;

namespace ASM
{
    public class Book
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Cate { get; set; }

        public Book(string id, string title, double price, string author, DateTime date, string description, string cate)
        {
            ID = id;
            Title = title;
            Price = price;
            Author = author;
            Date = date;
            Description = description;
            Cate = cate;
        }

        public virtual void Input()
        {
            Console.Write("ID: ");
            ID = Console.ReadLine();

            Console.Write("Title: ");
            Title = Console.ReadLine();

            Console.Write("Author: ");
            Author = Console.ReadLine();

            bool isValidPrice = false;
            do
            {
                Console.Write("Price: ");
                if (double.TryParse(Console.ReadLine(), out double price) && price >= 0)
                {
                    Price = price;
                    isValidPrice = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Price must be a non-negative number.");
                }
            } while (!isValidPrice);

            Console.Write("Date (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Date = date;
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }

            Console.Write("Description: ");
            Description = Console.ReadLine();

            Console.Write("Category: ");
            Cate = Console.ReadLine();
        }

        public virtual void Output()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Date: {Date:yyyy-MM-dd}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Category: {Cate}");
        }
    }
}