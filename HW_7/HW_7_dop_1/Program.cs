namespace HW_7_dop_1;

// Обработать несколько исключений в программе. Создайте асинхронный метод, который принимает массив строк.
// Вызовите этот метод минимум три раза, передав разные имена людей. В методе, если есть повторяющиеся имена, генерируйте ошибку.
// Если повторений нет, выведите имена в консоль. После выполнения всех вызовов выведите в консоль все возникшие ошибки.
    
class Program
{
    static async Task Main(string[] args)
    {
        var tasks = new List<Task>();

        try
        {
            tasks.Add(HasDuplicate(new List<string> { "Alisa", "Ivan", "Ivan" }));
            tasks.Add(HasDuplicate(new List<string> { "Sasha", "Ivan", "Ivan" }));
            tasks.Add(HasDuplicate(new List<string> { "Anastasia", "Anastasia", "Kate" }));
            await Task.WhenAll(tasks);
        }
        catch
        {
            foreach (var task in tasks)
            {
                if (task.IsFaulted)
                {
                    foreach (var innerException in task.Exception.InnerExceptions)
                    {
                        Console.WriteLine(innerException.Message);
                    }
                }
            }
        }
    }

    static async Task HasDuplicate(List<string> arr)
    {
        List<string> duplicates = new List<string>();
        
        await Task.Run(() =>
        {
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i] == arr[j])
                        duplicates.Add(arr[i]);
                }
                if (!duplicates.Contains(arr[i]))
                    Console.WriteLine(arr[i]);
            }
        });
        
        if (duplicates.Any())
            throw new AggregateException(duplicates.
                Select(name => new Exception($"Дублируется имя {name}"))
                .ToList());
    }
}