using GarageV1.Enums;

namespace GarageV1.UI
{
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
    }
}
