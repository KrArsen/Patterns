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
            
            List<int> intList = new List<int> { 4, 7, 2, 9, 12, 7, 15, 2 };
            List<double> doubleList = new List<double> { 2.5, 4.0, 7.5, 10.0 };
            List<string> stringList1 = new List<string> { "Яблуко", "Банан", "Апельсин", "Груша", "Вишня" };
            List<string> stringList2 = new List<string> { "", "  ", "Сонце", "Зоря", "Хмара" };
            List<string> stringList3 = new List<string> { "Київ", "Львів", "Одеса", "Харків" };
            
            List<int> oddNumbers = FilterOdd(intList);
            Console.WriteLine($"Завдання 1: [{string.Join(", ", oddNumbers)}]");
            
            double averageVal = Average(doubleList);
            Console.WriteLine($"Завдання 2: [{averageVal}]");
            
            List<string> sortedStrings = SortAlphabetically(stringList1);
            Console.WriteLine($"Завдання 3: [{string.Join(", ", sortedStrings)}]");
            
            int sumEven = SumOfEven(intList);
            Console.WriteLine($"Завдання 4: [{sumEven}]");
            
            int factorialInput = 5;
            long factResult = Factorial(factorialInput);
            Console.WriteLine($"Завдання 5: [{factResult}]");
            
            var (product, sum) = MultiplyAndSum(new List<int> { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Завдання 6: [Добуток: {product}, Сума: {sum}]");
            
            List<int> squared = SquareAll(new List<int> { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Завдання 7: [{string.Join(", ", squared)}]");
            
            List<string> sortedByLength = SortByLength(stringList1);
            Console.WriteLine($"Завдання 8: [{string.Join(", ", sortedByLength)}]");
            
            string sentence = "Лямбда вирази та LINQ це надзвичайно зручно";
            int wordCount = CountWords(sentence);
            Console.WriteLine($"Завдання 9: [{wordCount}]");
            
            string? firstNonEmpty = FirstNonEmpty(stringList2);
            Console.WriteLine($"Завдання 10: [{firstNonEmpty}]");
            
            bool allUpper = AllStartWithUpperCase(stringList3);
            Console.WriteLine($"Завдання 11: [{allUpper}]");
            
            int secondLargest = SecondLargest(intList);
            Console.WriteLine($"Завдання 12: [{secondLargest}]");
            
            int largestEven = LargestEven(intList);
            Console.WriteLine($"Завдання 13: [{largestEven}]");
        }
        
        public static List<int> FilterOdd(List<int> numbers)
        {
            return numbers.Where(n => n % 2 != 0).ToList();
        }
        
        public static double Average(List<double> numbers)
        {
            return numbers.Any() ? numbers.Average() : 0.0;
        }
        
        public static List<string> SortAlphabetically(List<string> strings)
        {
            return strings.OrderBy(s => s).ToList();
        }
        
        public static int SumOfEven(List<int> numbers)
        {
            return numbers.Where(n => n % 2 == 0).Sum();
        }
        
        public static long Factorial(int n)
        {
            return Enumerable.Range(1, n).Aggregate(1L, (acc, x) => acc * x);
        }
        
        public static (long Product, int Sum) MultiplyAndSum(List<int> numbers)
        {
            long product = numbers.Aggregate(1L, (acc, x) => acc * x);
            int sum = numbers.Sum();
            return (product, sum);
        }
        
        public static List<int> SquareAll(List<int> numbers)
        {
            return numbers.Select(x => x * x).ToList();
        }
        
        public static List<string> SortByLength(List<string> strings)
        {
            return strings.OrderBy(s => s.Length).ToList();
        }
        
        public static int CountWords(string sentence)
        {
            return sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();
        }
        
        public static string? FirstNonEmpty(List<string> strings)
        {
            return strings.FirstOrDefault(s => !string.IsNullOrWhiteSpace(s));
        }

        public static bool AllStartWithUpperCase(List<string> strings)
        {
            return strings.All(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
        }
        
        public static int SecondLargest(List<int> numbers)
        {
            return numbers.OrderByDescending(n => n).Distinct().Skip(1).First();
        }

        public static int LargestEven(List<int> numbers)
        {
            return numbers.Where(n => n % 2 == 0).Max();
        }
    }
}