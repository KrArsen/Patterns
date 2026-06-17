using System;
using System.Diagnostics;

namespace lab5
{
    
    public static class ExecuteAround
    {
       
        public static void ExecuteTimed(Action action, string label)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            Console.WriteLine($"[{label}] виконано за {stopwatch.Elapsed.TotalMilliseconds:F4} мс");
        }

        
        public static void ExecuteWithLogging(Action action, string operationName)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            Console.WriteLine($"Початок: {operationName}");
            action();
            Console.WriteLine($"Кінець: {operationName}");
        }

       
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
