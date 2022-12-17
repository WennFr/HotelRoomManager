using HotelRoomManager.BookingControllers;
using HotelRoomManager.CustomerControllers;
using HotelRoomManager.Data;
using HotelRoomManager.Messages;
using HotelRoomManager.RoomControllers;

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
        switch (selection)
        {
            case 1:
                var createBooking = new CreateBooking(dbContext);
                createBooking.Create();
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
        switch (selection)
        {
            case 1:
                var createRoom = new CreateRoom(dbContext);
                createRoom.Create();
                break;
            case 2:
                var createCustomer = new CreateCustomer(dbContext);
                createCustomer.Create();
                break;
        }

        Menu.MainMenu();
    }
    public static void UpdateSystemData()
    {
        selMenuLimit = 4;
        selection = ValidateSelection(selMenuLimit);
        switch (selection)
        {
            case 1:
                var updateRoom = new UpdateRoom(dbContext);
                updateRoom.Update();
                break;
            case 2:
                var updateCustomer = new UpdateCustomer(dbContext);
                updateCustomer.Update();
                break;
            case 3:
                var updateBooking = new UpdateBooking(dbContext);
               updateBooking.Update();
                break;
            case 4:
                Menu.DeleteEntityMenu();
                break;

        }

        Menu.MainMenu();
    }


    public static void DeleteEntity()
    {
        var selectionMenuLimit = 3;
        var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

        switch (selection)
        {
            case 1:
                var deleteRoom = new DeleteRoom(dbContext);
                deleteRoom.Delete();
                break;
            case 2:
                var deleteCustomer = new DeleteCustomer(dbContext); 
                deleteCustomer.Delete();
                break;
            case 3:
                var deleteBooking = new DeleteBooking(dbContext);
                deleteBooking.Delete();
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