namespace HW_2_dop_2;

// Напишите программу, которая создает несколько касс (потоков), и каждый поток будет обрабатывать очередь покупателей.
// Каждый покупатель будет обрабатываться за случайное время (от 1 до 3 секунд).
// Программа должна выводить на экран, когда покупатель начинает и заканчивает обслуживание на каждой кассе.
//
// 1) Создайте класс Customer, который будет представлять покупателя.
// 2) Создайте класс CashRegister, который будет представлять кассу и будет работать в отдельном потоке.
// 3) Используйте класс Thread для моделирования работы касс.
// 4) Сгенерируйте очередь из 20 покупателей и распределите покупателей между кассами.

class Program
{
    static void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "Alice" },
            new Customer { Name = "Bob" },
            new Customer { Name = "Charlie" },
            new Customer { Name = "Diana" },
            new Customer { Name = "Ethan" },
            new Customer { Name = "Fiona" },
            new Customer { Name = "George" },
            new Customer { Name = "Hannah" },
            new Customer { Name = "Ivan" },
            new Customer { Name = "Julia" },
            new Customer { Name = "Kevin" },
            new Customer { Name = "Laura" },
            new Customer { Name = "Mike" },
            new Customer { Name = "Nina" },
            new Customer { Name = "Oscar" },
            new Customer { Name = "Paula" },
            new Customer { Name = "Quinn" },
            new Customer { Name = "Rachel" },
            new Customer { Name = "Sam" },
            new Customer { Name = "Tom" }
        };

        CashRegister cashRegister1 = new CashRegister { Name = "cashRegister1" };
        CashRegister cashRegister2 = new CashRegister { Name = "cashRegister2" };
        
        cashRegister1.Start(customers.Take(customers.Count/2));
        cashRegister2.Start(customers.Skip(customers.Count/2));
    }
}

class Customer
{
    public string Name { get; set; }
}

class CashRegister
{
    // для внешнего вида в консоли
    public static int numberCustomer = 0;

    public string Name { get; set; }

    public void Start(IEnumerable<Customer> customers)
    {
        Console.WriteLine($"Каса {Name} начала работу");
        Thread thread = new Thread(() => CustomerService(customers));
        thread.Start();
    }

    public void CustomerService(IEnumerable<Customer> customers)
    {
        Random randomTime = new Random();
        
        foreach (var customer in customers)
        {
            int number = ++numberCustomer;

            Console.WriteLine($"{number} Начато обслуживание клиента {customer.Name} на кассе {Name} в {DateTime.Now}");
            Thread.Sleep(randomTime.Next(1000, 3000));
            Console.WriteLine($"{number} Закончено обслуживание клиента {customer.Name} на кассе {Name} в {DateTime.Now}");
        }
    }
}