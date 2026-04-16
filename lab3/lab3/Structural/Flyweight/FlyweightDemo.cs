using System;
using System.Collections.Generic;
using System.Linq;

namespace StructuralPatterns.Flyweight
{
    public class Flyweight
    {
        private string _sharedState;
        public Flyweight(string sharedState) { _sharedState = sharedState; }
        public string Operation(string uniqueState) => $"Flyweight: Displaying shared {_sharedState} and unique {uniqueState}.";
    }

    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params string[] args)
        {
            foreach (var elem in args)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), elem));
            }
        }

        public Flyweight GetFlyweight(string sharedState)
        {
            if (flyweights.Where(t => t.Item2 == sharedState).Count() == 0)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), sharedState));
            }
            return flyweights.First(t => t.Item2 == sharedState).Item1;
        }
    }

    public static class FlyweightDemo
    {
        public static void Show()
        {
            var factory = new FlyweightFactory("A", "B");
            var flyweight = factory.GetFlyweight("A");
            Console.WriteLine("    [Flyweight] -> " + flyweight.Operation("X"));
        }
    }
}
