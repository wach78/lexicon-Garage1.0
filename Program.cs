using GarageV1.Enums;
using GarageV1.Moduls;
using GarageV1.UI;
using System.Collections;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static Garage? garage = null;

    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            ConsoleMenu.Menu();

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

                case MenuChoice.ParkVehicle:
                    HandleParkedVehicle();
                    break;

                case MenuChoice.RemoveVehicle:
                    HandleRemoveVehicle();
                    break;

                case MenuChoice.FindVehicleByPlateNumber:
                    HandleFindVehicleByPlateNumber();
                    break;

                case MenuChoice.SearchVehicles:
                    HandleSearchVehicle();
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine();
        }
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

        foreach (DictionaryEntry vehicleTypeCount in vehicleTypeCounts)
        {
            Console.WriteLine($"{vehicleTypeCount.Key}: {vehicleTypeCount.Value}");
        }

    }

    private static void HandleParkedVehicle()
    {
        Garage? currentGarage = GetGarage();

        if (currentGarage is null)
        {
            return;
        }

        ConsoleMenu.VehicleTypeMenu();

        VehicleTypeChoice? vehicleTypeChoice = ConsoleInputReader.ReadVehicleTypeChoice();

        if (vehicleTypeChoice is null)
        {
            Console.WriteLine("Invalid vehicle type.");
            return;
        }

        switch (vehicleTypeChoice.Value)
        {
            case VehicleTypeChoice.Back:
                return;

            case VehicleTypeChoice.Car:
                HandleCreateCar(currentGarage);
                break;

            case VehicleTypeChoice.Motorcycle:
                HandleCreateMotorcycle(currentGarage);
                break;

            case VehicleTypeChoice.Bus:
                HandleCreateBus(currentGarage);
                break;

            case VehicleTypeChoice.Boat:
                HandleCreateBoat(currentGarage);
                break;

            case VehicleTypeChoice.Airplane:
                HandleCreateAirplane(currentGarage);
                break;

            default:
                Console.WriteLine("Invalid vehicle type.");
                break;
        }

    }

    private static void HandleCreateCar(Garage currentGarage)
    {
        CommonVehicleData? commonVehicleData = ReadCommonVehicleData();

        if (commonVehicleData is null)
        {
            return;
        }

        Console.Write("Enter fuel type, Gasoline or Diesel: ");
        string? fuelTypeInput = ConsoleInputReader.ReadRequiredString();

        if (
            fuelTypeInput is null ||
            !Enum.TryParse(fuelTypeInput, true, out FuelType fuelType)
        )
        {
            Console.WriteLine("Invalid fuel type");
            return;
        }

        var car = new Car(
            commonVehicleData.NumberPlate,
            commonVehicleData.Color,
            commonVehicleData.NumberOfWheels,
            fuelType
        );

        AddVehicleResult result = currentGarage.Add(car);

        AddVehicleResultMessage(result);
    }

    private static void HandleCreateMotorcycle(Garage currentGarage)
    {
        CommonVehicleData? commonVehicleData = ReadCommonVehicleData();

        if (commonVehicleData is null)
        {
            return;
        }

        Console.Write("Enter Cylinder Volume: ");
        int? cylinderVolume = ConsoleInputReader.ReadPositiveInt();

        if (cylinderVolume is null)
        {
            Console.WriteLine("Invalid cylinderVolume.");
            return;
        }

        var motorcycle = new MotorCycle(
            commonVehicleData.NumberPlate,
            commonVehicleData.Color,
            commonVehicleData.NumberOfWheels,
            cylinderVolume.Value
         );


        AddVehicleResult result = currentGarage.Add(motorcycle);

        AddVehicleResultMessage(result);
    }

    private static void HandleCreateBus(Garage currentGarage)
    {
        CommonVehicleData? commonVehicleData = ReadCommonVehicleData();

        if (commonVehicleData is null)
        {
            return;
        }

        Console.Write("Enter Number of Seats: ");
        int? seats = ConsoleInputReader.ReadPositiveInt();


        if (seats is null)
        {
            Console.WriteLine("Invalid number of seats.");
            return;
        }

        var bus = new Bus(
            commonVehicleData.NumberPlate,
            commonVehicleData.Color,
            commonVehicleData.NumberOfWheels,
            seats.Value
        );

        AddVehicleResult result = currentGarage.Add(bus);

        AddVehicleResultMessage(result);
    }

    private static void HandleCreateBoat(Garage currentGarage)
    {
        CommonVehicleData? commonVehicleData = ReadCommonVehicleData();

        if (commonVehicleData is null)
        {
            return;
        }

        Console.Write("Enter lenght: ");
        int? length = ConsoleInputReader.ReadPositiveInt();

        if (length is null)
        {
            Console.WriteLine("Invalid number of seats.");
            return;
        }

        var boat = new Boat(
            commonVehicleData.NumberPlate,
            commonVehicleData.Color,
            commonVehicleData.NumberOfWheels,
            length.Value
        );

        AddVehicleResult result = currentGarage.Add(boat);

        AddVehicleResultMessage(result);
    }

    private static void HandleCreateAirplane(Garage currentGarage)
    {
        CommonVehicleData? commonVehicleData = ReadCommonVehicleData();

        if (commonVehicleData is null)
        {
            return;
        }

        Console.Write("Enter number of engines: ");
        int? numberOfEngines = ConsoleInputReader.ReadPositiveInt();

        if (numberOfEngines is null)
        {
            Console.WriteLine("Invalid number of engines.");
            return;
        }

        var airplane = new AirPlane(
            commonVehicleData.NumberPlate,
            commonVehicleData.Color,
            commonVehicleData.NumberOfWheels,
            numberOfEngines.Value
        );

        AddVehicleResult result = currentGarage.Add(airplane);

        AddVehicleResultMessage(result);
    }

    private static void HandleRemoveVehicle()
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

        Console.Write("Enter plate number:");
        string? platenumber = ConsoleInputReader.ReadRequiredString();

        var isDeleted = currentGarage.RemoveByPlateNumber(platenumber);

        if (isDeleted is true)
        {
            Console.WriteLine($"Vehicle removed for plate number {platenumber}");
        }
        else
        {
            Console.WriteLine($"Vehicle not found for plate number {platenumber}");
        }

    }

    private static void HandleFindVehicleByPlateNumber()
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

        Console.Write("Enter plate number:");
        string? platenumber = ConsoleInputReader.ReadRequiredString();

        var vehicle = currentGarage.FindByPlateNumber(platenumber);

        if (vehicle is null)
        {
            Console.WriteLine($"Vehicle not found for plate number {platenumber}");
        }
        else
        {
            Console.WriteLine($"Vehicle found: {vehicle}");
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

    private static CommonVehicleData? ReadCommonVehicleData()
    {
        Console.Write("Enter plate number: ");
        string? numberPlate = ConsoleInputReader.ReadRequiredString();

        if (numberPlate is null)
        {
            Console.WriteLine("Invalid plate number.");
            return null;
        }

        Console.Write("Enter color: ");
        string? color = ConsoleInputReader.ReadRequiredString();

        if (color is null)
        {
            Console.WriteLine("Invalid color.");
            return null;
        }

        Console.Write("Enter number of wheels: ");
        int? numberOfWheels = ConsoleInputReader.ReadZeroOrPositiveInt();

        if (numberOfWheels is null)
        {
            Console.WriteLine("Invalid number of wheels.");
            return null;
        }

        return new CommonVehicleData(numberPlate, color, numberOfWheels.Value);
    }

    private static void HandleSearchVehicle()
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

        ConsoleMenu.SearchVehicleTypeMenu();

        SearchVehicleTypes? searchVehicleTypeChoice = ConsoleInputReader.ReadSearchVehicleTypeChoice();

        if (searchVehicleTypeChoice is null)
        {
            Console.WriteLine("Invalid vehicle type.");
            return;
        }

        Type? vehicleType = GetVehicleTypeFromSearchChoice(searchVehicleTypeChoice.Value);

        Console.Write("Enter color, or press Enter for any color:");

        string? color = ConsoleInputReader.ReadOptionalString();

        Console.Write("Enter number of wheels, or press Enter for any number:");
        int? numberOfWheels = ConsoleInputReader.ReadOptionalZeroOrPositiveInt();

        Vehicle[] vehicles = currentGarage.SearchVehicles(color, numberOfWheels, vehicleType);

        if (vehicles.Length == 0)
        {
            Console.WriteLine("No vehicles matched the search.");
            return;
        }

        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }


    }

    private static Type? GetVehicleTypeFromSearchChoice(SearchVehicleTypes searchVehicleTypeChoice)
    {
        return searchVehicleTypeChoice switch
        {
            SearchVehicleTypes.All => null,
            SearchVehicleTypes.Car => typeof(Car),
            SearchVehicleTypes.Motorcycle => typeof(MotorCycle),
            SearchVehicleTypes.Bus => typeof(Bus),
            SearchVehicleTypes.Boat => typeof(Boat),
            SearchVehicleTypes.Airplane => typeof(AirPlane),
            _ => null
        };
    }

    private static void AddVehicleResultMessage(AddVehicleResult result)
    {
        switch (result)
        {
            case AddVehicleResult.Success:
                Console.WriteLine("Vehicle was parked successfully.");
                break;

            case AddVehicleResult.GarageFull:
                Console.WriteLine("Could not park vehicle. The garage is full.");
                break;

            case AddVehicleResult.DuplicatePlateNumber:
                Console.WriteLine("Could not park vehicle. A vehicle with that plate number already exists.");
                break;

            default:
                Console.WriteLine("Could not park vehicle. Unknown error.");
                break;
        }

        Console.WriteLine();

        WaitForUser();
    }

    private static void WaitForUser()
    {
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey(intercept: true);
        Console.WriteLine();
    }
}
