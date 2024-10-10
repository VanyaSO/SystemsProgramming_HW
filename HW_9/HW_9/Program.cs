using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace HW_9;

class Program
{
    
    // Создайте консольное приложение, которое позволит пользователю решать арифметические выражения.
    static async Task Main(string[] args)
    {
        var options = ScriptOptions.Default.AddImports("System", "System.Math");
        string code;
        while (true)
        {
            code = Console.ReadLine();
            if (code == "") break;
            
            var result = await CSharpScript.EvaluateAsync(code, options);
            Console.WriteLine(result);
        }
    }
}