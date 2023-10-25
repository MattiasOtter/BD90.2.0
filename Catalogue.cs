namespace BD90;

class Catalogue
{
    List<Book> bookList = new()
    {
        new Book {Id = 530, Author = "Björn Kurtsson", Title = "Jättarnas Undergång", YearPublished = 2015},
        new Book {Id = 258, Author = "Tabetha Ford", Title = "The Lords Name in Vain", YearPublished = 1963},
        new Book {Id = 52, Author = "Thomas Strutt", Title = "Fire in the Hole", YearPublished = 2002}
    };

    List<Magazine> magazineList = new()
    {
        new Magazine {Id = 766, Issue = 8, Title = "Teknikhistoria", YearPublished = 2010},
        new Magazine {Id = 983, Issue = 21, Title = "Semesterresor", YearPublished = 2019},
        new Magazine {Id = 246, Issue = 13, Title = "Prylar och Leksaker", YearPublished = 2008}
    };
    List<Audiobook> audiobookList = new()
    {
        new Audiobook {Id = 543, Author = "Björn Kurtsson", Title = "Jättarnas Undergång", Duration = 530, YearPublished = 2017},
        new Audiobook {Id = 222, Author = "Tilde Davidsson", Title = "Skogens Härskarinna", Duration = 700, YearPublished = 2007},
        new Audiobook {Id = 632, Author = "Hans Zimmerman", Title = "Then There Were Two", Duration = 346, YearPublished = 1944}
    };

    //Varför måste man göra på detta sättet?

    public void AddBook(Book book)
    {
        bookList.Add(book);
    }

    public void AddMagazine(Magazine magazine)
    {
        magazineList.Add(magazine);
    }

    public void AddAudiobook(Audiobook audiobook)
    {
        audiobookList.Add(audiobook);
    }

    public void ShowLibrary()
    {
        foreach (var media in bookList)
        {
            Console.WriteLine($"ID: {media.Id}   Author: {media.Author}   Title: {media.Title}   Year Published: {media.YearPublished}");
        }
        foreach (var media in magazineList)
        {
            Console.WriteLine($"ID: {media.Id}   Issue: {media.Issue}   Title: {media.Title}   Year Published: {media.YearPublished}");
        }
        foreach (var media in audiobookList)
        {
            Console.WriteLine($"ID: {media.Id}   Author: {media.Author}   Title: {media.Title}   Year Published: {media.YearPublished}    Minutes Long: {media.Duration}");
        }
    }

    public void AddToLibrary()
    {
        Console.WriteLine("What would you like to add?\n1. Book.\n2. Magazine.\n3. Audiobook.\n0. Exit.");
        int userChoice = int.Parse(Console.ReadLine());

        switch (userChoice)
        {
            case 1:
                int intId;
                int intYear;
                int intMinutes;
                Book newBook = new();
                do
                {
                    Console.Write("Book ID: ");
                    int.TryParse(Console.ReadLine(), out intId);
                }
                while (intId <= 0);
                newBook.Id = intId;
                do
                {
                    Console.Write("Book Author: ");
                    newBook.Author = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(newBook.Author));
                do
                {
                    Console.Write("Book Title: ");
                    newBook.Title = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(newBook.Title));
                do
                {
                    Console.Write("Book Publish Year: ");
                    int.TryParse(Console.ReadLine(), out intYear);
                }
                while (intYear <= 0);
                newBook.YearPublished = intYear;

                bookList.Add(newBook);
                Console.ReadKey();
                break;

            case 2:
                Magazine newMagazine = new();
                int intIssue;
                do
                {
                    Console.Write("Magazine ID: ");
                    int.TryParse(Console.ReadLine(), out intId);
                }
                while (intId <= 0);
                newMagazine.Issue = intId;
                do
                {
                    Console.Write("Magazine Issue: ");
                    int.TryParse(Console.ReadLine(), out intIssue);
                }
                while (intIssue <= 0);
                newMagazine.Id = intIssue;
                do
                {
                    Console.Write("Magazine Title: ");
                    newMagazine.Title = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(newMagazine.Title));
                do
                {
                    Console.Write("Magazine Publish Year: ");
                    int.TryParse(Console.ReadLine(), out intYear);
                }
                while (intYear <= 0);
                newMagazine.YearPublished = intYear;

                magazineList.Add(newMagazine);
                Console.ReadKey();
                break;

            case 3:
                Audiobook newAudiobook = new();
                do
                {
                    Console.Write("Audiobook ID: ");
                    int.TryParse(Console.ReadLine(), out intId);
                }
                while (intId <= 0);
                newAudiobook.Id = intId;
                do
                {
                    Console.Write("Audiobook Author: ");
                    newAudiobook.Author = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(newAudiobook.Author));
                do
                {
                    Console.Write("Audiobook Title: ");
                    newAudiobook.Title = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(newAudiobook.Title));
                do
                {
                    Console.Write("Audiobook Publish Year: ");
                    int.TryParse(Console.ReadLine(), out intYear);
                }
                while (intYear <= 0);
                newAudiobook.YearPublished = intYear;
                do
                {
                    Console.Write("Audiobook Minutes Long: ");
                    int.TryParse(Console.ReadLine(), out intMinutes);
                }
                while (intMinutes <= 0);
                newAudiobook.Duration = intMinutes;

                audiobookList.Add(newAudiobook);
                Console.ReadKey();
                break;

            case 0:
                break;

            default:
                Console.WriteLine("Something went wrong, please try again.");
                Console.ReadKey();
                break;
        }
    }

    public void SearchLibrary()
    {
        Console.WriteLine("Search for \n1. Title.\n2. Author.");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Title: ");
            string titleSearch = Console.ReadLine().ToLower();
            foreach (Book book in bookList)
            {
                if (book.Title.ToLower().Contains(titleSearch))
                {
                    Console.WriteLine($"ID: {book.Id}    Author: {book.Author}    Title: {book.Title}    Year Published: {book.YearPublished}");
                }
            }
            foreach (Magazine magazine in magazineList)
            {
                if (magazine.Title.ToLower().Contains(titleSearch))
                {
                    Console.WriteLine($"ID: {magazine.Id}    Issue: {magazine.Issue}    Title: {magazine.Title}    Year Published: {magazine.YearPublished}");
                }
            }
            foreach (Audiobook audiobook in audiobookList)
            {
                if (audiobook.Title.ToLower().Contains(titleSearch))
                {
                    Console.WriteLine($"ID: {audiobook.Id}    Author: {audiobook.Author}    Title: {audiobook.Title}    Year Published:{audiobook.YearPublished}    Minutes Long: {audiobook.Duration}");
                }
            }
            Console.ReadKey();
        }

        else if (choice == 2)
        {
            Console.Write("Author: ");
            string authorSearch = Console.ReadLine().ToLower();
            foreach (Book book in bookList)
            {
                if (book.Author.ToLower().Contains(authorSearch))
                {
                    Console.WriteLine($"ID: {book.Id}    Author: {book.Author}    Title: {book.Title}    Year Published: {book.YearPublished}");
                }
            }
            foreach (Audiobook audiobook in audiobookList)
            {
                if (audiobook.Author.ToLower().Contains(authorSearch))
                {
                    Console.WriteLine($"ID: {audiobook.Id}    Author: {audiobook.Author}    Title: {audiobook.Title}    Year Published:{audiobook.YearPublished}    Minutes Long: {audiobook.Duration}");
                }
            }
            Console.ReadKey();
        }
    }
}