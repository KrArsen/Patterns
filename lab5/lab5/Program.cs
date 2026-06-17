using System;
using System.Collections.Generic;

namespace lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("=== Патерн: Стратегія ===");
            List<int> numbers = new List<int> { 5, -2, 12, -8, 0, 7 };
            Console.WriteLine($"Вхідний список: {string.Join(", ", numbers)}");
            
            Func<int, int, int> ascending = (a, b) => a.CompareTo(b);
            Func<int, int, int> descending = (a, b) => b.CompareTo(a);
            Func<int, int, int> byAbs = (a, b) => Math.Abs(a).CompareTo(Math.Abs(b));
            
            var sortedAsc = StrategyPattern.Sort(numbers, (a, b) => ascending(a, b));
            var sortedDesc = StrategyPattern.Sort(numbers, (a, b) => descending(a, b));
            var sortedAbs = StrategyPattern.Sort(numbers, (a, b) => byAbs(a, b));

            Console.WriteLine($"Сортування за зростанням: {string.Join(", ", sortedAsc)}");
            Console.WriteLine($"Сортування за спаданням: {string.Join(", ", sortedDesc)}");
            Console.WriteLine($"Сортування за модулем: {string.Join(", ", sortedAbs)}");
            Console.WriteLine();
            
            Console.WriteLine("=== Патерн: Фабричний метод ===");
          
            var factory = FactoryPattern.GetShapeFactory();
            
            foreach (var key in factory.Keys)
            {
                Shape shape = factory[key]();
                Console.WriteLine($"Фабрика створила: {shape.Name}, обчислена площа = {shape.Area():F2}");
            }
            Console.WriteLine();
            
            Console.WriteLine("=== Патерн: Декоратор ===");
            
            Func<string, string> trim = DecoratorPattern.Trim;
            Func<string, string> toUpper = DecoratorPattern.ToUpper;
            Func<string, string> exclaim = DecoratorPattern.Exclaim;
            
            Func<string, string> pipeline = trim.Then(toUpper).Then(exclaim);
            
            string testString = "    Привіт, функціональні патерни    ";
            string decoratedResult = pipeline(testString);
            
            Console.WriteLine($"Вхідний рядок: \"{testString}\"");
            Console.WriteLine($"Результат обробки (декорування): \"{decoratedResult}\"");
            Console.WriteLine();
            
            Console.WriteLine("=== Патерн: Execute Around ===");
            
            ExecuteAround.ExecuteTimed(() =>
            {
                var rand = new Random();
                var bigList = new List<int>();
                for (int i = 0; i < 50000; i++)
                {
                    bigList.Add(rand.Next());
                }
                bigList.Sort();
            }, "Сортування 50,000 чисел");
            Console.WriteLine();
            
            ExecuteAround.ExecuteWithLogging(() =>
            {
                int a = 125;
                int b = 375;
                int sum = a + b;
                Console.WriteLine($"[Лог-Контекст] Обчислення виконано: {a} + {b} = {sum}");
            }, "Додавання двох чисел");
            Console.WriteLine();
            
            Func<string> openDb = () =>
            {
                Console.WriteLine("[БД Ресурс] Відкриваємо з'єднання з базою даних...");
                return "Active_DB_Connection_Session_XYZ_987";
            };
            
            Action<string> queryDb = connection =>
            {
                Console.WriteLine($"[БД Ресурс] Виконуємо SELECT * FROM Users; через з'єднання: {connection}");
            };
            
            Action<string> closeDb = connection =>
            {
                Console.WriteLine($"[БД Ресурс] Безпечно закриваємо з'єднання: {connection}");
            };

            ExecuteAround.ExecuteWithResource(openDb, queryDb, closeDb);
            Console.WriteLine();
        }
    }
}