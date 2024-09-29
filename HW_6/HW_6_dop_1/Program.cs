namespace HW_6_dop_1;

class Program
{
    static void Main(string[] args)
    {
        // грзил сайт не файл)
        LoadWebsite();
        
        // для примера что ничего не блокируется вывожу числа
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(500);
        }
    }

    static async void LoadWebsite()
    {
        using (HttpClient httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.GetAsync("https://starrynift.art/home");
                string content = await response.Content.ReadAsStringAsync();
                await Task.Delay(5000);
                Console.WriteLine("Данные загружены");
                Console.WriteLine(content);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}