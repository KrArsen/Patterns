using System.Collections.Generic;

namespace StructuralPatterns.Composite
{
    public abstract class Component
    {
        protected string name;
        public Component(string name) { this.name = name; }
        public abstract string Operation();
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public override string Operation() => $"Leaf {name}";
    }

    public class Composite : Component
    {
        private List<Component> _children = new List<Component>();
        public Composite(string name) : base(name) { }
        public void Add(Component component) => _children.Add(component);
        public override string Operation()
        {
            string result = $"Composite {name} (";
            int i = 0;
            foreach (Component component in _children)
            {
                result += component.Operation();
                if (i != _children.Count - 1) result += "+";
                i++;
            }
            return result + ")";
        }
    }

    public static class CompositeDemo
    {
        public static void Show()
        {
            Composite tree = new Composite("Tree");
            tree.Add(new Leaf("A"));
            tree.Add(new Leaf("B"));
            Console.WriteLine("    [Composite] -> " + tree.Operation());
        }
    }
}
