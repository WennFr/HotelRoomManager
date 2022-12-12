namespace HotelRoomManager.Controllers;

public class MenuSelection
{
    private static int selection;
    private static int selMenuLimit;

    public static bool Main()
    {
        selMenuLimit = 3;
        var selection = ValidateSelection();

        switch (selection)
        {
            case 1:
                Menu.BookingMenu();
                break;
            case 2:
                Menu.RegistrationMenu();
                break;
            case 3:
                Menu.EditMenu();
                break;
        }

        return false;

    }

    public static void Booking()
    {
        selMenuLimit = 3;
        selection = ValidateSelection();

        switch (selection)
        {
            case 1:
                Menu.BookingMenu();
                break;
            case 2:
                Menu.RegistrationMenu();
                break;
            case 3:
                Menu.EditMenu();
                break;
        }

        Menu.MainMenu();

    }
    public static void Registration()
    {
        selMenuLimit = 2;
        selection = ValidateSelection();

        switch (selection)
        {
            case 1:
                Menu.BookingMenu();
                break;
            case 2:
                Menu.RegistrationMenu();
                break;
        }

        Menu.MainMenu();

    }
    public static int ValidateSelection()
    {
        int intSelection;
        Console.WriteLine($"{Environment.NewLine}Välj i menyn:");
        while (true)
        {
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out intSelection) && intSelection >= 0 && intSelection <= selMenuLimit)
                return intSelection;

            Console.WriteLine("Välj mellan de angivna siffrorna i menyn");
        }
    }
}