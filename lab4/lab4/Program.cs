using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Тестові дані
            List<int> intList = new List<int> { 4, 7, 2, 9, 12, 7, 15, 2 };
            List<double> doubleList = new List<double> { 2.5, 4.0, 7.5, 10.0 };
            List<string> stringList1 = new List<string> { "Яблуко", "Банан", "Апельсин", "Груша", "Вишня" };
            List<string> stringList2 = new List<string> { "", "  ", "Сонце", "Зоря", "Хмара" };
            List<string> stringList3 = new List<string> { "Київ", "Львів", "Одеса", "Харків" };

            // Завдання 1: FilterOdd
            List<int> oddNumbers = FilterOdd(intList);
            Console.WriteLine($"Завдання 1: [{string.Join(", ", oddNumbers)}]");

            // Завдання 2: Average
            double averageVal = Average(doubleList);
            Console.WriteLine($"Завдання 2: [{averageVal}]");

            // Завдання 3: SortAlphabetically
            List<string> sortedStrings = SortAlphabetically(stringList1);
            Console.WriteLine($"Завдання 3: [{string.Join(", ", sortedStrings)}]");

            // Завдання 4: SumOfEven
            int sumEven = SumOfEven(intList);
            Console.WriteLine($"Завдання 4: [{sumEven}]");

            // Завдання 5: Factorial
            int factorialInput = 5;
            long factResult = Factorial(factorialInput);
            Console.WriteLine($"Завдання 5: [{factResult}]");

            // Завдання 6: MultiplyAndSum
            var (product, sum) = MultiplyAndSum(new List<int> { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Завдання 6: [Добуток: {product}, Сума: {sum}]");

            // Завдання 7: SquareAll
            List<int> squared = SquareAll(new List<int> { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Завдання 7: [{string.Join(", ", squared)}]");

            // Завдання 8: SortByLength
            List<string> sortedByLength = SortByLength(stringList1);
            Console.WriteLine($"Завдання 8: [{string.Join(", ", sortedByLength)}]");

            // Завдання 9: CountWords
            string sentence = "Лямбда вирази та LINQ це надзвичайно зручно";
            int wordCount = CountWords(sentence);
            Console.WriteLine($"Завдання 9: [{wordCount}]");

            // Завдання 10: FirstNonEmpty
            string? firstNonEmpty = FirstNonEmpty(stringList2);
            Console.WriteLine($"Завдання 10: [{firstNonEmpty}]");

            // Завдання 11: AllStartWithUpperCase
            bool allUpper = AllStartWithUpperCase(stringList3);
            Console.WriteLine($"Завдання 11: [{allUpper}]");

            // Завдання 12: SecondLargest
            int secondLargest = SecondLargest(intList);
            Console.WriteLine($"Завдання 12: [{secondLargest}]");

            // Завдання 13: LargestEven
            int largestEven = LargestEven(intList);
            Console.WriteLine($"Завдання 13: [{largestEven}]");
        }

        // 1. FilterOdd — відфільтрувати непарні числа зі списку (залишити лише непарні)
        public static List<int> FilterOdd(List<int> numbers)
        {
            return numbers.Where(n => n % 2 != 0).ToList();
        }

        // 2. Average — знайти середнє зі списку дійсних чисел
        public static double Average(List<double> numbers)
        {
            return numbers.Any() ? numbers.Average() : 0.0;
        }

        // 3. SortAlphabetically — відсортувати рядки алфавітно
        public static List<string> SortAlphabetically(List<string> strings)
        {
            return strings.OrderBy(s => s).ToList();
        }

        // 4. SumOfEven — сума всіх парних чисел
        public static int SumOfEven(List<int> numbers)
        {
            return numbers.Where(n => n % 2 == 0).Sum();
        }

        // 5. Factorial — факторіал числа через Enumerable.Range та Aggregate
        public static long Factorial(int n)
        {
            return Enumerable.Range(1, n).Aggregate(1L, (acc, x) => acc * x);
        }

        // 6. MultiplyAndSum — добуток усіх елементів через Aggregate та сума через Sum (окремо)
        public static (long Product, int Sum) MultiplyAndSum(List<int> numbers)
        {
            long product = numbers.Aggregate(1L, (acc, x) => acc * x);
            int sum = numbers.Sum();
            return (product, sum);
        }

        // 7. SquareAll — квадрат кожного числа через Select
        public static List<int> SquareAll(List<int> numbers)
        {
            return numbers.Select(x => x * x).ToList();
        }

        // 8. SortByLength — сортування рядків за довжиною у порядку зростання
        public static List<string> SortByLength(List<string> strings)
        {
            return strings.OrderBy(s => s.Length).ToList();
        }

        // 9. CountWords — кількість слів у реченні (розділені пробілами) через Split + Count
        public static int CountWords(string sentence)
        {
            return sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();
        }

        // 10. FirstNonEmpty — перший непорожній рядок через FirstOrDefault
        public static string? FirstNonEmpty(List<string> strings)
        {
            return strings.FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
        }

        // 11. AllStartWithUpperCase — перевірити через All, чи всі рядки починаються з великої літери (char.IsUpper)
        public static bool AllStartWithUpperCase(List<string> strings)
        {
            return strings.All(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
        }

        // 12. SecondLargest — друге за величиною число через OrderByDescending + Distinct + Skip(1).First()
        public static int SecondLargest(List<int> numbers)
        {
            return numbers.OrderByDescending(n => n).Distinct().Skip(1).First();
        }

        // 13. LargestEven — найбільше парне число через Where + Max
        public static int LargestEven(List<int> numbers)
        {
            return numbers.Where(n => n % 2 == 0).Max();
        }
    }
}