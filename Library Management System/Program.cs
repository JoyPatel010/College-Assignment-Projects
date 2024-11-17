using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Joy
{
    internal class Program
    {
        // Define the maximum number of books that can be stored
        const int MaxBooks = 100;

        static Book[] books = new Book[MaxBooks]; //books array

        // Arrays to store book details
        static string[] titles = new string[MaxBooks];
        static string[] authors = new string[MaxBooks];
        static string[] isbns = new string[MaxBooks];
        static decimal[] prices = new decimal[MaxBooks];
        static string[] categories = new string[MaxBooks];

        // Counter to keep track of the number of books
        static int bookCount = 0;
        
        //Enum Called Book Category
        enum BookCategory
        {
            Fiction = 1,
            NoneFiction,
            Science,
            History,
            Biography,
            Technology
        }

        // Define struct for Book
        struct Book
        {
            public String Title;
            public String Author;
            public String ISBN;
            public decimal Price;
            public BookCategory Category;
        }

        static void Main(string[] args)
        {
            CreateBookRecords();
            LoadFromFile(); // Load books from file on startup
            while (true) 
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Welcome to Library Management System ");
				Console.Write("------------------------------------");
				Console.WriteLine("\n1 : Add Book");
                Console.WriteLine("2 : Display All Books");
                Console.WriteLine("3 : Search Book by ISBN number");
                Console.WriteLine("4 : Remove Book by ISBN number");
                Console.WriteLine("5 : Save Books to file");
                Console.WriteLine("6 : Exit");

                // ask user to select an option
                Console.Write("Enter your choice here : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        DisplayBooks();
                        break;
                    case 3:
                        SearchBook("Enter a ISBN number to search Book : ");
                        break;
                    case 4:
                        RemoveBook("Enter a ISBN number to Remove all data of Book : ");
                        break;
                    case 5:
                        SaveToFile();
                        break;
                    case 6:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("You chose wrong option");
                        break;


                }
            }

            Console.ReadLine();
        }
        // Method to add a new book
        static void AddBook()
        {
            Book books;

            if(bookCount >= MaxBooks) // check the libraray if it is full
            {
                Console.WriteLine("Sorry...Book Library is Full now so you can not store book.");
                return;
            }

            //ask user to get book details
            Console.Write("Enter a book title : ");
            String bookTitle = Console.ReadLine();
            books.Title = bookTitle;

            Console.Write("Enter a Author Name : ");
            String author = Console.ReadLine();
            books.Author = author;

            Console.Write("Enter ISBN number : ");
            String isbn = Console.ReadLine();
            books.ISBN = isbn;

            Console.Write("Enter a book Price : ");
            decimal price = decimal.Parse(Console.ReadLine());
            if (price < 0) // check if user entered unvalid price
            {
                Console.WriteLine("Please...Enter valid Price.");
                return;
            }
            else
            {
                Console.WriteLine("Price entered : " +  price);
            }
            books.Price = price;

            Console.WriteLine("Choose a one Category from below...");
            foreach (BookCategory cat in Enum.GetValues(typeof(BookCategory))) // print all values of enum
            {
                Console.Write((int)cat + "." + cat + " ");
            }
            Console.WriteLine("Enter a one category : ");
            int categoryNum = Convert.ToInt32(Console.ReadLine()); 
            books.Category = (BookCategory)categoryNum; // assign categoryNum variable to book's category property

            // stored new details of book in array
            titles[bookCount] = bookTitle;   //store new book values
            authors[bookCount] = author;
            prices[bookCount] = price;
            isbns[bookCount] = isbn;
            categories[bookCount] = books.Category.ToString();

            bookCount++;  //increment the book count

            Console.WriteLine("You Entered New Book Successfully");

        }

        // Method to display all books
        static void DisplayBooks()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Sr. No           Title                    Authors                 ISBN        Prices     Categories");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
           
            // loop go through all books and then display all them
            for (int i = 0; i < bookCount; i++)
            {
                Console.WriteLine($"{i+1,-10}{titles[i],-30} {authors[i],-20} {isbns[i],-15} ${prices[i], -10:F2} {categories[i], -15}");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Total Books : " + bookCount); // show total number of books
        }
        // Method to search for a book by ISBN
        static void SearchBook(string isbn)
        {
            Console.Write(isbn);
            String isbnNum = Console.ReadLine();    

            for(int i = 0; i < bookCount; i++)    // loop help to go through each book isbn number
            {
                if (isbns[i] == isbnNum) // compare the ISBN number of user with already stored books
                {
                    Console.WriteLine("You Found your book Successgully by entering ISBN number");
                    Console.WriteLine("Book Name:" + titles[i] + " || " + "Author Name:" + authors[i] + " || " + "Price:" + prices[i] + " || " + "Category:" + categories[i]);
                    return;

                }
               
            }
			Console.WriteLine("Book is not found because You entered wrong ISBN number...");  

		}
        // Method to remove a book by ISBN
        static void RemoveBook(string isbn)
        {
			Console.Write(isbn); 
			String isbnNum = Console.ReadLine(); 
			
            bool found = false;

			// loop help to go through all books and find match isbn number of book
			for (int i = 0; i < bookCount; i++)
			{
				if (isbns[i] == isbnNum)  // compare a book ISBN number from Array with user entered ISBN number
				{
					// Slide each book’s details one step back to “removing” the found book
					for (int j = i; j < bookCount - 1; j++)
					{
						books[j] = books[j + 1];
					}

					bookCount--;  // decrease the count of book number
					Console.WriteLine("You removed the book successfully.");
					found = true;
					break;
				}
			}

            //if book is not found then it prints that Sorry Book is not found 
			if (!found)
			{
				Console.WriteLine("Sorry...Book is not found.");
			}
		}
        //Method to exit from this Program
        static void Exit()
        {
            Environment.Exit(0);
        }
        // Method to save books to file
        static void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter("books.txt"))
            {
                for (int i = 0; i < bookCount; i++)
                {
                    writer.WriteLine($"{titles[i]},{authors[i]},{isbns[i]},{prices[i]},{categories[i]}");
                }
            }
            Console.WriteLine("Books saved to file.");

            DisplayBooks();
        }
        static void CreateBookRecords()
        {
            // File path for the books file
            string filePath = "books.txt";
            //Console.WriteLine("File Created at : " + Directory.GetCurrentDirectory()+"\\"+filePath);
            // Check if the file already exists and delete it
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Predefined book records
            string[] predefinedBooks = new string[10]
            {
             "The Great Gatsby,F. Scott Fitzgerald,9780743273565,10.99,Fiction",
             "Sapiens,Yuval Noah Harari,9780062316097,15.50,NonFiction",
             "A Brief History of Time,Stephen Hawking,9780553380163,12.95,Science",
             "The Diary of a Young Girl,Anne Frank,9780553296983,7.95,History",
             "Steve Jobs,Walter Isaacson,9781451648539,14.99,Biography",
             "The Innovators,Walter Isaacson,9781476708706,16.99,Technology",
             "1984,George Orwell,9780451524935,9.99,Fiction",
             "Homo Deus,Yuval Noah Harari,9780062464316,17.99,NonFiction",
             "Cosmos,Carl Sagan,9780345539434,13.50,Science",
             "The Wright Brothers,David McCullough,9781476728759,11.99,History"
            };

            // Saving predefined books to file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var book in predefinedBooks)
                {
                    writer.WriteLine(book);
                }
            }
        }

        // Method to load books from file
        static void LoadFromFile()
        {
            if (File.Exists("books.txt"))
            {
                using (StreamReader reader = new StreamReader("books.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        titles[bookCount] = parts[0];
                        authors[bookCount] = parts[1];
                        isbns[bookCount] = parts[2];
                        prices[bookCount] = decimal.Parse(parts[3]);
                        categories[bookCount] = parts[4];
                        bookCount++;
                    }
                }
                Console.WriteLine("Sample Book Records has been created and loaded from file.");
            }
            else
            {
                Console.WriteLine("No saved books found.");
            }
        }

        
    }
}
