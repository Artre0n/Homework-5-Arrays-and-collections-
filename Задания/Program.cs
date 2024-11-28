using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;


public struct Student
{
    public string LastName;
    public string FirstName;
    public int BirthYear;
    public string Exam;
    public int Score;

    public override string ToString()
    {
        return $"{LastName} {FirstName}, Год рождения: {BirthYear}, Экзамен: {Exam}, Баллы: {Score}";
    }
}

public class MainClass
{

    public static void Task1()
    {
        Console.WriteLine("Упражнение 1\n");
        //Создать List на 64 элемента, скачать из интернета 32 пары картинок(любых). В List
        //должно содержаться по 2 одинаковых картинки. Необходимо перемешать List с
        //картинками.Вывести в консоль перемешанные номера(изначальный List и полученный
        //List).Перемешать любым способом.
        List<string> images = new List<string>();
        
        string[] imagePaths = new string[]
        {
            "C:/Users/adora/Desktop/images/1.jpg",
            "C:/Users/adora/Desktop/images/1.jpg",
            "C:/Users/adora/Desktop/images/2.jpg",
            "C:/Users/adora/Desktop/images/2.jpg",
            "C:/Users/adora/Desktop/images/3.jpg",
            "C:/Users/adora/Desktop/images/3.jpg",
            "C:/Users/adora/Desktop/images/4.jpg",
            "C:/Users/adora/Desktop/images/4.jpg",
            "C:/Users/adora/Desktop/images/5.jpg",
            "C:/Users/adora/Desktop/images/5.jpg",
            "C:/Users/adora/Desktop/images/6.jpg",
            "C:/Users/adora/Desktop/images/6.jpg",
            "C:/Users/adora/Desktop/images/7.jpg",
            "C:/Users/adora/Desktop/images/7.jpg",
            "C:/Users/adora/Desktop/images/8.jpg",
            "C:/Users/adora/Desktop/images/8.jpg",
            "C:/Users/adora/Desktop/images/9.jpg",
            "C:/Users/adora/Desktop/images/9.jpg",
            "C:/Users/adora/Desktop/images/10.jpg",
            "C:/Users/adora/Desktop/images/10.jpg",
            "C:/Users/adora/Desktop/images/11.jpg",
            "C:/Users/adora/Desktop/images/11.jpg",
            "C:/Users/adora/Desktop/images/12.jpg",
            "C:/Users/adora/Desktop/images/12.jpg",
            "C:/Users/adora/Desktop/images/13.jpg",
            "C:/Users/adora/Desktop/images/13.jpg",
            "C:/Users/adora/Desktop/images/14.jpg",
            "C:/Users/adora/Desktop/images/14.jpg",
            "C:/Users/adora/Desktop/images/15.jpg",
            "C:/Users/adora/Desktop/images/15.jpg",
            "C:/Users/adora/Desktop/images/16.jpg",
            "C:/Users/adora/Desktop/images/16.jpg",
            "C:/Users/adora/Desktop/images/17.jpg",
            "C:/Users/adora/Desktop/images/17.jpg",
            "C:/Users/adora/Desktop/images/18.jpg",
            "C:/Users/adora/Desktop/images/18.jpg",
            "C:/Users/adora/Desktop/images/19.jpg",
            "C:/Users/adora/Desktop/images/19.jpg",
            "C:/Users/adora/Desktop/images/20.jpg",
            "C:/Users/adora/Desktop/images/20.jpg",
            "C:/Users/adora/Desktop/images/21.jpg",
            "C:/Users/adora/Desktop/images/21.jpg",
            "C:/Users/adora/Desktop/images/22.jpg",
            "C:/Users/adora/Desktop/images/22.jpg",
            "C:/Users/adora/Desktop/images/23.jpg",
            "C:/Users/adora/Desktop/images/23.jpg",
            "C:/Users/adora/Desktop/images/24.jpg",
            "C:/Users/adora/Desktop/images/24.jpg",
            "C:/Users/adora/Desktop/images/25.jpg",
            "C:/Users/adora/Desktop/images/25.jpg",
            "C:/Users/adora/Desktop/images/26.jpg",
            "C:/Users/adora/Desktop/images/26.jpg",
            "C:/Users/adora/Desktop/images/27.jpg",
            "C:/Users/adora/Desktop/images/27.jpg",
            "C:/Users/adora/Desktop/images/28.jpg",
            "C:/Users/adora/Desktop/images/28.jpg",
            "C:/Users/adora/Desktop/images/29.jpg",
            "C:/Users/adora/Desktop/images/29.jpg",
            "C:/Users/adora/Desktop/images/30.jpg",
            "C:/Users/adora/Desktop/images/30.jpg",
            "C:/Users/adora/Desktop/images/31.jpg",
            "C:/Users/adora/Desktop/images/31.jpg",
            "C:/Users/adora/Desktop/images/32.jpg",
            "C:/Users/adora/Desktop/images/32.jpg"
        };

        images.AddRange(imagePaths);


        Console.WriteLine("Изначальный список изображений:");
        for (int i = 0; i < images.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {images[i]}");
        }

        Random random = new Random();
        List<string> shuffledImages = images.OrderBy(x => random.Next()).ToList();

        Console.WriteLine("\nПеремешанный список изображений:");
        for (int i = 0; i < shuffledImages.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {shuffledImages[i]}");

        }
    }
    
