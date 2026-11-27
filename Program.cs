using System;
using System.Diagnostics;
namespace code
{
    class Program
    {
        public static void Main()
        {
            bool go = true;
            while (go)
            {
                Console.WriteLine("Привет! Выбери пункты:\n1. Отгадай ответ\n2. Об авторе\n3. Сортировка массива\n4. Выход");
                switch (Console.ReadLine())
                {
                    case "1": M1();
                    break;
                    case "2": M2();
                    break;
                    case "3": M3();
                    break;
                    case "4": if (M4())
                    {
                        go = false;
                    }
                    break;
                    default: Console.WriteLine("Неверное значение! Введите число.");
                    break;
                }
            }
        }
        public static void M1()
        {            
            double a;
            Console.WriteLine("Напишите угол альфа (от -1 до 1; например, 0,87):");
            while (!double.TryParse(Console.ReadLine(), out a) || a > 1 || a < -1)
            {
                Console.WriteLine("Неверное значение! Попробуйте снова.");
            }
            double b;
            Console.WriteLine("Напишите число b:");
            while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.WriteLine("Неверное значение! Попробуйте снова.");
            }
            Console.WriteLine("Вычисляю функцию...");
            double c = Math.Cos(2 * a);
            double f = Math.Round(Math.Pow(Math.Sin(Math.Log(b, 5) / Math.Sqrt(c)), 2), 2);
            Console.WriteLine("Ответ записан. Теперь угадайте его! У вас 3 попытки.");
            int tries = 3;
            while (tries > 0)
            {
                Console.WriteLine("Напишите ответ:");
                double u;
                if (double.TryParse(Console.ReadLine(), out u))
                {
                    if (u == f)
                    {
                        Console.WriteLine($"Верно! Ответ: {f}");
                        return;
                    }
                    tries--;
                    Console.WriteLine($"Неверно! Осталось {tries} попыток.");
                }
                else Console.WriteLine("Неверное значение! Попробуйте снова.");
            }
            Console.WriteLine($"Попытки закончились! Ответ: {f}\nВозвращаюсь...");
        }
        public static void M2() 
        {
            Console.WriteLine("Автор программы: Чегуров Владислав 6105-090301D");
        }
        public static void M3()
        {
            Random r = new Random();
            bool sa = true;
            while (sa)
            {
                int n;
                Console.Write("Напишите размер массива: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    int[] arr = new int[n];
                    for (int i = 0; i < arr.Length; i++) arr[i] = r.Next(1, 100);
                    Console.Write("Массив: " + string.Join(", ", arr) + "\n");
                    int[] a1 = (int[])arr.Clone();
                    int[] a2 = (int[])arr.Clone();
                    Stopwatch sw = new Stopwatch();
                    sw.Start(); InsertionSort(a1); sw.Stop();
                    double t1 = (double)sw.ElapsedTicks / TimeSpan.TicksPerMicrosecond;
                    sw.Reset();
                    sw.Start();
                    GnomeSort(a2);
                    sw.Stop();
                    double t2 = (double)sw.ElapsedTicks / TimeSpan.TicksPerMicrosecond;
                    Console.WriteLine($"Сортировка вставками: {t1} мкс");
                    Console.WriteLine($"Гномья сортировка: {t2} мкс");
                    PrintArr(a1, "Сортировка вставками");
                    PrintArr(a2, "Гномья сортировка");
                    sa = false;
                }
                else Console.WriteLine("Неверный ввод! Попробуйте снова.");
            }
        }
        public static bool M4()
        {
            while (true)
            {
                Console.WriteLine("Вы уверены, что хотите выйти? Введите «д» или «н».");
                string s = Console.ReadLine();
                if (s == "д") 
                {
                    Console.WriteLine("До свидания!");
                    return true;
                }
                if (s == "н") 
                {
                    Console.WriteLine("Возвращаюсь...");
                    return false;
                }
                Console.WriteLine("Неверное значение!");
            }
        }
        public static void PrintArr(int[] arr, string name)
        {
            if (arr.Length > 10) Console.WriteLine("Массив не может быть выведен на экран, так как длина массива больше 10!");
            else Console.Write($"Массив ({name}): " + string.Join(", ", arr) + "\n");
        }
        public static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int k = arr[i], j = i - 1;
                while (j >= 0 && arr[j] > k)
                { 
                    arr[j + 1] = arr[j]; 
                    j--; 
                }
                arr[j + 1] = k;
            }
        }
        public static void GnomeSort(int[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                if (i == 0 || arr[i] >= arr[i - 1]) i++;
                else { int t = arr[i]; arr[i] = arr[i - 1]; arr[i - 1] = t; i--; }
            }
        }
    }
}
