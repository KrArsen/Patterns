using System;

namespace BehavioralPatterns.ChainOfResponsibility
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        string Handle(string request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual string Handle(string request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            return null;
        }
    }

    public class MonkeyHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request == "Banana")
                return $"Monkey: I'll eat the {request}.\n";
            return base.Handle(request);
        }
    }

    public class SquirrelHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request == "Nut")
                return $"Squirrel: I'll eat the {request}.\n";
            return base.Handle(request);
        }
    }

    public class DogHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request == "MeatBall")
                return $"Dog: I'll eat the {request}.\n";
            return base.Handle(request);
        }
    }

    public static class ChainOfResponsibilityDemo
    {
        public static void Show()
        {
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            Console.WriteLine("    [Chain of Responsibility] -> ");
            foreach (var food in new string[] { "Nut", "Banana", "Cup of coffee" })
            {
                var result = monkey.Handle(food);
                if (result != null)
                {
                    Console.Write($"        {result}");
                }
                else
                {
                    Console.WriteLine($"        {food} was left untouched.");
                }
            }
        }
    }
}
