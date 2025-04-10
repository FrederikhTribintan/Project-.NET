using System;
using System.IO;

// Struct untuk menyimpan data motor
struct Motor
{
    public int ID;
    public string Model;
    public int PricePerDay; // In case it's needed for rental
    public int Availability; // In case it's needed for rental
    public decimal SellingPrice; // Added for selling price

    // Constructor untuk inisialisasi data motor
    public Motor(int id, string model, decimal sellingPrice, int availability)
    {
        ID = id;
        Model = model;
        SellingPrice = sellingPrice;
        Availability = availability;
        PricePerDay = 0; // Default to 0 for selling
    }
}

class RentalAdmin
{
    // Filepath untuk menyimpan data motor
    public string rentalFilePath = "rentalmotor.txt"; // Changed to public
    public string sellFilePath = "jualmotor.txt"; // Changed to public

    public void ApplicationMenu()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("Motor Application");
        Console.WriteLine("==========================");
        Console.WriteLine("1. Rental Motor");
        Console.WriteLine("2. Jual Motor");
        Console.WriteLine("0. EXIT");
        Console.WriteLine("==========================");
    }

    public void RentalMenu()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("Rental Motor Menu");
        Console.WriteLine("==========================");
        Console.WriteLine("1. Show Motor List");
        Console.WriteLine("2. Add New Motor");
        Console.WriteLine("3. Update Motor Info");
        Console.WriteLine("4. Delete Motor");
        Console.WriteLine("0. Back to Main Menu");
        Console.WriteLine("==========================");
    }

    public void ShowMotorList(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not Found!");
        }
        else
        {
            Console.WriteLine("Motor List");
            Console.WriteLine("==========================");
            Console.WriteLine("ID\tMODEL\t\tPRICE\t\tAVAILABLE");
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] data = line.Split(',');
                int id = int.Parse(data[0]);
                string model = data[1];
                decimal price = decimal.Parse(data[2]);
                int available = int.Parse(data[3]);
                Console.WriteLine($"{id}\t{model}\t\t{price}\t\t{available}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public void AddMotor(string filePath, bool isRental = false)
    {
        Console.WriteLine(isRental ? "Adding a New Rental Motor" : "Adding a New Selling Motor");
        Console.WriteLine("==========================");
        Console.Write("ID\t: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Model\t: ");
        string model = Console.ReadLine();
        decimal price;

        if (isRental)
        {
            Console.Write("Price/Day\t: ");
            price = decimal.Parse(Console.ReadLine());
        }
        else
        {
            Console.Write("Selling Price\t: ");
            price = decimal.Parse(Console.ReadLine());
        }

        Console.Write("Availability\t: ");
        int availability = int.Parse(Console.ReadLine());

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine($"{id},{model},{price},{availability}");
        }
        Console.WriteLine("A new motor was successfully added!");
    }

    public void UpdateMotor(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not Found!");
            return;
        }

        Console.WriteLine("Updating Motor Info");
        Console.WriteLine("==========================");
        Console.Write("Enter the ID of the Motor: ");
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
                    Console.WriteLine("Enter the New Data");
                    Console.Write("Model\t: ");
                    string newModel = Console.ReadLine();
                    Console.Write("New Price\t: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Availability\t: ");
                    int newAvailability = int.Parse(Console.ReadLine());
                    sw.WriteLine($"{id},{newModel},{newPrice},{newAvailability}");
                    found = true;
                }
                else
                {
                    sw.WriteLine(line);
                }
            }
        }

        if (found)
            Console.WriteLine("Motor was successfully updated!");
        else
            Console.WriteLine("Motor not Found!");
    }

    public void DeleteMotor(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not Found!");
            return;
        }

        Console.WriteLine("Deleting Motor");
        Console.WriteLine("==========================");
        Console.Write("Enter the ID of the Motor: ");
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
            Console.WriteLine("Motor was successfully deleted!");
        else
            Console.WriteLine("Motor not Found!");
    }
}

class Program
{
    static void Main()
    {
        RentalAdmin rental = new RentalAdmin();
        int chosen;
        char choice;

        while (true)
        {
            Console.Clear();
            rental.ApplicationMenu();
            Console.Write("Enter your Application number: ");
            chosen = int.Parse(Console.ReadLine());

            switch (chosen)
            {
                case 1: // Rental Motor
                    int rentalChoice;
                    do
                    {
                        Console.Clear();
                        rental.RentalMenu();
                        Console.Write("Enter your choice: ");
                        rentalChoice = int.Parse(Console.ReadLine());

                        switch (rentalChoice)
                        {
                            case 1:
                                rental.ShowMotorList(rental.rentalFilePath);
                                break;
                            case 2:
                                do
                                {
                                    rental.AddMotor(rental.rentalFilePath, true);
                                    Console.Write("Do you want to add another motor? (y/n): ");
                                    choice = Console.ReadLine()[0];
                                } while (choice == 'y' || choice == 'Y');
                                break;
                            case 3:
                                rental.UpdateMotor(rental.rentalFilePath);
                                break;
                            case 4:
                                rental.DeleteMotor(rental.rentalFilePath);
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("The application number is not valid!");
                                break;
                        }
                    } while (rentalChoice != 0);
                    break;

                case 2: // Jual Motor
                    int sellChoice;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("==========================");
                        Console.WriteLine("Jual Motor Menu");
                        Console.WriteLine("==========================");
                        Console.WriteLine("1. List Motor Yg Dijual");
                        Console.WriteLine("2. Add Motor");
                        Console.WriteLine("3. Update Info Motor");
                        Console.WriteLine("4. Delete Motor");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.WriteLine("==========================");
                        Console.Write("Enter your choice: ");
                        sellChoice = int.Parse(Console.ReadLine());

                        switch (sellChoice)
                        {
                            case 1:
                                rental.ShowMotorList(rental.sellFilePath);
                                break;
                            case 2:
                                do
                                {
                                    rental.AddMotor(rental.sellFilePath, false);
                                    Console.Write("Do you want to add another motor? (y/n): ");
                                    choice = Console.ReadLine()[0];
                                } while (choice == 'y' || choice == 'Y');
                                break;
                            case 3:
                                rental.UpdateMotor(rental.sellFilePath);
                                break;
                            case 4:
                                rental.DeleteMotor(rental.sellFilePath);
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine("The application number is not valid!");
                                break;
                        }
                    } while (sellChoice != 0);
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
