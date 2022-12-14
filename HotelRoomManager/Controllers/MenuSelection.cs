using HotelRoomManager.Data;

namespace HotelRoomManager.Controllers;

public static class MenuSelection
{
    private static int selection;
    private static int selMenuLimit;
    public static ApplicationDbContext dbContext { get; set; }
    public static void GetDbContext(ApplicationDbContext context)
    {
        dbContext = context;
    }

    public static bool Main()
    {
        selMenuLimit = 3;
        var selection = ValidateSelection(selMenuLimit);

        switch (selection)
        {
            case 1:
                Menu.BookingMenu();
                break;
            case 2:
                Menu.RegistrationMenu();
                break;
            case 3:
                Menu.EditSystemDataMenu();
                break;
        }

        return false;

    }

    public static void Booking()
    {
        selMenuLimit = 3;
        selection = ValidateSelection(selMenuLimit);

        switch (selection)
        {
            case 1:
                Menu.BookingMenu();
                break;
            case 2:
                Menu.RegistrationMenu();
                break;
            case 3:
                Menu.EditSystemDataMenu();
                break;
        }

        Menu.MainMenu();

    }
    public static void Registration()
    {
        selMenuLimit = 2;
        selection = ValidateSelection(selMenuLimit);
        var create = new Create(dbContext);
        switch (selection)
        {
            case 1:
                create.CreateNewRoom();
                break;
            case 2:
                create.CreateNewCustomer();
                break;
        }

        Menu.MainMenu();

    }
    public static void UpdateSystemData()
    {
        selMenuLimit = 3;
        selection = ValidateSelection(selMenuLimit);
        var update = new Update(dbContext);
        switch (selection)
        {
            case 1:
              
                break;
            case 2:
                update.UpdateCustomer();
                break;

            case 3:

                break;
        }

        Menu.MainMenu();
    }

   
    public static int ValidateSelection(int selMenuLimit)
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