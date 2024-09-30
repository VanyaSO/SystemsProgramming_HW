using System.Net;

namespace HW_5;

class Program
{
    // У вас есть список URL-адресов, которые нужно загрузить параллельно (загрузить содержимое страницы),
    // используя несколько потоков на C#. В программе должна быть возможность отменить операцию, если она
    // занимает слишком много времени или если пользователь решит ее отменить.
    // Напишите программу, которая загружает файлы, используя TPL и CancellationToken.
    static void Main(string[] args)
    {
        List<string> urls = new List<string>
        {
            "https://od.itstep.org/",
            "https://www.microsoft.com/uk-ua/"
        };
        CancellationTokenSource cls = new CancellationTokenSource();

        Task[] tasks = new Task[urls.Count];

        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Factory.StartNew(() =>
            {
                while (urls.Count > 0 && !cls.Token.IsCancellationRequested)
                {
                    string? url = null;
                    int count = 1;
                    lock (urls)
                    {
                        count += 1;
                        url = urls[0];
                        urls.RemoveAt(0);
                    }

                    if (url != null)
                    {
                        try
                        {
                            WebClient client = new WebClient();
                            client.DownloadFile(url, $"site{count}.txt");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }, cls.Token);
        }

        Console.WriteLine("Stop load ?");
        Console.ReadKey();
        
        cls.Cancel();
        Task.WaitAll(tasks);
    }
}