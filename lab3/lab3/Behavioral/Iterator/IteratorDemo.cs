using System;
using System.Collections;
using System.Collections.Generic;

namespace BehavioralPatterns.Iterator
{
    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();
        public abstract int Key();
        public abstract object Current();
        public abstract bool MoveNext();
        public abstract void Reset();
    }

    public abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    public class AlphabeticalOrderIterator : Iterator
    {
        private WordsCollection _collection;
        private int _position = -1;
        private bool _reverse;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
        {
            _collection = collection;
            _reverse = reverse;
            if (reverse)
                _position = collection.GetItems().Count;
        }

        public override object Current() => _collection.GetItems()[_position];
        public override int Key() => _position;

        public override bool MoveNext()
        {
            int updatedPosition = _position + (_reverse ? -1 : 1);
            if (updatedPosition >= 0 && updatedPosition < _collection.GetItems().Count)
            {
                _position = updatedPosition;
                return true;
            }
            return false;
        }

        public override void Reset() => _position = _reverse ? _collection.GetItems().Count - 1 : 0;
    }

    public class WordsCollection : IteratorAggregate
    {
        List<string> _collection = new List<string>();
        bool _direction = false;

        public void ReverseDirection() => _direction = !_direction;
        public List<string> GetItems() => _collection;
        public void AddItem(string item) => _collection.Add(item);

        public override IEnumerator GetEnumerator() => new AlphabeticalOrderIterator(this, _direction);
    }

    public static class IteratorDemo
    {
        public static void Show()
        {
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("    [Iterator] -> Straight traversal:");
            Console.Write("        ");
            foreach (var element in collection)
            {
                Console.Write(element + " ");
            }
            
            Console.WriteLine("\n        Reverse traversal:");
            collection.ReverseDirection();
            Console.Write("        ");
            foreach (var element in collection)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
