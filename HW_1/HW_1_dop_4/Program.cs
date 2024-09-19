using System.Diagnostics;

namespace HW_1_dop_4;

class Program
{
    private static string[] _menu = new[] { "Выйти", "TextEdit", "Safari", "Telegram", "Google Ghrome", "Своё приложение" };
    
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            for (int i = 0; i < _menu.Length; i++)
            {
                Console.WriteLine($"{i+1}. {_menu[i]}");
            }

            Console.WriteLine("\nВыберите програму для запуска");
            if (Int32.TryParse(Console.ReadLine(), out int app) && app > 0 && app <= _menu.Length)
            {
                app--;  // Преобразуем в индекс массива
    
                if (app == 0)
                {
                    // Выход из программы
                    break;
                } 
                else if (app == _menu.Length - 1)
                {
                    // Пользовательское приложение
                    Console.WriteLine("Введите путь к своему приложению:");
                    string custPath = Console.ReadLine();
                    StartCustApp(custPath);  // Метод для запуска пользовательского приложения
                }
                else
                {
                    // Стандартные приложения из меню
                    StartApp(_menu[app]);
                }
    
                Console.WriteLine("Процесс запущен");   
            }
            else
                Console.WriteLine("Выберите корректный вариант");
            
            Console.WriteLine("Нажите любой кнопку чтобы продолжить...");
            Console.ReadLine();
        }
    }

    static void StartApp(string app)
    {
        using (Process process = new Process())
        {
            process.StartInfo.FileName = "open";
            process.StartInfo.Arguments = $"-a {app}";
            process.Start();
        }
    }
    
    static void StartCustApp(string app)
    {
        using (Process process = new Process())
        {
            process.StartInfo.FileName = "open";
            process.StartInfo.Arguments = $"{app}";
            process.Start();
        }
    }
}