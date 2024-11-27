using System;
using System.Numerics;
using System.Collections;
using System.IO;
using System.Text;



public class MainClass
{
     public static (int, int)  NumberOfVowelsAndConsonants(char[] arr)
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
    }//Метод вычисляет количество гласных и согласных букв
    public static void Task1(string args)
    {
        Console.WriteLine("Упражнение 6.1\n");
        //Написать программу, которая вычисляет число гласных и согласных букв в
        //файле.Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
        //заносится в массив символов.Количество гласных и согласных букв определяется проходом
        //по массиву.Предусмотреть метод, входным параметром которого является массив символов.
        //Метод вычисляет количество гласных и согласных букв.
        //Проверка на наличие аргументов командной строки

        char[] arrayOfchars = File.ReadAllText(args).ToCharArray();

        (int numberOfVowels, int numberOfConsonants) = NumberOfVowelsAndConsonants(arrayOfchars);

        Console.WriteLine($"Количество гласных букв: {numberOfVowels}");
        Console.WriteLine($"Количество согласных букв: {numberOfConsonants}");
    }
    public static void Task2() 
    {
     
    
    
    }
    public static void Task3() { }
    public static void Task4() { }
    public static void Task5() { }
    public static void Task6() { }


    public static void Main()
    {
        Task1("C:/Users/adora/Documents/Books/text.txt");// Привет! Как дела?

    } 
}
