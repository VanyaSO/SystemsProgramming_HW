using System.Text;

namespace HW_8_dop_1;

class Program
{
    // Напишите программу, в которой объявляется переменная типа double.
    // В область памяти, выделенную под эту переменную, запишите такие значения: в первый байт запишите значение 1,
    // в следующие два байта запишите символ ƍAƍ, в следующие четыре байта запишите значение 2 и
    // в оставшийся восьмой байт запишите значение 3.
        
    unsafe static void Main(string[] args)
    {
        double cell = 0;
        char symbol = 'A';
        byte* bytes = (byte*)&cell;

        bytes[0] = 1;

        byte[] symbolBytes = Encoding.Unicode.GetBytes("ƍAƍ");
        bytes[1] = symbolBytes[0];
        bytes[2] = symbolBytes[1];

        byte[] intBytes = BitConverter.GetBytes(2);
        for (int i = 0; i < intBytes.Length; i++)
            bytes[3 + i] = intBytes[i];

        bytes[7] = 3;

        for (int i = 0; i < sizeof(double); i++)
            Console.WriteLine($"Байт {i}: {bytes[i]}");
    }
}