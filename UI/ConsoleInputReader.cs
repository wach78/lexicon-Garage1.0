using GarageV1.Enums;

namespace GarageV1.UI;

internal static class ConsoleInputReader
{
    public static MenuChoice? ReadMainMenuChoice()
    {

        string? input = Console.ReadLine();

        if (
            int.TryParse(input, out int numericChoice)
            && Enum.IsDefined(typeof(MenuChoice), numericChoice)
        )
        {
            return (MenuChoice)numericChoice;
        }

        return null;
    }


    public static int? ReadPositiveInt()
    {
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value) && value > 0)
        {
            return value;
        }

        return null;
    }

    public static VehicleTypeChoice? ReadVehicleTypeChoice()
    {
        string? input = Console.ReadLine();

        if (
            int.TryParse(input, out int numericChoice)
            && Enum.IsDefined(typeof(VehicleTypeChoice), numericChoice)
        )
        {
            return (VehicleTypeChoice)numericChoice;
        }

        return null;
    }

    public static string? ReadRequiredString()
    {
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        return input.Trim();
    }

    public static int? ReadZeroOrPositiveInt()
    {
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value) && value >= 0)
        {
            return value;
        }

        return null;
    }

    public static string? ReadOptionalString()
    {
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        return input.Trim();
    }

    public static int? ReadOptionalZeroOrPositiveInt()
    {
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        if (int.TryParse(input, out int value) && value >= 0)
        {
            return value;
        }

        return null;
    }

    public static SearchVehicleTypes? ReadSearchVehicleTypeChoice()
    {
        string? input = Console.ReadLine();

        if (
            int.TryParse(input, out int numericChoice) &&
            Enum.IsDefined(typeof(SearchVehicleTypes), numericChoice)
        )
        {
            return (SearchVehicleTypes)numericChoice;
        }

        return null;
    }
}
