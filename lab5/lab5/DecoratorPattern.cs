using System;

namespace lab5
{
    /// <summary>
    /// Патерн "Декоратор" (Decorator) у функціональному стилі.
    /// Замість класичної ієрархії обгорток над об'єктами, декоратори представляють собою
    /// функції вищого порядку Func&lt;string, string&gt;. Їх поєднання відбувається за допомогою
    /// композиції функцій.
    /// </summary>
    public static class DecoratorPattern
    {
        // Базові декоратори (функції обробки рядків)
        public static readonly Func<string, string> Trim = s => s.Trim();
        public static readonly Func<string, string> ToUpper = s => s.ToUpper();
        public static readonly Func<string, string> Exclaim = s => s + "!!!";
    }

    /// <summary>
    /// Розширення для ланцюгового виклику декораторів (композиції функцій).
    /// </summary>
    public static class DecoratorExtensions
    {
        /// <summary>
        /// Дозволяє ланцюгово об'єднувати функції обробки тексту: спочатку застосовується f, потім g.
        /// Математично це композиція: (g ∘ f)(x) = g(f(x))
        /// </summary>
        public static Func<string, string> Then(this Func<string, string> f, Func<string, string> g)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            if (g == null) throw new ArgumentNullException(nameof(g));
            
            return x => g(f(x));
        }
    }
}
