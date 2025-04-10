using System;
using System.IO;

// Declare the Struct
struct MenuItem
{
    public int ID;
    public string Item;
    public int Price;
    public int Stock;

    // Constructor
    public MenuItem(int id, string item, int price, int stock)
    {
        ID = id;
        Item = item;
        Price = price;
        Stock = stock;
    }
}

class KfcAdmin
{
    // Declare the filepath of our Menu
    private string filePath = "menu.txt";

    public void ApplicationMenu()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("Admin KFC Application!");
        Console.WriteLine("==========================");
        Console.WriteLine("1. Show Menu");
        Console.WriteLine("2. Add Menu");
        Console.WriteLine("3. Update Menu");
        Console.WriteLine("4. Delete Menu");
        Console.WriteLine("0. EXIT");
        Console.WriteLine("==========================");
    }

    public void ShowMenu()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not Found!");
        }
        else
        {
            Console.WriteLine("KFC Menu");
            Console.WriteLine("==========================");
            Console.WriteLine("ID\tITEM\t\tPRICE\tSTOCK");
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] data = line.Split(',');
                int id = int.Parse(data[0]);
                string item = data[1];
                int price = int.Parse(data[2]);
                int stock = int.Parse(data[3]);
                Console.WriteLine($"{id}\t{item}\t\t{price}\t{stock}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public void AddMenu()
    {
        Console.WriteLine("Adding a new Item");
        Console.WriteLine("==========================");
        Console.Write("Id\t: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Item\t: ");
        string item = Console.ReadLine();
        Console.Write("Price\t: ");
        int price = int.Parse(Console.ReadLine());
        Console.Write("Stock\t: ");
        int stock = int.Parse(Console.ReadLine());

        // Using StreamWriter to write the item to the menu.txt
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine($"{id},{item},{price},{stock}");
        }
        Console.WriteLine("An Item was successfully added!");
    }

    public void UpdateMenu()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not Found!");
            return;
        }

        Console.WriteLine("Updating Item in Menu");
        Console.WriteLine("==========================");
        Console.Write("Enter the ID of Menu: ");
        int idToUpdate = int.Parse(Console.ReadLine());

        string[] lines = File.ReadAllLines(filePath);
        bool found = false;

        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                int id = int.Parse(data[0]);
                if (id == idToUpdate)
                {
                    Console.WriteLine("Input the New Data");
                    Console.Write("Item\t: ");
                    string newItem = Console.ReadLine();
                    Console.Write("Price\t: ");
                    int newPrice = int.Parse(Console.ReadLine());
                    Console.Write("Stock\t: ");
                    int newStock = int.Parse(Console.ReadLine());
                    sw.WriteLine($"{id},{newItem},{newPrice},{newStock}");
                    found = true;
                }
                else
                {
                    sw.WriteLine(line);
                }
            }
        }

        if (found)
            Console.WriteLine("Item was successfully updated!");
        else
            Console.WriteLine("Item not Found!");
    }

    public void DeleteMenu()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not Found!");
            return;
        }

        Console.WriteLine("Deleting Item in Menu");
        Console.WriteLine("==========================");
        Console.Write("Enter the ID of Menu: ");
        int idToDelete = int.Parse(Console.ReadLine());

        string[] lines = File.ReadAllLines(filePath);
        bool found = false;

        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                int id = int.Parse(data[0]);
                if (id != idToDelete)
                {
                    sw.WriteLine(line);
                }
                else
                {
                    found = true;
                }
            }
        }

        if (found)
            Console.WriteLine("Item was successfully deleted!");
        else
            Console.WriteLine("Item not Found!");
    }
}

class Program
{
    static void Main()
    {
        KfcAdmin kfc = new KfcAdmin();
        int chosen;
        char choice;

        while (true)
        {
            Console.Clear();
            kfc.ApplicationMenu();
            Console.Write("Enter your Application number: ");
            chosen = int.Parse(Console.ReadLine());

            switch (chosen)
            {
                case 1:
                    kfc.ShowMenu();
                    break;
                case 2:
                    do
                    {
                        kfc.AddMenu();
                        Console.Write("Do you want to add another item? (y/n): ");
                        choice = Console.ReadLine()[0];
                    } while (choice == 'y' || choice == 'Y');
                    break;
                case 3:
                    kfc.UpdateMenu();
                    break;
                case 4:
                    kfc.DeleteMenu();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("The application number is not valid!");
                    break;
            }
        }
    }
}