using Microsoft.EntityFrameworkCore;

namespace HW_6_dop_3;

// Добавить коллекцию пользователь в базе данных и после считать всех пользователей из таблицы в коллекцию,
// используя асинхронные методы. Работать с базой данных можно через Ado.Net или EF.
    
class Program
{
    static async Task Main()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.SaveChanges();
        }

        await AddUserAsync(new User { Name = "Ivan" });
        await AddUserAsync(new User { Name = "Miha" });

        List<User> users = await GetAllUsers();
    }

    static async Task AddUserAsync(User user)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }
    }
    
    static async Task<List<User>> GetAllUsers()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return await db.Users.ToListAsync();
        }
    }
};

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        optionsBuilder.UseSqlServer("Server=localhost;Database=HW;User=sa;Password=admin@Admin87457;TrustServerCertificate=True;");
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}