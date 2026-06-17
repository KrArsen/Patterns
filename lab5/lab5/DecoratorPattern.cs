using System;

namespace lab5
{
    
    public static class DecoratorPattern
    {
        public static readonly Func<string, string> Trim = s => s.Trim();
        public static readonly Func<string, string> ToUpper = s => s.ToUpper();
        public static readonly Func<string, string> Exclaim = s => s + "!!!";
    }

   
    public static class DecoratorExtensions
    {
       
        public static Func<string, string> Then(this Func<string, string> f, Func<string, string> g)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            if (g == null) throw new ArgumentNullException(nameof(g));
            
            return x => g(f(x));
        }
    }
}
