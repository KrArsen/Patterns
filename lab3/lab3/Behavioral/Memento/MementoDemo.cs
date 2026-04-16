using System;
using System.Collections.Generic;
using System.Threading;

namespace BehavioralPatterns.Memento
{
    public class Originator
    {
        private string _state;

        public Originator(string state)
        {
            _state = state;
            Console.WriteLine($"        Originator: My initial state is: {_state}");
        }

        public void DoSomething()
        {
            Console.WriteLine("        Originator: I'm doing something important.");
            _state = GenerateRandomString(30);
            Console.WriteLine($"        Originator: and my state has changed to: {_state}");
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;
            Random rng = new Random();
            while (length > 0)
            {
                result += allowedSymbols[rng.Next(allowedSymbols.Length)];
                length--;
            }
            return result;
        }

        public IMemento Save() => new ConcreteMemento(_state);

        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }
            _state = memento.GetState();
            Console.WriteLine($"        Originator: My state has changed to: {_state}");
        }
    }

    public interface IMemento
    {
        string GetName();
        string GetState();
        DateTime GetDate();
    }

    public class ConcreteMemento : IMemento
    {
        private string _state;
        private DateTime _date;

        public ConcreteMemento(string state)
        {
            _state = state;
            _date = DateTime.Now;
        }

        public string GetState() => _state;
        public string GetName() => $"{_date} / ({_state.Substring(0, 9)}...)";
        public DateTime GetDate() => _date;
    }

    public class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();
        private Originator _originator;

        public Caretaker(Originator originator)
        {
            _originator = originator;
        }

        public void Backup()
        {
            Console.WriteLine("\n        Caretaker: Saving Originator's state...");
            _mementos.Add(_originator.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0) return;
            var memento = _mementos[_mementos.Count - 1];
            _mementos.Remove(memento);
            Console.WriteLine($"        Caretaker: Restoring state to: {memento.GetName()}");
            try
            {
                _originator.Restore(memento);
            }
            catch (Exception)
            {
                Undo();
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("        Caretaker: Here's the list of mementos:");
            foreach (var memento in _mementos)
            {
                Console.WriteLine($"        {memento.GetName()}");
            }
        }
    }

    public static class MementoDemo
    {
        public static void Show()
        {
            Console.WriteLine("    [Memento] ->");
            Originator originator = new Originator("Super-duper-super-puper-super.");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            caretaker.ShowHistory();

            Console.WriteLine("\n        Client: Now, let's rollback!");
            caretaker.Undo();

            Console.WriteLine("\n        Client: Once more!");
            caretaker.Undo();
        }
    }
}