    ////////////////////////////////////////////////////
    
    public static List<Student> students = new List<Student>();

    public static void LoadStudents(string filePath)
    {
        if (File.Exists(filePath))
        {
            var rows = File.ReadAllLines(filePath);
            foreach (var row in rows)
            {
                var parts = row.Split(',');
                if (parts.Length == 5)
                {
                    students.Add(new Student
                    {
                        LastName = parts[0].Trim(),
                        FirstName = parts[1].Trim(),
                        BirthYear = int.Parse(parts[2].Trim()),
                        Exam = parts[3].Trim(),
                        Score = int.Parse(parts[4].Trim())
                    });
                }
            }
        }
        else
        {
            Console.WriteLine("Файл не найден.");
        }
    }// Загрузка сткдентов из файла
    public static void AddStudent()
    {
        try
        {
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите год рождения: ");
            int birthYear = int.Parse(Console.ReadLine());
            if (1990 > birthYear || birthYear > 2007) { throw new ArgumentOutOfRangeException(); }
        
            Console.Write("Введите экзамен: ");
            string exam = Console.ReadLine();

            Console.Write("Введите баллы: ");
            int score = int.Parse(Console.ReadLine());
            if (40 > score || score > 100) {  throw new ArgumentException(); }

            students.Add(new Student
            {
                LastName = lastName,
                FirstName = firstName,
                BirthYear = birthYear,
                Exam = exam,
                Score = score
            });
            Console.WriteLine("Студент добавлен");

        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: неверный формат числа");
        }
        catch(ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: год рождения для студента от 1991 до 2006");
        }
        catch(ArgumentException)
        {
            Console.WriteLine("Ошибка: балл может быть от 40 до 100");
        }
    }// Добавить студента
    public static void ShowStudents() 
    {
        Console.WriteLine("\nСписок студентов:");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }   // Выводит список студентов
    public static void SortStudents()
    {
        students = students.OrderBy(s => s.Score).ToList();
        Console.WriteLine("Студенты отсортированы по баллам");
    } // Сортировка студентов по баллам
    public static void RemoveStudent()
    {
        Console.Write("Введите фамилию: ");
        string lastName = Console.ReadLine();
        Console.Write("Введите имя: ");
        string firstName = Console.ReadLine();

        var studentToRemove = students.FirstOrDefault(s => s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)
                                                            && s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
        if (studentToRemove.Equals(default(Student)))
        {
            Console.WriteLine("Студент не найден.");
        }
        else
        {
            students.Remove(studentToRemove);
            Console.WriteLine("Студент удален");
        }
    } // Удалить студентаы
    public static void Task2()
    {
        Console.WriteLine("\nУпражнение 2\n");
        //Создать студента из вашей группы(фамилия, имя, год рождения, с каким экзаменом
        //поступил, баллы).Создать словарь для студентов из вашей группы(10 человек).
        //Необходимо прочитать информацию о студентах с файла.В консоли необходимо создать
        //меню:
        //a.Если пользователь вводит: Новый студент, то необходимо ввести
        //информацию о новом студенте и добавить его в List
        //b.Если пользователь вводит: Удалить, то по фамилии и имени удаляется
        //студент
        //c.Если пользователь вводит: Сортировать, то происходит сортировка по баллам
        //(по возрастанию)
        LoadStudents("C:/Users/adora/source/repos/Homework 5(Arrays and collections)/Задания/students.txt");

        string choice = string.Empty;
        while (choice != "выход")
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1.Новый студент");
            Console.WriteLine("2.Удалить");
            Console.WriteLine("3.Сортировать");
            Console.WriteLine("4.Показать список студентов");//Чтобы проверять удалилось, добавилось и тд или нет
            Console.WriteLine("5.Выход");//чтобы проверять быстрее
            Console.Write("Выберите действие: ");
            choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "новый студент":
                    AddStudent();
                    break;
                case "удалить":
                    RemoveStudent();
                    break;
                case "сортировать":
                    SortStudents();
                    break;
                case "показать список студентов":
                    ShowStudents();
                    break;
                case "выход":
                    break;
                default:
                    Console.WriteLine("Неверный выбор, gопробуйте снова.");
                    break;
            }
        }
    }
    public static void Main()
    {
        Task1();
        Task2();
    }
}