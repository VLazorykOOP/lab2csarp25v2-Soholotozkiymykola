using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Оберіть завдання:");
        Console.WriteLine("1. Завдання 1: Генерація масиву і пошук елементів поза інтервалом");
        Console.WriteLine("2. Завдання 2: Пошук кількості пар сусідніх елементів з різницею");
        Console.WriteLine("3. Завдання 3: Середнє арифметичне парних елементів нижче головної діагоналі матриці");
        Console.WriteLine("4. Завдання 4: Мінімальні елементи в кожному стовпці сходчастого масиву");
        Console.Write("Введіть номер завдання: ");
        int taskChoice = int.Parse(Console.ReadLine());

        switch (taskChoice)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            case 3:
                Task3();
                break;
            case 4:
                Task4();
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

    static void Task1()
    {
        Random rand = new Random();

        Console.Write("Введіть розмір масиву: ");
        int arraySize = int.Parse(Console.ReadLine());

        int[] numbers = new int[arraySize];

        Console.Write("Введіть початок інтервалу (a): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введіть кінець інтервалу (b): ");
        int b = int.Parse(Console.ReadLine());

        for (int i = 0; i < arraySize; i++)
        {
            numbers[i] = rand.Next(0, 101);
        }

        Console.WriteLine("\nЗгенерований масив:");
        for (int i = 0; i < arraySize; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine("\n");

        Console.WriteLine($"Індекси елементів поза інтервалом [{a}, {b}]:");
        for (int i = 0; i < arraySize; i++)
        {
            if (numbers[i] < a || numbers[i] > b)
            {
                Console.WriteLine($"Індекс: {i}, Значення: {numbers[i]}");
            }
        }
    }

    static void Task2()
    {
        Random rand = new Random();

        Console.Write("Введіть розмір масиву: ");
        int size = int.Parse(Console.ReadLine());

        Console.Write("Введіть задану різницю (d): ");
        int d = int.Parse(Console.ReadLine());

        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(0, 101);
        }

        Console.WriteLine("\nЗгенерований масив:");
        for (int i = 0; i < size; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        int count = 0;
        for (int i = 0; i < size - 1; i++)
        {
            if (Math.Abs(array[i] - array[i + 1]) == d)
            {
                count++;
            }
        }

        Console.WriteLine($"\nКількість пар сусідніх елементів з різницею {d}: {count}");
    }

    static void Task3()
    {
        Random rand = new Random();

        Console.Write("Введіть розмірність масиву (n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        Console.WriteLine("\nЗгенерований масив:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rand.Next(0, 101);
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int sum = 0;
        int count = 0;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrix[i, j] % 2 == 0)
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
        }

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine($"\nСереднє арифметичне парних елементів нижче головної діагоналі: {average:F2}");
        }
        else
        {
            Console.WriteLine("\nНемає жодного парного елемента нижче головної діагоналі.");
        }
    }

    static void Task4()
    {
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[n][];
        Random rand = new Random();

        int maxColumns = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть кількість елементів у рядку {i + 1}: ");
            int m = int.Parse(Console.ReadLine());
            jaggedArray[i] = new int[m];

            if (m > maxColumns)
                maxColumns = m;

            for (int j = 0; j < m; j++)
            {
                jaggedArray[i][j] = rand.Next(0, 101);
            }
        }

        Console.WriteLine("\nСхідчастий масив:");
        for (int i = 0; i < n; i++)
        {
            foreach (int val in jaggedArray[i])
            {
                Console.Write(val + "\t");
            }
            Console.WriteLine();
        }

        int[] minInColumns = new int[maxColumns];
        for (int col = 0; col < maxColumns; col++)
        {
            int min = int.MaxValue;
            bool found = false;

            for (int row = 0; row < n; row++)
            {
                if (col < jaggedArray[row].Length)
                {
                    if (jaggedArray[row][col] < min)
                    {
                        min = jaggedArray[row][col];
                    }
                    found = true;
                }
            }

            minInColumns[col] = found ? min : -1;
        }

        Console.WriteLine("\nМінімальні елементи в кожному стовпці:");
        for (int i = 0; i < minInColumns.Length; i++)
        {
            Console.WriteLine($"Стовпець {i}: {(minInColumns[i] != -1 ? minInColumns[i] : "немає елементів")}");
        }
    }
}
