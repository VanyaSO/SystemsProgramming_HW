namespace HW_6;

class Program
{
    // Используя асинхронный метод, считать текст из файла, определить количество символов, результат вывести на экран.
    
    static async Task Main(string[] args)
    {
        await CreateFile();
        string str = await GetStringFromFileAsync();
        int countSymbols = await GetCountSymbolsInStringAsync(str);
        Console.WriteLine(countSymbols);
    }

    static async Task CreateFile()
    {
        string str = " Запуск Kamino V2 ожидается в Q4 этого года. Несмотря на отсутствие значительного utility для токена, команда объявила о планах начать распределять доходы на стимулы, что потребует покупки KMNO с рынка. Kamino зарабатывает около $1M в месяц, что составляет 10% от капитализации. Для сравнения, AAVE зарабатывает $4M в месяц при капитализации в $2.5B. Неплохо, да?";
        File.WriteAllTextAsync("text.txt", str);
    }
    
    static async Task<string> GetStringFromFileAsync()
    {
        return await File.ReadAllTextAsync("text.txt");
    }
    
    static async Task<int> GetCountSymbolsInStringAsync(string str)
    {
        return await Task.Run(() =>
        {
            int count = 0;
            foreach (var symbol in str)
            {
                if (char.IsPunctuation(symbol) || char.IsSymbol(symbol))
                    count += 1;
            }

            return count;
        });
    }
}