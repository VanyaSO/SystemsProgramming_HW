namespace HW_2_dop_7;


// Представьте, что вы создаете систему для ресторана, которая позволяет официантам принимать заказы от клиентов, а поварам готовить блюда.
// Ваша задача - реализовать эту систему с использованием многопоточности. Использовать очередь.
//
// 1) Создайте два типа потоков: официанты и повара.
// 2) Официанты могут принимать заказы от клиентов и добавлять их в очередь заказов.
// 3) Повара могут брать заказы из очереди и готовить блюда.
// 4) Очередь заказов должна быть синхронизирована, чтобы избежать конфликтов при доступе к ней.
// 5) Параллельно может работать несколько официантов и поваров, обрабатывая заказы.


class Program
{
    private static int orderNumber = 0;
    private static Queue<string> _orders = new Queue<string>();
    private static Random _random = new Random();
    private static bool stop = false;
    
    static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread> { new Thread(() => WaiterGetOrder()), new Thread(() => WaiterGetOrder()), new Thread(() => WaiterGetOrder()), new Thread(() => CookPreparingOrder()), new Thread(() => CookPreparingOrder())};
        
        foreach (var thread in threads)
            thread.Start();
        
        foreach (var thread in threads)
            thread.Join();

        stop = true;
    }

    static void WaiterGetOrder()
    {
        for (int i = 1; i <= 5; i++)
        {
            string newOrder = $"{++orderNumber}...Order";
            _orders.Enqueue(newOrder);
            Console.WriteLine($"{newOrder} was received");
            Thread.Sleep(_random.Next(10000, 20000));
        }
    }

    static void CookPreparingOrder()
    {
        while (!stop)
        {
            if (_orders.TryDequeue(out string? order))
            {
                Console.WriteLine($"{order} started cooking");
                Thread.Sleep(_random.Next(3000, 6000));
                Console.WriteLine($"{order} finished cooking");
            }
            else
            {
                Console.WriteLine("Cook chill 5s...)))");
                Thread.Sleep(_random.Next(5000));
            }
        }
    }
}