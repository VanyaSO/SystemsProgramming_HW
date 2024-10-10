namespace TextManager;

public static class TextManager
{
    private static char[] chars = new char[] { '.', '?', '!', ';' };
    // Создайте dll-модуль, который содержит класс для работы с текстом.
    // В этом классе должны быть статические методы по работе с текстом: проверка на палиндром,
    // подсчет количества предложений, переворот строки. Подключите dll-модуль к другому проекту и проверьте работу методов.

    public static bool IsPalindrome(string str)
    {
        str = str.ToLower();
        for (int i = 0, j = str.Length-1; i < j / 2; i++, j--)
        {
            if (str[i] != str[j]) return false;
        }
        return true;
    }

    public static string Reverse(string str)
    {
        string reverseStr = "";
        for (int i = str.Length-1; i >= 0; i--)
            reverseStr += str[i];

        return reverseStr;
    }

    public static int CountSentence(string str)
    {
        string[] sentences = str.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        return sentences.Length;
    }
}