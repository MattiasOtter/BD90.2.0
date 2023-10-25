namespace BD90;

class UI
{
    Register myRegister = new();
    Catalogue myCatalogue = new();
    public void ShowMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Registrera lån.\n2. Återlämning av media.\n3. Hitta media.\n4. Lägg till media.\n5. Visa all media.\n0. Avsluta.");
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
                        Console.WriteLine("Välj ett av valen från menyn.\nTryck på valfri knapp för att fortsätta.");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Något gick fel.\nTryck på valfri knapp för att fortsätta.");
                Console.ReadKey();
            }
        }
    }
    public void RegisterBorrowedItems()
    {
        while (true)
        {
            Register newPerson = new();
            Console.Write("Namn på lånadstagare: ");
            newPerson.PersonName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newPerson.PersonName))
            {
                Console.Write("Lånadstagare måste ha ett namn.\nNamn på lånadstagare: ");
                newPerson.PersonName = Console.ReadLine();
            }
            Console.Write($"Personnummer på {newPerson.PersonName}: ");
            newPerson.SocialSecurityNr = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newPerson.SocialSecurityNr))
            {
                Console.Write($"Lånadstagare måste ha ett personnummer.\nPersonnummer på {newPerson.PersonName}: ");
                newPerson.SocialSecurityNr = Console.ReadLine();
            }
            try
            {
                Console.Write("Produktens ID: ");
                newPerson.BorrowId = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nKvitto:\nLåntagarnummer: {newPerson.BorrowNr}\nID: {newPerson.BorrowId}\nLånadstagare: {newPerson.PersonName}\nUtlånad: {newPerson.DateBorrowed}\nÅterlämnas senast: {newPerson.ReturnDate}\n");
                myRegister.person.Add(newPerson);
                Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
                Console.ReadKey();
                break;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Använd endast siffror.\nFörsök igen.\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
    }

    public void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("1. Registrera återlämning via val av utlånare.\n2. Registrera återlämning via lånenummer.\n0. Avbryt.");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                for (int i = 0; i < myRegister.person.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: Låntagarnummer:{myRegister.person[i].BorrowNr}   ID:{myRegister.person[i].BorrowId}   Lånadstagare:{myRegister.person[i].PersonName}   Återlämnas senast:{myRegister.person[i].ReturnDate}");
                }
                try
                {
                    Console.WriteLine($"Välj återlämnare:");
                    int indexChoice = int.Parse(Console.ReadLine());
                    if (myRegister.person[indexChoice - 1].FindOutIfMediaIsLate() == true)
                    {
                        Console.WriteLine($"Förseningsavgift debiteras från ditt kort. Din media är {myRegister.person[indexChoice - 1].TimeLate} sekunder sen");
                        myRegister.person.RemoveAt(indexChoice - 1);
                    }
                    else if (myRegister.person[indexChoice - 1].FindOutIfMediaIsLate() == false)
                    {
                        Console.WriteLine($"MediaID: {myRegister.person[indexChoice - 1].BorrowId} är återlämnad av {myRegister.person[indexChoice - 1].PersonName}.");
                        myRegister.person.RemoveAt(indexChoice - 1);
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Något gick fel.\nFörsök igen.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
                Console.ReadKey();
                break;

            case 2:
                try
                {
                    Console.Write("Skriv in låntagarnummer: ");
                    int borrowNr = int.Parse(Console.ReadLine());
                    for (int i = 0; i < myRegister.person.Count; i++)
                    {
                        if (borrowNr == myRegister.person[i].BorrowNr)
                        {
                            Console.WriteLine($"MediaID: {myRegister.person[i].BorrowId} är återlämnad av {myRegister.person[i].PersonName}.");
                            myRegister.person.Remove(myRegister.person[i]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Låntagarnumret ogiltigt.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Använd endast siffror.\nFörsök igen.\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("Tryck på valfri knapp för att fortsätta.");
                Console.ReadKey();
                break;

            case 0:
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Välj ett av valen från menyn.\nTryck på valfri knapp för att fortsätta.");
                Console.ReadKey();
                break;
        }
    }
}

