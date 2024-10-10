namespace HW_9_dop_3;
using TextManager;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(TextManager.IsPalindrome("qweewq"));
        Console.WriteLine(TextManager.IsPalindrome("123 \n"));
        
        Console.WriteLine(TextManager.Reverse("Hello, World!") + "\n");
        
        Console.WriteLine(TextManager.CountSentence("Hello, World!") + "\n");
        Console.WriteLine(TextManager.CountSentence("Hello, World! Text...") + "\n");
        
        Console.WriteLine();
    }
}