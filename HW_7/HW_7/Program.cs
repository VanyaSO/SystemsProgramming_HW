using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HW_7;

// Необходимо загрузить информацию о пользователе с сервера или локальной базы данных, используя асинхронный метод.
// Если во время загрузки возникает ошибка (например, сервер не отвечает), нужно обработать эту ошибку и уведомить пользователя о проблеме.
// Выполните имитацию зависания сервера и отмените операцию, если запрос к серверу выполняется более 10 секунд.
    
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

        using (ApplicationContext db = new ApplicationContext())
        {
            db.Users.AddRange(new List<User>
            {
                new User {Name = "Alex"},
                new User {Name = "Misha"}
            });
        }

        User? user = await GetUserAsync();
        if (user != null)
        {
            Console.WriteLine(user.Name);
        }

    }

    static async Task<User?> GetUserAsync()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(10000);
        
        
        Task<User?> result = Task.Run(async () =>
        {
            await Task.Delay(15000);
            using (ApplicationContext db = new ApplicationContext())
            {
                return await db.Users.FirstOrDefaultAsync();
            }
        });

        if (await Task.WhenAny(result, Task.Delay(10000, cancellationTokenSource.Token)) == result) return await result;

        throw new OperationCanceledException("Error");
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