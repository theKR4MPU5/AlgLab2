using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleHanoiTower
{
    class Program
    {
        //Создаем список алгоритмов для сортировки.
        static void Main(string[] args)
        {
            Instrument.ConductResearch(new HanoiTower(), 30);
        }
    }

    class Instrument
    {
        //Создающем массив заданного размера со случайными значениями.
        public static int[] GenerateArray(int numberOfDisks)
        {
            int[] array = new int[numberOfDisks];
            for (int i = 0; i < numberOfDisks; i++)
                array[i] = i + 1;
            return array;
        }

        //Измеряем время выполнения алгоритма.
        public static long MeasureTime(int[] array, Enumeration algorithm)
        {
            Random random = new Random();
            Stopwatch watch = new Stopwatch();
            algorithm.AlgRun(array, array.Length);
            watch.Start();
            algorithm.AlgRun(array, array.Length);
            watch.Stop();
            return watch.ElapsedTicks / 100;
        }

        //Метод для тестирования
        public static void ConductResearch(Enumeration algorithm, int maxNumberOfDisks, bool sorted = false)
        {
            List<(int, long)> results = new List<(int, long)>();
            results.Add((-1, sorted ? 1 : 0));

            for (int numberOfDisks = 1; numberOfDisks <= maxNumberOfDisks; numberOfDisks++)
            {
                long totalTime = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Проверка кол-ва колец для {algorithm.Name}: {numberOfDisks}");
                    totalTime += MeasureTime(GenerateArray(numberOfDisks), algorithm);
                }

                long averageTime = totalTime / 5;
                results.Add((numberOfDisks, averageTime));
            }

            Console.WriteLine("Выполнено!");
            ExportAsCsv(results, algorithm);
        }


        //Метод, который записывает наши данные в файл
        private static void ExportAsCsv(List<(int, long)> researches, Enumeration algorithm)
        {
            string path =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{algorithm.Name}_{DateTime.Now.ToString("yyyy-M-dd")}.csv";


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tested algorithm:;{algorithm.GetType().Name}({algorithm.Name})");
            sb.AppendLine($"Dimension (elements);Spent time (µs)");
            foreach (var pos in researches)
                sb.AppendLine($"{pos.Item1};{pos.Item2}");
            File.WriteAllText(path, sb.ToString());
            Console.WriteLine($"File saved at: {path}");
        }
    }

    //Абстрактный класс, для алгоритмов, которые будут тестироваться.
    public abstract class Enumeration
    {
        //Принимаем размер и имя в конструктор.
        protected Enumeration(int size, string name)
        {
            TestArray = GenerateArray(size);
            Name = name;
        }
        //Создаем массив по заданным размерам.
        private int[] GenerateArray(int size)
        {
            int[] dimensions = new int[size];
            for (int i = 0; i < dimensions.Length; i++)
            {
                dimensions[i] = i + 1;
            }

            return dimensions;
        }
        //Абстрактный метод, который реализуется в классах наследках.
        public abstract void AlgRun(int[] array, int value = 0);

        public int[] TestArray { get; }
        //Имя, которое отображается в экспортном файле.
        public string Name { get; }
    }
    //static void TowerOfHanoi(int n, char source, char destination, char auxiliary)
    //{
    //    if (n == 1)
    //    {
    //        //Console.WriteLine($"Переместить диск 1 с {source} на {destination}");
    //        return;
    //    }

    //    TowerOfHanoi(n - 1, source, auxiliary, destination);
    //    //Console.WriteLine($"Переместить диск {n} с {source} на {destination}");
    //    TowerOfHanoi(n - 1, auxiliary, destination, source);
    //}

    //static long MeasureHanoiPerformance(int n)
    //{
    //    var watch = new Stopwatch();
    //    watch.Start();
    //    TowerOfHanoi(n, 'A', 'C', 'B');
    //    watch.Stop();
    //    return watch.ElapsedMilliseconds;
    //}
}