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
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        bool go1 = true;
                        while (go1)
                        {
                            Console.WriteLine("Напишите угол альфа (от -1 до 1; например, 0,87):");
                            double alfa,b;
                            bool parse_alfa=double.TryParse(Console.ReadLine(), out alfa);
                            if (parse_alfa==true&&alfa<=1&&alfa>=-1)
                            {
                                bool bgo=true;
                                while (bgo)
                                {
                                    Console.WriteLine("Напишите число b:");
                                    bool parse_b=double.TryParse(Console.ReadLine(), out b);
                                    if (parse_b==true&&b>0)
                                    {
                                        Console.WriteLine("Вычисляю функцию...");
                                        double cosine = Math.Cos(2 * alfa);
                                        if (cosine>0)
                                        {
                                            go1=false;
                                            bgo=false;
                                            double func = Math.Round(Math.Pow(Math.Sin(Math.Log(b, 5) / Math.Sqrt(cosine)), 2),2);
                                            Console.WriteLine("Ответ записан. Теперь угадайте его! У вас 3 попытки.");
                                            double ansuser;
                                            bool go2 = true;
                                            while (go2)
                                                {
                                                    for (int i=1;i<4;i++)
                                                    {
                                                        Console.WriteLine("Напишите ответ:");
                                                        if (double.TryParse(Console.ReadLine(), out ansuser))
                                                        {
                                                            if (ansuser==func)
                                                                {
                                                                    go2=false;
                                                                    go1=false;
                                                                    Console.WriteLine($"Верно! Ответ: {func}");
                                                                    break;
                                                                }
                                                            else
                                                                {
                                                                    Console.WriteLine($"Неверно! Осталось {3-i} попыток.");
                                                                    if ((3-i)==0)
                                                                        {
                                                                            go2=false;
                                                                            Console.WriteLine($"Попытки законичились!. Ответ:{func}\nВозвращаюсь...");
                                                                        }
                                                                }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Неверное значение! Попробуйте снова.");
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Выражение под корнем в знаменателе получилось меньше нуля или равно нулю! Напишите действительные значения для вычисления .");
                                            }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверное значение! Попробуйте снова.");
                                    }
                                }
                            }
                            else
                                {
                                    Console.WriteLine("Неверное значение! Попробуйте снова.");
                                }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Автор программы: Чегуров Владислав 6105-090301D");
                        break;
                    case "3":
                        int n;
                        Random rand = new Random();
                        bool sort_array=true;
                        while (sort_array)
                        {
                            Console.Write("Напишите размер массива: ");
                            bool sizetrprs=int.TryParse(Console.ReadLine(),out n);
                            if (sizetrprs==true)
                            {
                                int[] array = new int[n];
                                for (int i=0;i<array.Length; i++)
                                {
                                    array[i]=rand.Next(1,100);
                                }
                                string result_array = string.Join(", ", array);
                                Console.Write("Массив: "+result_array+"\n");
                                int[] arrForInsertion = (int[])array.Clone();
                                int[] arrForGnome = (int[])array.Clone();
                                Stopwatch sw = new Stopwatch();
                                sw.Start();
                                InsertionSort(arrForInsertion);
                                sw.Stop();
                                double insertionTime = (double)sw.ElapsedTicks / TimeSpan.TicksPerMicrosecond;
                                sw.Reset();
                                sw.Start();
                                GnomeSort(arrForGnome);
                                sw.Stop();
                                double gnomeTime = (double)sw.ElapsedTicks / TimeSpan.TicksPerMicrosecond;
                                Console.WriteLine($"Сортировка вставками: {insertionTime} мкс");
                                Console.WriteLine($"Гномья сортировка: {gnomeTime} мкс");
                                sort_array=false;
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод! Попробуйте снова.");
                            }
                        }
                    break;
                    case "4":
                        bool goexit = true;
                        while (goexit)
                            {
                                Console.WriteLine("Вы уверены, что хотите выйти? Введите «д» или «н».");
                                string exit = Console.ReadLine();
                                switch (exit)
                                    {
                                        case "д":
                                            go = false;
                                            goexit=false;
                                            Console.WriteLine("До свидания!");
                                            break;
                                        case "н":
                                            goexit=false;
                                            Console.WriteLine("Возвращаюсь...");
                                            break;
                                        default:
                                            Console.WriteLine("Неверное значение!");
                                            break;
                                    }
                            }
                        break;
                    default:
                        Console.WriteLine("Неверное значение! Введите число.");
                        break;
                }
            }
        }
        public static void InsertionSort(int[] arr)
        {
        for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i], j = i - 1;
                while (j >= 0 && arr[j] > key)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = key;
            }
        if (arr.Length>10) Console.WriteLine("Массив не может быть выведен на экран, так как длина массива больше 10!");
        else
            {
            string ins_array = string.Join(", ", arr);
            Console.Write("Массив (Сортировка вставками): "+ins_array+"\n");
            }
        }
        public static void GnomeSort(int[] arr)
        {
        int i = 0;
        while (i < arr.Length)
            {
                if (i == 0 || arr[i] >= arr[i - 1]) i++;
                else
                {
                int temp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = temp;
                i--;
                }
            }
        if (arr.Length>10) Console.WriteLine("Массив не может быть выведен на экран, так как длина массива больше 10!");
        else
            {
            string gnome_array = string.Join(", ", arr);
            Console.Write("Массив (Гномья сортировка): "+gnome_array+"\n");
            }
        }
    }
}