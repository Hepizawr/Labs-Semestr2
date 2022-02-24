using System;
using System.Diagnostics;

namespace LAB
{
    class Program
    {
        public static int[] arr;
        public static Stopwatch sw = new Stopwatch();

        static void Menu()
        {
            int choise, choise1;
            do
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1.Створити масив");
                Console.WriteLine("2.Пошук перебором");
                Console.WriteLine("3.Пошуку з бар'єром");
                Console.WriteLine("4.Бiнарний пошук");
                Console.WriteLine("5.Бiнарний пошук v2.0");
                Console.WriteLine("6.Вивести довжину масиву");
                Console.WriteLine("0.Вихiд з програми");
                Console.Write("Ваш вибiр: ");
                choise = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Як заповнити масив");
                        Console.WriteLine("1.Самостiйно");
                        Console.WriteLine("2.Випадково");
                        Console.WriteLine("3.Випадково за зростанням");
                        Console.WriteLine("0.Повернутися до меню");
                        Console.Write("Ваш вибiр: ");
                        choise = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n");
                        switch (choise)
                        {
                            case 1: Program.MasHand(); break;
                            case 2: Program.MasRnd(); break;
                            case 3: Program.MasRndSort(); break;
                            case 0: Program.Menu(); break;
                        }

                        break;

                    case 2: Program.BFSearch(arr); break;
                    case 3: Program.BarSearch(arr); break;
                    case 4: Program.BinSearch(arr); break;
                    case 5: Program.BinSearchV2(arr); break;
                    case 6: Program.MasLen(arr); break;
                    case 0: break;
                }

            } while (choise != 0);
        }

        static void MasHand()
        {
            Console.Write("\nВведiть довжину масиву");
            int N = Convert.ToInt32(Console.ReadLine());

            arr = new int[N + 1];

            for (int i = 0; i < N; i++)
            {
                Console.Write("Введiть елемент масиву №" + i + ": ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < N; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        static void MasRnd()
        {
            Console.Write("Введiть довжину масиву: ");
            int N = Convert.ToInt32(Console.ReadLine());

            arr = new int[N + 1];
            Random x = new Random();

            for (int i = 0; i < N; i++)
            {
                arr[i] = x.Next(-100, 100);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        static void MasRndSort()
        {
            Console.Write("Введiть довжину масиву: ");
            int N = Convert.ToInt32(Console.ReadLine());

            arr = new int[N + 1];
            Random x = new Random();

            int min = -1 * (10 * N), r, i = 0;

            r = 20;

            while (i < N)
            {
                arr[i] = x.Next(min, min + r);
                min = min + r;
                Console.Write(arr[i] + " ");
                i++;
            }
            Console.WriteLine("\n");
        }

        static void MasLen(int[] LArr)
        {
            Console.WriteLine("Довжина масиву: " + LArr.Length);
            Console.WriteLine("\n");
        }

        static void BFSearch(int[] BFArr)
        {
            Console.Write("Введiть число для пошуку: ");
            int X = Convert.ToInt32(Console.ReadLine());

            int i = 0, num = 0; bool Found = false;

            sw.Start();
            while (i < BFArr.Length - 1 && !Found)
            {
                if (BFArr[i] == X)
                {
                    num = i;
                    Found = true;
                }
                i++;
            }
            sw.Stop();
            if (!Found) Console.WriteLine("Число не знайдено");
            else Console.WriteLine("Число знаходится пiд номером №" + (num + 1));
            Console.WriteLine($"Кiлькiсть затраченого часу:{sw.ElapsedTicks}");
            sw.Reset();
            Console.WriteLine("\n");
        }

        static void BarSearch(int[] BarArr)
        {
            Console.Write("Введiть число для пошуку: ");
            int X = Convert.ToInt32(Console.ReadLine());

            int i = 0, num = 0;

            BarArr[BarArr.Length - 1] = X;
            sw.Start();
            while (BarArr[i] != X)
            {
                i++;
            }
            sw.Stop();
            num = i;
            if (num == BarArr.Length - 1) Console.WriteLine("Число не знайдено");
            else Console.WriteLine("Число знаходится пiд номером №" + (num + 1));
            Console.WriteLine($"Кiлькiсть затраченого часу:{sw.ElapsedTicks}");
            sw.Reset();
            Console.WriteLine("\n");
        }

        static void BinSearch(int[] BinArr)
        {
            Console.Write("Введiть число для пошуку: ");
            int X = Convert.ToInt32(Console.ReadLine());

            int left = 0, mid = 0;
            int right = BinArr.Length - 1;
            int num = 0; bool Found = false;
            sw.Start();
            while ((!(left >= right)) && !Found)
            {
                mid = (left + right) / 2;

                Console.WriteLine(mid);
                if (BinArr[mid] == X)
                {
                    num = mid;
                    Found = true;
                }

                if (BinArr[mid] > X) right = mid;
                else left = mid + 1;
            }
            sw.Stop();
            if (!Found) Console.WriteLine("Число не знайдено");
            else Console.WriteLine("Число знаходится пiд номером №" + (num + 1));
            Console.WriteLine($"Кiлькiсть затраченого часу:{sw.ElapsedTicks}");
            sw.Reset();
            Console.WriteLine("\n");
        }

        static void BinSearchV2(int[] BinArr)
        {
            Console.Write("Введiть число для пошуку: ");
            int X = Convert.ToInt32(Console.ReadLine());

            double left = 0, Dmid = 0;
            int mid = 0;
            int right = BinArr.Length - 2;
            int num = 0; bool Found = false;

            sw.Start();
            while ((!(left >= right)) && !Found)
            {
                Dmid = left + 0.618 * (right - left); 

                mid = Convert.ToInt32(Dmid);

                Console.WriteLine(mid);
                if (BinArr[mid] == X)
                {
                    num = mid;
                    Found = true;
                }

                if (BinArr[mid] > X) right = mid - 1;
                else left = mid;
            }
            sw.Stop();
            if (!Found) Console.WriteLine("Число не знайдено");
            else Console.WriteLine("Число знаходится пiд номером №" + (num + 1));
            Console.WriteLine($"Кiлькiсть затраченого часу:{sw.ElapsedTicks}");
            sw.Reset();
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Program.Menu();
        }

    }
}
