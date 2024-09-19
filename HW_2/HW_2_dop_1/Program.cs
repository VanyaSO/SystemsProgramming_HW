namespace HW_2_dop_1;

// Используя потоки создать метод, который находит в строке количество слов, которые начинаются и оканчиваются на одну и ту же букву.
    
class Program
{
    private static int _count;
    static void Main(string[] args)
    {
        string str = "Hannah drove her racecar to see a civic event.";
        string[] words = str.Split(' ', ',');


        List<Thread> threads = new List<Thread>
        {
            new Thread(() => GetCountPalindromeWorlds(words.Take(words.Length / 2))),
            new Thread(() => GetCountPalindromeWorlds(words.Skip(words.Length/2)))
        };

        foreach (var thread in threads)
            thread.Start();

        foreach (var thread in threads)
            thread.Join();
        
        Console.WriteLine(_count);
    }

    static void GetCountPalindromeWorlds(IEnumerable<string> arr)
    {
        foreach (var str in arr)
        {
            if (str.Length > 1 && char.ToUpper(str[0]) == char.ToUpper(str[str.Length-1]))
                _count+=1;
        }
    }
}