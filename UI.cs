namespace BD90;

class UI
{
    Register myRegister = new();
    Catalogue myCatalogue = new();
    public void ShowMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Register Loans.\n2. Media returns.\n3. Find media.\n4. Add media.\n5. Show all media.\n0. Exit.");
    }
    public void SelectMenuChoice()
    {
        while (true)
        {
            ShowMenu();
            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterBorrowedItems();
                        break;

                    case 2:
                        RegisterReturn();
                        break;

                    case 3:
                        myCatalogue.SearchLibrary();
                        break;

                    case 4:
                        myCatalogue.AddToLibrary();
                        break;

                    case 5:
                        myCatalogue.ShowLibrary();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Make a choice from the menu.\nPress a key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.\nPress a key to continue.");
                Console.ReadKey();
            }
        }
    }
    public void RegisterBorrowedItems()
    {
        while (true)
        {
            Register newPerson = new();
            Console.Write("Borrowers name: ");
            newPerson.PersonName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newPerson.PersonName))
            {
                Console.Write("Borrower needs to have a name.\nBorrowers name: ");
                newPerson.PersonName = Console.ReadLine();
            }
            Console.Write($"{newPerson.PersonName} social security number: ");
            newPerson.SocialSecurityNr = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newPerson.SocialSecurityNr))
            {
                Console.Write($"Borrower needs to have a social security number.\n{newPerson.PersonName} social security number: ");
                newPerson.SocialSecurityNr = Console.ReadLine();
            }
            try
            {
                Console.Write("Products ID: ");
                newPerson.BorrowId = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nReceipt:\nBorrownumber: {newPerson.BorrowNr}\nID: {newPerson.BorrowId}\nBorrower: {newPerson.PersonName}\nBorrowed: {newPerson.DateBorrowed}\nLatest return: {newPerson.ReturnDate}\n");
                myRegister.person.Add(newPerson);
                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
                break;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Only numbers please.\nTry again.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
    }

    public void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("1. Register return by choosing borrower.\n2. Register return via borrownumber.\n0. Exit.");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                for (int i = 0; i < myRegister.person.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: Borrownumber:{myRegister.person[i].BorrowNr}   ID:{myRegister.person[i].BorrowId}   Borrower:{myRegister.person[i].PersonName}   Latest Return:{myRegister.person[i].ReturnDate}");
                }
                try
                {
                    Console.WriteLine($"Välj återlämnare:");
                    int indexChoice = int.Parse(Console.ReadLine());
                    if (myRegister.person[indexChoice - 1].FindOutIfMediaIsLate() == true)
                    {
                        Console.WriteLine($"Delay fee has been debited. Your media is {myRegister.person[indexChoice - 1].TimeLate} seconds late");
                        myRegister.person.RemoveAt(indexChoice - 1);
                    }
                    else if (myRegister.person[indexChoice - 1].FindOutIfMediaIsLate() == false)
                    {
                        Console.WriteLine($"MediaID: {myRegister.person[indexChoice - 1].BorrowId} is returned by {myRegister.person[indexChoice - 1].PersonName}.");
                        myRegister.person.RemoveAt(indexChoice - 1);
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something went wrong.\nPlease try again.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
                break;

            case 2:
                try
                {
                    Console.Write("Type in borrownumber: ");
                    int borrowNr = int.Parse(Console.ReadLine());
                    for (int i = 0; i < myRegister.person.Count; i++)
                    {
                        if (borrowNr == myRegister.person[i].BorrowNr)
                        {
                            Console.WriteLine($"MediaID: {myRegister.person[i].BorrowId} is returned by {myRegister.person[i].PersonName}.");
                            myRegister.person.Remove(myRegister.person[i]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Borrownumber is invalid.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Only use numbers.\nPlease try again.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
                break;

            case 0:
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choose one of the options presented.\nPress a key to continue.");
                Console.ReadKey();
                break;
        }
    }
}

