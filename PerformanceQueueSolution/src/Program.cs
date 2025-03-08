using System;
using System.Diagnostics;
using DataStructures;
using Utils;

namespace HighPerformanceQueueSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benchmark Senaryosu: İş Görevlerinin Yönetimi");
            Console.Write("Lütfen işlem sayısını giriniz (örneğin, 10000): ");
            int operations;
            while (!int.TryParse(Console.ReadLine(), out operations) || operations <= 0)
            {
                Console.Write("Geçerli bir sayı giriniz: ");
            }

            Console.WriteLine("\n--- Benchmark Sonuçları ---\n");

            // Benchmark 1: Naif Key-Value List (Liste üzerinden ekle/sil)
            Console.WriteLine("Benchmark 1: Naif Key-Value List");
            var naiveList = new NaiveKeyValueList("NaiveList");
            RunBenchmark(naiveList, i => i, i => "Task" + i, operations);

            // Benchmark 2: HybridQueueStack (Dictionary + Doubly Linked List, Normal Dağıtım)
            Console.WriteLine("\nBenchmark 2: HybridQueueStack (Normal Dağıtım)");
            var hybridNormal = new HybridQueueStackDLL<int, string>("HybridNormal");
            RunBenchmark(hybridNormal, i => i, i => "Task" + i, operations);

            // Benchmark 3: HybridQueueStack (Dictionary + Doubly Linked List, Bilerek Çakışma)
            Console.WriteLine("\nBenchmark 3: HybridQueueStack (Collision - CollidingKey)");
            var hybridCollision = new HybridQueueStackDLL<CollidingKey, string>("HybridCollision");
            RunBenchmark(hybridCollision, i => new CollidingKey(i), i => "Task" + i, operations);

            // Benchmark 4: SortedDictionary Tabanlı HybridQueueStack (Çakışma - CollidingKey)
            Console.WriteLine("\nBenchmark 4: HybridQueueStackRB (SortedDictionary / Red–Black Tree, Collision)");
            var hybridRB = new HybridQueueStackRB<CollidingKey, string>("HybridRB");
            RunBenchmark(hybridRB, i => new CollidingKey(i), i => "Task" + i, operations);

            Console.WriteLine("\nBenchmark tamamlandı. Çıkmak için bir tuşa basınız...");
            Console.ReadKey();
        }

        /// <summary>
        /// Belirtilen kuyruk yapısı için ekleme ve silme işlemlerini benchmark eder.
        /// </summary>
        /// <typeparam name="TKey">Anahtar tipi</typeparam>
        /// <typeparam name="TValue">Değer tipi</typeparam>
        /// <param name="queue">Kuyruk veri yapısı</param>
        /// <param name="keySelector">İşlem için anahtar üreten fonksiyon</param>
        /// <param name="valueSelector">İşlem için değer üreten fonksiyon</param>
        /// <param name="ops">Toplam işlem sayısı</param>
        static void RunBenchmark<TKey, TValue>(dynamic queue, Func<int, TKey> keySelector, Func<int, TValue> valueSelector, int ops)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < ops; i++)
            {
                TKey key = keySelector(i);
                TValue value = valueSelector(i);
                queue.Add(key, value);
            }
            while (!queue.IsEmpty())
            {
                queue.Dequeue();
            }
            sw.Stop();
            Console.WriteLine($"{queue.Name} Benchmark: {sw.ElapsedMilliseconds} ms");
        }
    }
}
