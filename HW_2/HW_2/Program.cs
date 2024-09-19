namespace HW_2;

// Напишите программу, которая создает несколько потоков, каждый из которых моделирует датчик температуры в отдельной комнате.
// Каждый поток должен периодически генерировать и выводить случайные значения температуры для своей комнаты.
// Программа должна остановить все потоки через заданное время.
    
class Program
{
    private static bool _stop = false;
    
    static void Main(string[] args)
    {
        
        List<Thread> threads = new List<Thread>()
        {
            new Thread(() => TemperatureSensor("Room1", 1500)),
            new Thread(() => TemperatureSensor("Room2", 1000)),
            new Thread(() => TemperatureSensor("Room3", 3000))
        };
        
        foreach (var thread in threads)
            thread.Start();
        
        Thread.Sleep(5000);
        _stop = true;
        
        Console.WriteLine("Все потоки остановленны");
    }

    static void TemperatureSensor(string name, int period)
    {
        Random random = new Random();

        while (!_stop)
        {
            Console.WriteLine($"{name}: {random.Next(20,28)}C");
            Thread.Sleep(period);
        }
    }
}