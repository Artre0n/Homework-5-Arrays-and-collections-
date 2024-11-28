using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System.Text;



public class MainClass
{
    public static (int, int)  NumberOfVowelsAndConsonants(char[] arr)// Метод вычисляет количество гласных и согласных букв с помощью массива
    {   
        string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
        string consonants = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";

        int numberOfVowels = 0;
        int numberOfConsonants = 0;

        foreach (char c in arr)
        {
            if (vowels.Contains(c))
            {
                numberOfVowels++;
            }
            else if (consonants.Contains(c))
            {
                numberOfConsonants++;
            }
        }

        return (numberOfVowels, numberOfConsonants);
    }
    public static void Task1(string args)
    {
        Console.WriteLine("Упражнение 6.1\n");
        //Написать программу, которая вычисляет число гласных и согласных букв в
        //файле.Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
        //заносится в массив символов.Количество гласных и согласных букв определяется проходом
        //по массиву.Предусмотреть метод, входным параметром которого является массив символов.
        //Метод вычисляет количество гласных и согласных букв.

        char[] arrayOfchars = File.ReadAllText(args).ToCharArray();

        (int numberOfVowels, int numberOfConsonants) = NumberOfVowelsAndConsonants(arrayOfchars);
        
        Console.WriteLine($"Количество гласных букв: {numberOfVowels}");
        Console.WriteLine($"Количество согласных букв: {numberOfConsonants}");
    }
    static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB) // Умножение матриц
    {
        int rowsA = matrixA.GetLength(0);
        int columnsA = matrixA.GetLength(1);
        int columnsB = matrixB.GetLength(1);

        int[,] result = new int[rowsA, columnsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < columnsA; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return result;
    }
    public static void ShowMatrix(int[,] matrix) // Вывод матрицы на экран
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }

    public static void Task2() 
    {
        Console.WriteLine("\nУпражнение 6.2\n");
        //Написать программу, реализующую умножению двух матриц, заданных в
        //виде двумерного массива.В программе предусмотреть два метода: метод печати матрицы,
        //метод умножения матриц(на вход две матрицы, возвращаемое значение – матрица).
        // Ввод первой матрицы
        try
        {
            Console.WriteLine("Введите размеры первой матрицы:");

            Console.Write("Кол-во строк: ");
            int rowsA = int.Parse(Console.ReadLine());

            Console.Write("Кол-во столбцов: ");
            int columnsA = int.Parse(Console.ReadLine());

            int[,] matrixA = new int[rowsA, columnsA];

            Console.WriteLine("\nВведите элементы первой матрицы:");
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsA; j++)
                {
                    Console.Write($"{i + 1} строка, {j + 1} столбец: ");
                    matrixA[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введите размеры второй матрицы:");

            Console.Write("Кол-во строк: ");
            int rowsB = int.Parse(Console.ReadLine());

            Console.Write("Кол-во столбцов: ");
            int columnsB = int.Parse(Console.ReadLine());

            int[,] matrixB = new int[rowsB, columnsB];

            Console.WriteLine("\nВведите элементы второй матрицы:");
            for (int i = 0; i < rowsB; i++)
            {
                for (int j = 0; j < columnsB; j++)
                {
                    Console.Write($"{i + 1} строка, {j + 1} столбец: ");
                    matrixB[i, j] = int.Parse(Console.ReadLine());
                }
            }

            if (columnsA != rowsB)
            {
                throw new ArgumentException();
            }

            int[,] resultMatrix = MatrixMultiplication(matrixA, matrixB);

            Console.WriteLine("Результат умножения матриц: ");
            ShowMatrix(resultMatrix);
        }
        catch (FormatException) 
        {
            Console.WriteLine("Ошибка: некорректный формат числа");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Ошибка: кол-во столбцов первой матрицы должно быть равно кол-ву строк второй матрицы");
        }
    }
    static int TemperatureGeneration(int month, Random randomizer)// Случайные температуры по сезонам
    {
        // Зима (декабрь, январь, февраль)
        if (month == 0 || month == 1 || month == 11)
        {
            return randomizer.Next(-30, -6); 
        }
        // Весна (март, апрель, май)
        else if (month == 2 || month == 3 || month == 4)
        {
            return randomizer.Next(-1, 23); 
        }
        // Лето (июнь, июль, август)
        else if (month == 5 || month == 6 || month == 7)
        {
            return randomizer.Next(16, 35);
        }
        // Осень (сентябрь, октябрь, ноябрь)
        else
        {
            return randomizer.Next(-5, 24);
        }
    }
    static double[] AverageTemperature(int[,] temperature)//Вычисление средниз температур
    {
        double[] averages = new double[12];

        for (int month = 0; month < 12; month++)
        {
            double sum = 0;

            for (int day = 0; day < 30; day++)
            {
                sum += temperature[month, day];
            }

            averages[month] = sum / 30;
        }

        return averages;
    }
    public static void Task3() 
    {
        Console.WriteLine("\nУпражнение 6.3\n");
        //Написать программу, вычисляющую среднюю температуру за год. Создать
        //двумерный рандомный массив temperature[12, 30], в котором будет храниться температура
        //для каждого дня месяца(предполагается, что в каждом месяце 30 дней).Сгенерировать
        //значения температур случайным образом. Для каждого месяца распечатать среднюю
        //температуру.Для этого написать метод, который по массиву temperature[12, 30] для каждого
        //месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
        //средних температур.Полученный массив средних температур отсортировать по
        //возрастанию.

        int[,] temperature = new int[12, 30];
        Random randomizer = new Random();

        for (int month = 0; month < 12; month++)
        {
            for (int day = 0; day < 30; day++)
            {
                temperature[month, day] = TemperatureGeneration(month, randomizer);
            }
        }

        double[] averageTemperatures = AverageTemperature(temperature);

        Console.WriteLine("Средняя температура за каждый месяц:");
        for (int month = 0; month < averageTemperatures.Length; month++)
        {
            Console.WriteLine($"Месяц {month + 1}: {averageTemperatures[month]:F2} °C");
        }

        Array.Sort(averageTemperatures);

        Console.WriteLine("\nОтсортированные по возрастанию средние температуры:");
        foreach (var temp in averageTemperatures)
        {
            Console.WriteLine($"{temp:F2} °C");
        }

    }
    public static void NumberOfVowelsAndConsonants(List <char> listOfChars, out int numberOfVowels, out int numberOfConsonants)// Метод вычисляет количество гласных и согласных букв с помощью листа
    {
        string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
        string consonants = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";

        numberOfVowels = 0;
        numberOfConsonants = 0;

        foreach (char c in listOfChars)
        {
            if (vowels.Contains(c))
            {
                numberOfVowels++;
            }
            else if (consonants.Contains(c))
            {
                numberOfConsonants++;
            }
        }
    }
    public static void Task4(string args) 
    {
        Console.WriteLine("\nДомашнее задание 6.1\n");
        //Упражнение 6.1 выполнить с помощью коллекции List<T>.
        List<char> listOfChars = new List<char>(File.ReadAllText(args));
        
        NumberOfVowelsAndConsonants(listOfChars, out int numberOfVowels, out int numberOfConsonants);

        Console.WriteLine($"Количество гласных букв: {numberOfVowels}");
        Console.WriteLine($"Количество согласных букв: {numberOfConsonants}");

    }
    public static LinkedList<LinkedList<int>> WriteMatrix(int rows, int columns, string matrixName)
    {
        var matrix = new LinkedList<LinkedList<int>>();

        Console.WriteLine($"Введите элементы матрицы {matrixName}:");
        for (int i = 0; i < rows; i++)
        {
            var row = new LinkedList<int>();
            string[] elements = Console.ReadLine().Split();

            for (int j = 0; j < columns; j++)
            {
                if (j < elements.Length)
                {
                    row.AddLast(int.Parse(elements[j]));
                }
                else
                {
                    row.AddLast(0);
                }
            }

            matrix.AddLast(row);
        }

        return matrix;
    }
    public static void Task5()
    {
        Console.WriteLine("Домашнее задание 6.2");
        //Упражнение 6.2 выполнить с помощью коллекций LinkedList<LinkedList<T>>.
        try
        {
            Console.WriteLine("Введите размеры первой матрицы:");

            Console.Write("Кол-во строк: ");
            int rowsA = int.Parse(Console.ReadLine());

            Console.Write("Кол-во столбцов: ");
            int columnsA = int.Parse(Console.ReadLine());

            LinkedList<LinkedList<int>> matrixA = WriteMatrix(rowsA, columnsA, "A");

            Console.WriteLine("Введите размеры второй матрицы:");

            Console.Write("Кол-во строк: ");
            int rowsB = int.Parse(Console.ReadLine());

            Console.Write("Кол-во столбцов: ");
            int columnsB = int.Parse(Console.ReadLine());

            LinkedList<LinkedList<int>> matrixB = WriteMatrix(rowsB, columnsB, "B");

            if (columnsA != rowsB)
            {
                throw new ArgumentException();
            } 

        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: некорректный формат числа");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Ошибка: кол-во столбцов первой матрицы должно быть равно кол-ву строк второй матрицы");
        }
    }
    public static Dictionary<string, double> AverageTemperature(Dictionary<string, int[]> temperatureDatabase)//Вычисление средних температур
    {
        Dictionary<string, double> averageTemperatures = new Dictionary<string, double>();

        foreach (var temp in temperatureDatabase)
        {
            string month = temp.Key;
            int[] temperatures = temp.Value;

            double average = temperatures.Average();
            averageTemperatures[month] = average;
        }

        return averageTemperatures;
    }
    public static void Task6() 
    {
        Console.WriteLine("\nДомашнее задание 6.3\n");
        //Написать программу для упражнения 6.3, использовав класс
        //Dictionary<TKey, TValue>.В качестве ключей выбрать строки – названия месяцев, а в
        //качестве значений – массив значений температур по дням

        Dictionary<string, int[]> temperatureDatabase = new Dictionary<string, int[]>();
  
        string[] monthNames = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                                "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        
        Random randomizer = new Random();
        for (int i = 0; i < 12; i++)
        {
            int[] dailyTemperatures = new int[30];
            for (int j = 0; j < 30; j++)
            {
                // Зима (декабрь, январь, февраль)
                if (i == 0 || i == 1 || i == 11)
                {
                    dailyTemperatures[j] = randomizer.Next(-30, -6);
                }
                // Весна (март, апрель, май)
                else if (i == 2 || i == 3 || i == 4)
                {
                    dailyTemperatures[j] = randomizer.Next(-1, 23);
                }
                // Лето (июнь, июль, август)
                else if (i == 5 || i == 6 || i == 7)
                {
                    dailyTemperatures[j] = randomizer.Next(16, 35);
                }
                // Осень (сентябрь, октябрь, ноябрь)
                else
                {
                    dailyTemperatures[j] = randomizer.Next(-5, 24);
                }
            }
            temperatureDatabase[monthNames[i]] = dailyTemperatures;
        }

        Dictionary<string, double> averageTemperatures = AverageTemperature(temperatureDatabase);

        var sortedAverageTemperatures = from pair in averageTemperatures
                                        orderby pair.Value
                                        select pair;

        Console.WriteLine("Средняя температура по месяцам:");
        foreach (var pair in sortedAverageTemperatures)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value:F2}°C");
        }
    }

    public static void Main()
    {
        Task1("C:/Users/adora/source/repos/Homework 5(Arrays and collections)/Тумаков - Лабораторная 6 главы/text.txt");// Привет! Как дела?123
        Task2();
        Task3();
        Task4("C:/Users/adora/source/repos/Homework 5(Arrays and collections)/Тумаков - Лабораторная 6 главы/text.txt");// Привет! Как дела?123
        Task6();
    }
}
