namespace HotelRoomManager.Models;

public class MenuSelection
{
    private static int selection;
    private static int selMenuLimit;

    public static bool Main()
    {
        selMenuLimit = 2;
        var selection = ValidateSelection();

        if (selection == 1)
            Menu.BookingMenu();
        else if (selection == 2)
            Menu.RegistrationMenu();

        return false;
    }

    public static void Booking()
    {
        selMenuLimit = 3;
        selection = ValidateSelection();

        if (selection == 1)
            Menu.BookingMenu();
        else if (selection == 2)
            Menu.RegistrationMenu();
        else if (selection == 3)
            Menu.BookingMenu();

        Menu.MainMenu();

    }
    public static void Registration()
    {
        selMenuLimit = 2;
        selection = ValidateSelection();

        if (selection == 1)
            Menu.BookingMenu();
        else if (selection == 2)
            Menu.RegistrationMenu();

        Menu.MainMenu();

    }
    public static int ValidateSelection()
    {
        int intSelection;
        Console.WriteLine("Välj i menyn:");
        while (true)
        {
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out intSelection) && intSelection >= 0 && intSelection <= selMenuLimit)
            {
                return intSelection;
            }
            Console.WriteLine("Välj mellan de angivna siffrorna");
        }
    }
}