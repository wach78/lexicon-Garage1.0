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

                case MenuChoice.PopulateGarage:
                    HandlePopulateGarage();
                    break;

                case MenuChoice.ListParkedVehicles:
                    HandleListAllVehicles();
                    break;

                case MenuChoice.ListVehicleTypes:
                    HandleListVehiclesTypes();
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

    private static void HandlePopulateGarage()
    {
        Garage? currentGarage = GetGarage();

        if (currentGarage is null)
        {
            return;
        }

        int addedVehicles = currentGarage.Populate();

        Console.WriteLine($"{addedVehicles} vehicles were added to the garage.");
    }

    private static void HandleListAllVehicles()
    {
        Garage? currentGarage = GetGarage();

        if (currentGarage is null)
        {
            return;
        }

        if (!GarageHasVehicles(currentGarage))
        {
            return;
        }

        Vehicle[] vehicles = currentGarage.GetParkedVehicles();

        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    private static void HandleListVehiclesTypes()
    {
        Garage? currentGarage = GetGarage();

        if (currentGarage is null)
        {
            return;
        }

        if (!GarageHasVehicles(currentGarage))
        {
            return;
        }

        var vehicleTypeCounts = currentGarage.GetParkedVehicleTypeCounts();

        foreach (KeyValuePair<string, int> vehicleTypeCount in vehicleTypeCounts)
        {
            Console.WriteLine($"{vehicleTypeCount.Key}: {vehicleTypeCount.Value}");
        }

    }

    private static Garage? GetGarage()
    {
        if (garage is null)
        {
            Console.WriteLine("You must create a garage first.");
            return null;
        }

        return garage;
    }

    private static bool GarageHasVehicles(Garage? currentGarage)
    {
        if (currentGarage is null)
        {
            Console.WriteLine("You must create a garage first.");
            return false;
        }

        if (currentGarage.IsEmpty)
        {
            Console.WriteLine("The garage is empty.");
            return false;
        }

        return true;
    }

}
