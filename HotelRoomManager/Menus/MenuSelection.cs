using HotelRoomManager.Controllers;
using HotelRoomManager.CustomerControllers;
using HotelRoomManager.Data;
using HotelRoomManager.Messages;

namespace HotelRoomManager.Menus;

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

        var create = new Create(dbContext);
        switch (selection)
        {
            case 1:
                create.CreateNewBooking();
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
        var createCustomer = new CreateCustomer(dbContext);
        var create = new Create(dbContext);
        switch (selection)
        {
            case 1:
                create.CreateNewRoom();
                break;
            case 2:
                createCustomer.Create();
                break;
        }

        Menu.MainMenu();
    }
    public static void UpdateSystemData()
    {
        selMenuLimit = 4;
        selection = ValidateSelection(selMenuLimit);
        var update = new Update(dbContext);
        var delete = new Delete(dbContext);
        switch (selection)
        {
            case 1:
                update.UpdateRoom();
                break;
            case 2:
                var updateCustomer = new UpdateCustomer(dbContext);
                updateCustomer.Update();
                break;
            case 3:
                update.UpdateBooking();
                break;
            case 4:
                Menu.DeleteEntitySelectionMenu();
                break;

        }

        Menu.MainMenu();
    }


    public static void DeleteEntity()
    {
        var selectionMenuLimit = 3;
        var selection = MenuSelection.ValidateSelection(selectionMenuLimit);
        var delete = new Delete(dbContext);

        switch (selection)
        {
            case 1:
                delete.DeleteRoom();
                break;
            case 2:
                var deleteCustomer = new DeleteCustomer(dbContext); 
                deleteCustomer.Delete();
                break;
            case 3:
                delete.DeleteBooking();
                break;
            
        }




    }



    public static int ValidateSelection(int selectionMenuLimit)
    {
        int intSelection;
        Console.WriteLine($"{Environment.NewLine}Välj i menyn:");
        while (true)
        {
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out intSelection) && intSelection >= 0 && intSelection <= selectionMenuLimit)
                return intSelection;

            Message.ChooseBetweenAvailableMenuNumbers();
        }
    }
}