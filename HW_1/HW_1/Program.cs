using System.Diagnostics;

namespace HW_1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "open";
                process.StartInfo.Arguments = "-a Safari";
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.Exited += (sender, eventArgs) => Console.WriteLine($"Процес завершился с кодом: {process.ExitCode}");
                process.Start();
                process.WaitForExit();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}