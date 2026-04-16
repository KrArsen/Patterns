using System;

namespace BehavioralPatterns.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class SimpleCommand : ICommand
    {
        private string _payload;

        public SimpleCommand(string payload)
        {
            _payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"        SimpleCommand: See, I can do simple things like printing ({_payload})");
        }
    }

    public class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            _receiver = receiver;
            _a = a;
            _b = b;
        }

        public void Execute()
        {
            Console.WriteLine("        ComplexCommand: Complex stuff should be done by a receiver object.");
            _receiver.DoSomething(_a);
            _receiver.DoSomethingElse(_b);
        }
    }

    public class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"        Receiver: Working on ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"        Receiver: Also working on ({b}.)");
        }
    }

    public class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            _onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            _onFinish = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("    [Command] -> Invoker: Does anybody want something done before I begin?");
            if (_onStart != null) _onStart.Execute();
            
            Console.WriteLine("        Invoker: ...doing something really important...");
            
            Console.WriteLine("        Invoker: Does anybody want something done after I finish?");
            if (_onFinish != null) _onFinish.Execute();
        }
    }

    public static class CommandDemo
    {
        public static void Show()
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
        }
    }
}
