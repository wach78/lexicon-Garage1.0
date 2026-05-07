using GarageV1.Enums;

internal class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;


        while (isRunning)
        {
            Menu();


            MenuChoice numericChoice = (MenuChoice)choice;

            switch (numericChoice)
            {
                case MenuChoice.Exit:
                    isRunning = false;
                    Console.WriteLine("Exit.");
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
}