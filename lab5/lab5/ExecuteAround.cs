using System;
using System.Diagnostics;

namespace lab5
{
    /// <summary>
    /// Патерн "Навколишнє виконання" (Execute Around) у функціональному стилі.
    /// Цей патерн вирішує проблему дублювання шаблонного коду до та після виконання
    /// основної операції (наприклад, відкриття/закриття ресурсів, логування початку та завершення,
    /// вимірювання часу виконання тощо). Основна логіка передається через лямбда-функцію.
    /// </summary>
    public static class ExecuteAround
    {
        /// <summary>
        /// а) Вимірювання часу виконання переданого лямбда-виразу (Action).
        /// </summary>
        public static void ExecuteTimed(Action action, string label)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            Console.WriteLine($"[{label}] виконано за {stopwatch.Elapsed.TotalMilliseconds:F4} мс");
        }

        /// <summary>
        /// б) Логування початку та кінця операції навколо переданого лямбда-виразу.
        /// </summary>
        public static void ExecuteWithLogging(Action action, string operationName)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            Console.WriteLine($"Початок: {operationName}");
            action();
            Console.WriteLine($"Кінець: {operationName}");
        }

        /// <summary>
        /// в) Безпечна робота з ресурсом: відкриття, виконання логіки та гарантоване закриття ресурсу.
        /// </summary>
        public static void ExecuteWithResource<T>(Func<T> openResource, Action<T> use, Action<T> closeResource)
        {
            if (openResource == null) throw new ArgumentNullException(nameof(openResource));
            if (use == null) throw new ArgumentNullException(nameof(use));
            if (closeResource == null) throw new ArgumentNullException(nameof(closeResource));

            T resource = openResource();
            try
            {
                use(resource);
            }
            finally
            {
                closeResource(resource);
            }
        }
    }
}
