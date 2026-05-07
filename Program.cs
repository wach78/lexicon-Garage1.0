using GarageV1.Enums;
using GarageV1.Moduls;
using GarageV1.UI;
using System.Runtime.CompilerServices;

internal class Program
{
    private static Garage? garage = null;

    static void Main(string[] args)
    {
        bool isRunning = true;

        


        while (isRunning)
        {
            Menu();


            MenuChoice? menuChoice = ConsoleInputReader.ReadMainMenuChoice();

            if (menuChoice is null)
            {
                Console.WriteLine("Invalid choice");
                Console.WriteLine();
                continue;
                
            }

            switch (menuChoice)
            {
                case MenuChoice.Exit:
                    isRunning = false;
                    Console.WriteLine("Exit.");
                    break;

                case MenuChoice.CreateGarage:
                    HandleCreateGarage();
                    break;


                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine();


        }

    }

    private static void Menu()
    {
        Console.Write(
            $"""
            Welcome to the main menu.
            Enter a number to choose an option.

            {(int)MenuChoice.CreateGarage} = Create garage
            {(int)MenuChoice.PopulateGarage} = Populate garage with vehicles
            {(int)MenuChoice.ListParkedVehicles} = List all parked vehicles
            {(int)MenuChoice.ListVehicleTypes} = List vehicle types and count
            {(int)MenuChoice.ParkVehicle} = Park a vehicle
            {(int)MenuChoice.RemoveVehicle} = Remove a vehicle
            {(int)MenuChoice.FindVehicleByPlateNumber} = Find vehicle by plate number
            {(int)MenuChoice.SearchVehicles} = Search vehicles
            {(int)MenuChoice.Exit} = Exit

            Your choice:
            """
        );
    }
    private static void HandleCreateGarage()
    {
        Console.Write("Enter garage capacity: ");

        int? capacity = ConsoleInputReader.ReadPositiveInt();

        if (capacity is null)
        {
            Console.WriteLine("Invalid capacity.");
            return;
        }

        garage = new Garage(capacity.Value);

        Console.WriteLine($"Garage created with {capacity} parking spaces.");
    }
    
   
}
