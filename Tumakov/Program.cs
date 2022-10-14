using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

namespace Tumakov
{
    internal class Program
    {
        public static void gl_sogl(string bukvi)
        {
            int count = 0, kol = 0;
            for (int i = 0; i < bukvi.Length; i++)
            {
                if (bukvi[i] == 'a' || bukvi[i] == 'e' || bukvi[i] == 'y' || bukvi[i] == 'o' || bukvi[i] == 'u' || bukvi[i] == 'i')
                {
                    count++;
                }
                else
                {
                    kol++;
                }
            }
            Console.WriteLine($"Количесвто гласных: {count}, количество согласных: {kol}");
        }
        public static void PrintMatr(int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(matr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static void ProizvMatr(int[,] matr1, int[,] matr2)
        {
            int[,] r = new int[matr1.GetLength(0), matr2.GetLength(1)];
            for (int i = 0; i < matr1.GetLength(0); i++)
            {
                for (int j = 0; j < matr2.GetLength(1); j++)
                {
                    for (int k = 0; k < matr2.GetLength(0); k++)
                    {
                        r[i, j] += matr1[i, k] * matr2[k, j];
                    }
                }
            }
            Console.WriteLine("Произведение матриц: ");
            PrintMatr(r);
        }
        public static void SrTemp(int[,] matr)
        {
            int sum = 0;
            double sr_ar = 1;
            double[] sr_znach = new double[12];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    sum += matr[i, j];
                    sr_ar = sum / 30;
                }
                sr_znach[i] = Math.Round(sr_ar);
                Console.WriteLine($"Средняя температура в {i + 1} месяце: {Math.Round(sr_ar)}");
            }
            for (int i = 0; i < sr_znach.Length; i++)
            {
                for (int j = 0; j < sr_znach.Length - 1; j++)
                {
                    if (sr_znach[j] > sr_znach[j + 1])
                    {
                        double z = sr_znach[j];
                        sr_znach[j] = sr_znach[j + 1];
                        sr_znach[j + 1] = z;
                    }
                }
            }
            Console.WriteLine("Отсортированные значения температур: ");
            for (int i = 0; i < sr_znach.Length; i++)
            {
                Console.WriteLine(sr_znach[i] + " ");
            }
        }
        static int GetCountWithList(List<char> list, char[] letter)
        {
            int Count = 0;
            foreach (char i in list)
            {
                foreach (char j in letter)
                {
                    if (i == j)
                        Count++;
                }
            }
            return Count;
        }
        enum months
        {
            январь = 1, февраль = 2, март = 3, апрель = 4, май = 5, июнь = 6, июль = 7, август = 8, сентябрь = 9, октябрь = 10, ноябрь = 11, декабрь = 12
        }
        static int Averagetemper(int[] array, ref int[] sr_znach)
        {
            double sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum = array[i]++;
            }
            Array.Sort(sr_znach);
            return (int)Math.Round(sum / 12);
        }
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Задание 1. Число гласных и согласных в файле");
            Console.WriteLine();
            string path = (@"C:\Users\Амир Сагдуллин\source\repos\TextFile1.txt");
            string bukvi = File.ReadAllText(path);
            gl_sogl(bukvi);

            Console.WriteLine();
            
            Console.WriteLine("Задание 2. Умножение матриц");
            Console.WriteLine();
            int[,] matr1 = new int[2,2];
            Random rand = new Random();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matr1[i,j] = rand.Next(0, 100);
                }
            }
            PrintMatr(matr1);
            Console.WriteLine();
            int[,] matr2 = new int[2, 2];
            Random rnd = new Random();
            for (int k = 0; k < 2; k++)
            {
                for (int p = 0; p < 2; p++)
                {
                    matr2[k, p] = rnd.Next(0, 100);
                }
            }
            PrintMatr(matr2);
            ProizvMatr(matr1, matr2);

            Console.WriteLine();
            
            Console.WriteLine("Задание 3. Средняя температура за год");
            Console.WriteLine();
            int [,] matr = new int[12, 30];
            Random r = new Random();
            for (int i=0; i < 12; i++)
            {
                for (int j=0; j < 30; j++)
                {
                    matr[i, j] = r.Next(-40, 40);
                    Console.Write(matr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            SrTemp(matr);
            
            Console.WriteLine();

            Console.WriteLine("Задание 1. С помощью листа");
            Console.WriteLine();
            char[] glasn = "aeyuio".ToCharArray();
            char[] soglasn = "qwrtpsdfghjklzxcvbnm".ToCharArray();
            string path = File.ReadAllText(@"C:\Users\Амир Сагдуллин\source\repos\TextFile1.txt");
            char[] file = path.ToCharArray();
            List<char> list = new List<char>();
            for (int i = 0; i < file.Length; i++)
            {
                list.Add(file[i]);
            }
            Console.WriteLine($"Гласных в файле: {GetCountWithList(list, glasn)} \nCогласных в файле: {GetCountWithList(list, soglasn)}");
            */
            Console.WriteLine();

            Console.WriteLine("Задание 3. С помощью словаря");
            Console.WriteLine();
            Random temp = new Random();
            int[] day = new int[30];
            int[] month = new int[12];
            Dictionary<months, int[]> weather = new Dictionary<months, int[]>();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    day[j] = temp.Next(-30, 30);
                }
                Console.WriteLine($"Средняя температура в месяце {(months)(i + 1)} - {Averagetemper(day, ref month)}");
                weather.Add((months)(i + 1), day);
                month[i] = Averagetemper(day, ref month);
            }
            Console.WriteLine("Отсортированный массив средних температур месяцов: ");
            foreach (int a in month)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }
    }
}
