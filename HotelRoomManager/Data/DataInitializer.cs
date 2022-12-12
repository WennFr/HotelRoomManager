using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Data;

public class DataInitializer
{

    public void MigrateAndSeed()
    {
        var dbContext = Builder.GetDbContext();
        dbContext.Database.Migrate();
       
        dbContext.SaveChanges();

    }






}