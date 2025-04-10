using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 3, 7, 12, -4, 10 };
        int a = 0, b = 10;

        Console.WriteLine($"Елементи, що не потрапляють у інтервал [{a}, {b}]:");

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < a || numbers[i] > b)
            {
                Console.WriteLine($"Індекс: {i}, Значення: {numbers[i]}");
            }
        }
    }
}
