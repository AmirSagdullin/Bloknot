using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Timers;
using System.IO;
using System.Xml.Linq;

namespace For_Dina
{
    internal class Student
    {
        public string surname { get; set; }
        public string name { get; set; }
        public int god_r { get; set; }
        public string exam { get; set; }
        public int points { get; set; }
    }
    internal class Program
    {
        static string Func2()
        {
            Console.WriteLine("Введите первый массив: (числа от 0 до 9)");
            int[] arr1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Console.WriteLine("Введите второй массив: (числа от 0 до 9)");
            int[] arr2 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int count = 0;
            int kol = 0;
            for (int i=0; i < arr1.Length; i++)
            {
                if (arr1[i] == 5)
                {
                    count++;
                }
            }
            for (int i=0; i < arr2.Length; i++)
            {
                if (arr2[i] == 5)
                {
                    kol++;
                }
            }
            if (count == kol)
            {
                return "Drinks All Round! Free Beers on Bjorg!";
            }
            else
            {
                return "Ой, Бьорг - пончик! Ни для кого пива!";
            }
        }
        public static void Students()
        {
            Console.WriteLine("Задание 1. Словарь студентов");
            Dictionary<int, Student> students = new Dictionary<int, Student>
            {
                [0] = new Student { surname = "Зиганшин", name = "Халиль", god_r = 2004, exam = "Информатика", points = 83 },
                [1] = new Student { surname = "Сайфуллин", name = "Азат", god_r = 2004, exam = "Информатика", points = 88 },
                [2] = new Student { surname = "Романов", name = "Илья", god_r = 2004, exam = "Информатика", points = 90 },
                [3] = new Student { surname = "Ахметов", name = "Ильдар", god_r = 2004, exam = "Информатика", points = 93 },
                [4] = new Student { surname = "Братухин", name = "Илья", god_r = 2004, exam = "Физика", points = 91 },
                [5] = new Student { surname = "Калашников", name = "Андрей", god_r = 2004, exam = "Информатика", points = 85 },
                [6] = new Student { surname = "Залялетдинов", name = "Азат", god_r = 2004, exam = "Информатика", points = 80 },
                [7] = new Student { surname = "Ахметзянов", name = "Камиль", god_r = 2004, exam = "Английский язык", points = 87 },
                [8] = new Student { surname = "Мошкина", name = "Мария", god_r = 2004, exam = "Информатика", points = 83 },
                [9] = new Student { surname = "Хузина", name = "Карина", god_r = 2003, exam = "Английский язык", points = 95 }
            };
            Console.WriteLine("Напишите, что вы хотите сделать: (Новый студент / Удалить / Сортировать)");
            string s = Console.ReadLine();
            switch (s)
            {
                case "Новый студент":
                    Console.WriteLine("Введите фамилию студента: ");
                    string Surname = Console.ReadLine();
                    Console.WriteLine("Введите имя студента: ");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Введите год рождения студента: ");
                    int God_r = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите экзамен: ");
                    string Exam = Console.ReadLine();
                    Console.WriteLine("Введите баллы: ");
                    int Points = int.Parse(Console.ReadLine());
                    students.Add(10, new Student { surname = Surname, name = Name, god_r = God_r, exam = Exam, points = Points });
                    foreach (var p in students)
                    {
                        Console.WriteLine($"Фамилия: {p.Value.surname}, Имя: {p.Value.name}, Год рождения: {p.Value.god_r}, Экзамен: {p.Value.exam}, Баллы: {p.Value.points} ");
                    }
                    break;
                case "Удалить":
                    Console.WriteLine("Введите фамилию и имя: ");
                    string[] name = Console.ReadLine().Split(' ');
                    var item = students.First(x => x.Value.surname == name[0]);
                    students.Remove(item.Key);
                    foreach (var p in students)
                    {
                        Console.WriteLine($"Фамилия: {p.Value.surname}, Имя: {p.Value.name}, Год рождения: {p.Value.god_r}, Экзамен: {p.Value.exam}, Баллы: {p.Value.points} ");
                    }
                    break;
                case "Сортировать":
                    Console.WriteLine("Отсортированный словарь: \n");
                    var sortedStud = students.OrderBy(x => x.Value.points);
                    foreach (var p in sortedStud)
                    {
                        Console.WriteLine($"Фамилия: {p.Value.surname}, Имя: {p.Value.name}, Год рождения: {p.Value.god_r}, Экзамен: {p.Value.exam}, Баллы: {p.Value.points}  ");
                    }
                    break;
            }
        }
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Задание 1. Словарь студентов");
            Console.WriteLine();
            Students();

            Console.WriteLine();

            Console.WriteLine("Задание 2. Викинги");
            Console.WriteLine();
            Console.WriteLine(Func2());
            */
            Console.WriteLine();
        }
    }
}
